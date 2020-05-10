using System;
using System.Collections.Generic;
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
        string result;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var networkStructure = new List<int> { 2, 2, 1 };
            var testConfiguration = new Configuration(networkStructure);
            var testNetwork = new Network(testConfiguration);
            //var weights = WeightGenerator.getRandomWeights(networkStructure);
            var weights = WeightsHandler.loadWeights("weights.txt");
            testNetwork.setWeights(weights);
            testNetwork.calculateOutput(new List<double> { 1, 0 });
            testNetwork.propagate(testNetwork.getNeuron(1, 0), 1);
            result = testNetwork.getNetworkAsJson()+"\n";
            var cor = testNetwork.getNeuron(0, 1).weightsCorrections;
            foreach(double c in cor)
            {
                result += c.ToString() + '\n';
            }
            resultBox.Text = result;

            //WeightsHandler.saveWeights(weights);
            //var test = WeightsHandler.loadWeights("weights.txt");
        }
    }
}
