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
using MahApps.Metro.Controls;
using System.ComponentModel;

namespace AlgorytmGenetyczny
{
    public partial class MainWindow : MetroWindow
    {
        Population population = new Population();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void testBtn_Click(object sender, RoutedEventArgs e)
        {
            string message;
            if (!DataValidator.areInputsOk(
                iterationBox.Text,
                populationSizeBox.Text,
                turnamentSizeBox.Text,
                mutationRateBox.Text,
                chromosomePerParemeterBox.Text,
                out message))
            {
                MessageBox.Show(message);
                return;
            }
            resultBox.Text = "";
            iterationAmount = int.Parse(iterationBox.Text);
            populationSize = int.Parse(populationSizeBox.Text);
            turnamentSize = int.Parse(turnamentSizeBox.Text);
            mutationRate = int.Parse(mutationRateBox.Text);
            chromosomAmountPerParameter = int.Parse(chromosomePerParemeterBox.Text);

            population.generateRandomPopulation();
            population.calculateAdaptation();

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork;
            if (worker.IsBusy == true)
            {
                MessageBox.Show("Poczekaj na zakończenie poprzedniego procesu");
                return;
            }
            progressBar.Visibility = Visibility.Visible;
            worker.RunWorkerAsync();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            StringBuilder result = new StringBuilder();
            BackgroundWorker worker = sender as BackgroundWorker;
            result.Append("STARTING POPULATION\n");
            result.Append(population.print() + '\n');

            for (int i = 0; i < iterationAmount; i++)
            {
                double progress = (double)(i + 1) / iterationAmount * 100;
                Population populationAfterTurnament = population.selectNewPopulationUsingTurnament(populationSize - 1);
                populationAfterTurnament.mutateOneChromosome();
                Individual best = population.hotDeck();
                populationAfterTurnament.addIndividual(best);
                populationAfterTurnament.calculateAdaptation();
                worker.ReportProgress((int)progress);
                result.Append("ITERATION NUMBER: " + (i + 1) + '\n');
                result.Append(populationAfterTurnament.print() + '\n');
                result.Append("Najlepszy: " + best.adaptationFunctionResult.ToString() + '\n');
                result.Append("Średnia: " + populationAfterTurnament.calcualteAvg().ToString() + "\n\n");
                population = populationAfterTurnament;
                resultBox.Dispatcher.Invoke(new Action(delegate ()
                {
                    resultBox.Text=result.ToString();
                }));
            }
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (progressBar.Value == 100)
            {
                progressBar.Visibility = Visibility.Hidden;
            }

        }
    }
}
