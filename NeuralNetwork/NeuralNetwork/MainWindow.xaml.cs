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
            Configuration configuration = new Configuration(new List<int> { 2, 2, 1 });
            Network fromClasses = new Network(configuration);
            var weights = new Dictionary<int[], List<double>>();
            weights.Add(new int[] { 0, 0 }, new List<double> { 0.3, 0.1, 0.2 });
            weights.Add(new int[] { 0, 1 }, new List<double> { 0.6, 0.4, 0.5 });
            weights.Add(new int[] { 1, 0 }, new List<double> { 0.9, 0.7, -0.8 });
            fromClasses.setWeights(weights);
            var inputs = new List<double> { 1, 0 };
            double output = fromClasses.calculateOutput(inputs,1);
            fromClasses.propagate(fromClasses.getOutputNeuron(), 1,1,0.1);
            fromClasses.applyWeightsCorrections();
            var newWeights = fromClasses.getWeights();
            WeightsHandler.saveWeights(newWeights, "test.txt");
        }
    }
}
