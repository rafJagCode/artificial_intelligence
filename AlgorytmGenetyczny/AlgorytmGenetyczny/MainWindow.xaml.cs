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
using static AlgorytmGenetyczny.Settings;

namespace AlgorytmGenetyczny
{
    public partial class MainWindow : Window
    {
        Population population = new Population();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void testBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < iterationAmount; i++)
            {
                population.generateRandomPopulation();
                population.calculateAdaptation();
                //resultBox.Text += population.print()+'\n';
                Population populationAfterTurnament = population.selectNewPopulationUsingTurnament(populationSize-1);
                populationAfterTurnament.mutateOneChromosome();
                Individual best = population.hotDeck();
                populationAfterTurnament.addIndividual(best);
                populationAfterTurnament.calculateAdaptation();
                //resultBox.Text += populationAfterTurnament.print()+'\n';
                resultBox.Text += "Najlepszy: " + best.adaptationFunctionResult.ToString() + '\n';
                resultBox.Text += "Średnia: " + populationAfterTurnament.calcualteAvg().ToString() + '\n';
                population = populationAfterTurnament;
            }
        }
    }
}
