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
            //Neuron newNeuron = new Neuron(1, 0);
            //newNeuron.setHiddenInputValue(1);
            //newNeuron.setWeights(new List<double> { 0.3,0.1, 0.2 });
            //result = newNeuron.getNeuronAsJson();
            Configuration testConfiguration = new Configuration(new List<int> { 2, 2, 1 });
            Network testNetwork = new Network(testConfiguration.getNeuronsConfiguration());
            var weights = new Dictionary<int[], List<double>>();
            weights.Add(new int[] { 0, 0 }, new List<double> { 0.3, 0.1, 0.2 });
            weights.Add(new int[] { 0, 1 }, new List<double> { 0.6, 0.4, 0.5 });
            weights.Add(new int[] { 1, 0 }, new List<double> { 0.9, 0.7, -0.8 });
            testNetwork.setWeights(weights);
            result = testNetwork.getNetworkAsJson() + testNetwork.calculateOutput(new List<double> { 1, 0 }).ToString();
            resultBox.Text = result;
        }
    }
}
