using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace NeuralNetwork
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Network network;
        Configuration configuration;
        bool weightsLoaded = false;
        Dictionary<int[], List<double>> weights;
        Learning learning;
        int epochAmount;
        double beta;
        double learningFactor;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadLearningSamplesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (network == null)
            {
                learningSamplesStatus.Content = "Stwórz najpierw sieć";
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != true)
            {
                learningSamplesStatus.Content = "Wystąpił problem podczas ładowania wybranego pliku";
                return;
            }
            string path = openFileDialog.FileName;
            string[] learningSamples = File.ReadAllLines(path);
            if (!FormValidation.areLearningSamplesValid(configuration, learningSamples, out string message))
            {
                learningSamplesStatus.Content = message;
                return;
            }
            learning = new Learning(learningSamples);
            learningSamplesStatus.Content = "Próbki załadowane";
            denormalizationBox.Text = "Min = " + learning.min.ToString() + " Max = " + learning.max.ToString();
        }
        private void createNetworkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!FormValidation.isConfigurationValid(configurationBox, out string configurationError))
            {
                networkStatus.Content = configurationError;
                return;
            }
            configuration = new Configuration(configurationBox.Text);
            network = new Network(configuration);
            reset();
            networkStatus.Content = "Sieć utworzona";
        }
        private void loadWeightsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (network == null)
            {
                weightsStatus.Content = "Stwórz najpierw sieć";
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != true)
            {
                weightsStatus.Content = "Wystąpił problem z wybranym plikiem";
                return;
            }
            string path = openFileDialog.FileName;
            string[] weightsString = File.ReadAllLines(path);

            if (!FormValidation.areWeightsValid(configuration.networkStructure, weightsString, out string message))
            {
                weightsStatus.Content = message;
                return;
            }
            weights = WeightsHandler.loadWeights(path);
            network.setWeights(weights);
            weightsStatus.Content = "Załadowano wagi";
            weightsLoaded = true;
        }
        private void saveWeightsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!weightsLoaded)
            {
                savingStatus.Content = "Brak wag do zapisania";
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() != true)
            {
                return;
            }
            if (saveFileDialog.FileName == "")
            {
                savingStatus.Content = "Wagi nie zapisane, plik musi mieć nazwę";
                return;
            }
            var path = saveFileDialog.FileName;
            WeightsHandler.saveWeights(weights, path);
            savingStatus.Content = "Wagi zapisane";
        }
        private void generateRandomWeightsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (network == null)
            {
                weightsStatus.Content = "Stwórz najpierw sieć";
                return;
            }
            weights = WeightGenerator.getRandomWeights(configuration.networkStructure);
            network.setWeights(weights);
            weightsStatus.Content = "Losowe wagi zaladowane";
            weightsLoaded = true;
        }
        private void learnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (network == null)
            {
                learningStatus.Content = "Stwórz najpierw sieć";
                return;
            }
            if (!weightsLoaded)
            {
                learningStatus.Content = "Załaduj najpierw wagi";
                return;
            }
            if (learning == null)
            {
                learningStatus.Content = "Załaduj najpierw próbki uczące";
                return;
            }
            if (!FormValidation.isBetaValid(betaBox, out string betaMessage))
            {
                learningStatus.Content = betaMessage;
                return;
            }
            if (!FormValidation.isLearningFactorValid(learningFactorBox, out string LearningFactorMessage))
            {
                learningStatus.Content = LearningFactorMessage;
                return;
            }
            if (!FormValidation.isEpochAmountValid(epochAmountBox, out string epochMessage))
            {
                learningStatus.Content = epochMessage;
                return;
            }
            epochAmount = int.Parse(epochAmountBox.Text);
            beta = double.Parse(betaBox.Text);
            learningFactor = double.Parse(learningFactorBox.Text);

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork;

            if (worker.IsBusy == true)
            {
                learningStatus.Content = "Poczekaj na zakończenie procesu uczenia";
                return;
            }
            progressBar.Visibility = Visibility.Visible;
            worker.RunWorkerAsync();

        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            learning.learn(network, epochAmount, worker, beta, learningFactor);
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (progressBar.Value == 100)
            {
                learningStatus.Content = "Uczenie zakończone";
                progressBar.Visibility = Visibility.Hidden;
            }

        }
        private void outputBtn_Click(object sender, RoutedEventArgs e)
        {
            if (network == null)
            {
                resultBox.Text = "Najpierw stwórz sieć";
                return;
            }
            if (!FormValidation.isBetaValid(inputBetaBox, out string message))
            {
                resultBox.Text = message;
                return;
            }
            if (!FormValidation.isInputValid(configuration, inputBox, out string inputMessage))
            {
                resultBox.Text = inputMessage;
                return;
            }
            if(!FormValidation.isMinValid(minBox, out string minMessage)){
                resultBox.Text = minMessage;
                return;
            }
            if (!FormValidation.isMaxValid(minBox, out string maxMessage))
            {
                resultBox.Text = maxMessage;
                return;
            }
            double min = double.Parse(minBox.Text);
            double max = double.Parse(maxBox.Text);
            double inputBeta = double.Parse(inputBetaBox.Text);
            var inputs = Tools.convertStringToDoubleList(inputBox.Text);
            double output = network.calculateOutput(inputs, inputBeta);
            double denormalizedOutput = Tools.getDenormalizedValue(output, min, max);
            resultBox.Text = denormalizedOutput.ToString();
        }
        public void reset()
        {
            learning = null;
            learningSamplesStatus.Content = "Próbki nie załadowane";
            weightsLoaded = false;
            weightsStatus.Content = "Wagi nie załadowane";
            inputBetaBox.Text = "";
            inputBetaBox.Text = "";
            resultBox.Text = "";
            minBox.Text = "";
            maxBox.Text = "";
            savingStatus.Content = "";
            learningStatus.Content = "";
            betaBox.Text = "";
            learningFactorBox.Text = "";
            epochAmountBox.Text = "";
            denormalizationBox.Text = "";
        }
    }
}
