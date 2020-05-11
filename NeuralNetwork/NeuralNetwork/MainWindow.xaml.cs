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

namespace NeuralNetwork
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void printDelegate();
        string result;
        Network testNetwork;
        Learning testLearn = new Learning();
        StringBuilder difference = new StringBuilder();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var networkStructure = new List<int> { 2, 2, 1 };
            var testConfiguration = new Configuration(networkStructure);
            testNetwork = new Network(testConfiguration);
            //var weights = WeightGenerator.getRandomWeights(networkStructure);
            var weights = WeightsHandler.loadWeights("learningEffects.txt");
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
            
            testLearn.addTestingSamples();
            testLearn.learn(testNetwork, 200000, worker);
            var weightsAfterLearning = testNetwork.getWeights();
            WeightsHandler.saveWeights(weightsAfterLearning, "learningEffects.txt");

        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.UserState)
            {
                case null:
                    progressBar.Value = e.ProgressPercentage;
                    break;
                default:
                    difference.Append(e.UserState.ToString() + '\n');
                    resultBox.Text = difference.ToString();
                    break;
            }
            if (progressBar.Value == 100) resultBox.Text = testLearn.checkError(testNetwork);
        }

    }
}
