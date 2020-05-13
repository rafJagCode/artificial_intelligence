using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace NeuralNetwork
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        
        Network testNetwork;
        Learning testLearn = new Learning();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var networkStructure = new List<int> { 2, 2, 1 };
            var testConfiguration = new Configuration(networkStructure);
            testNetwork = new Network(testConfiguration);
            var weights = WeightGenerator.getRandomWeights(networkStructure);
            //var weights = WeightsHandler.loadWeights("learningEffects.txt");
            testNetwork.setWeights(weights);


            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork;
     
            if (worker.IsBusy != true)
            {
                worker.RunWorkerAsync();
            }
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
            testLearn.addLearningSamples();
            testLearn.learn(testNetwork, 2000000, worker, 1, 0.1);
            var weightsAfterLearning = testNetwork.getWeights();
            WeightsHandler.saveWeights(weightsAfterLearning, "learningEffects.txt");
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (progressBar.Value == 100) resultBox.Text = testLearn.checkError(testNetwork, testLearn.learningSamples,1);
        }
        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            var test = new TestingObjects();
            Network fromClasses = new Network(test.configuration);
            fromClasses.setWeights(test.weights);
            double output = fromClasses.calculateOutput(test.inputs,1);
            resultBox.Text = output.ToString();
            fromClasses.propagate(fromClasses.getOutputNeuron(), 1,1,0.1);
            fromClasses.applyWeightsCorrections();
            var newWeights = fromClasses.getWeights();

            WeightsHandler.saveWeights(newWeights, "test.txt");
        }

        private void loadLearningSamplesBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void createNetworkBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void loadWeightsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void saveWeightsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void generateRandomWeightsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void learnBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
