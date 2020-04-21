using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KnnAlgortihm
{
    public partial class Form1 : Form
    {

        SampleColection sampleColection;
        DataLoader dataLoader;
        List<string> results = new List<string>();
        List<string> kResults = new List<string>();
        int p = 0;
        public Form1()
        {
            InitializeComponent();
            bgw = new BackgroundWorker();
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            bgw.ProgressChanged += bgw_ProgressChanged;
            bgw.WorkerReportsProgress = true;
            comboBox.Items.Add("Euclidean Metric");
            comboBox.Items.Add("Manhattan Metric");
            comboBox.Items.Add("Czybaszew Metric");
            comboBox.Items.Add("Logarithmic Metric");
            comboBox.Items.Add("Minkowski Metric");
            comboBox.SelectionChangeCommitted += ComboBoxSelectionChangeCommitted;

        }

        private void loadData_Click(object sender, EventArgs e)
        {
            dataLoader = new DataLoader(ofd);
            if (!DataValidation.isDataLoaded(dataLoader, out string dataError))
            {
                dataInfo.Text = dataError;
                return;
            }
            sampleColection = new SampleColection(dataLoader.data);
            var samplesAmount = sampleColection.countSamples();
            var decisionAmount = sampleColection.possibleDecisions().Count;
            var attributesAmount = sampleColection.samples.First().attributes.Count;
            var maxK = KChecker.maxK(sampleColection);
            dataInfo.Text = "File OK\n";
            dataInfo.Text += "Loaded " + samplesAmount + " samples\n";
            dataInfo.Text += "There are " + decisionAmount + " decisions possible\n";
            dataInfo.Visible = true;
            attributesInfo.Text = "Attributes";
            attributesInfo.Text += "\nEnter " + attributesAmount+" attributes";
            kInfo.Text = "K";
            kInfo.Text += "\nK must be between 1 and " + maxK;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            Metrics.metric metric;
            DataValidation dataValidation;
            int k;
            string userSampleString;
            List<double> attributesToCheck;
            int? decision;

            if (!DataValidation.isDataLoaded(dataLoader, out string dataError))
            {
                MessageBox.Show(dataError);
                return;
            }
            dataValidation = new DataValidation(sampleColection, dataLoader, comboBox, kBox, attrBox);
            if (!dataValidation.isValid)
            {
                MessageBox.Show(dataValidation.message);
                return;
            }
            if ((string)comboBox.SelectedItem == "Minkowski Metric")
            {
                if (!DataValidation.isCorrectP(pBox, out string pError))
                {
                    MessageBox.Show(pError);
                    return;
                }
            }
            p = int.Parse(pBox.Text);
            k = int.Parse(kBox.Text);
            userSampleString = attrBox.Text;
            metric = Metrics.chooseMetric(comboBox);
            attributesToCheck = Data.rowToList(userSampleString);



            decision = Algorithm.chooseDecision(attributesToCheck, sampleColection, k, metric,p);
            resultsTextBox.Text = "";
            results.Add("Attributes: " + userSampleString + "\nK: " + k + "\nMetric: " + comboBox.SelectedItem + "\nDecision: " + (decision == null ? "Couldn't solve" : decision.ToString())+"\n----------\n");
            foreach(string result in results)
            {
                resultsTextBox.Text += result;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            resultsTextBox.Text = "";
            results.Clear();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            
            if (!DataValidation.isDataLoaded(dataLoader, out string dataError))
            {
                MessageBox.Show(dataError);
                return;
            }
            if(!DataValidation.isMetricChosen(comboBox, out string metricError))
            {
                MessageBox.Show(metricError);
                return;
            }
            if((string)comboBox.SelectedItem=="Minkowski Metric")
            {
                if (!DataValidation.isCorrectP(pBox, out string pError))
                {
                    MessageBox.Show(pError);
                    return;
                }
            }
            p = int.Parse(pBox.Text);
            var data = new List<object>();
            data.Add(Metrics.chooseMetric(comboBox));
            data.Add(comboBox.SelectedItem);
            if (bgw.IsBusy)
            {
                MessageBox.Show("Searching in progress");
                return;
            }
            progBar.Visible = true;
            resultLabel.Visible = true;
            bgw.RunWorkerAsync(data);

        }

        private void clearKbtn_Click(object sender, EventArgs e)
        {
            if (bgw.IsBusy)
            {
                MessageBox.Show("Wait for the end of the search");
                return;
            }
            kResults.Clear();
            searchKtextBox.Text = "";
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            var data = (List<object>)e.Argument;
            Metrics.metric metric = data[0] as Metrics.metric;
            string choosedMetric = data[1] as string;
            double precision;
            int maxK = KChecker.maxK(sampleColection);
            for (int i = 1; i < maxK; i++)
            {
                precision = OneVsRest.precision(sampleColection, i, metric,p);
                kResults.Add("K: " + i + " Metric: " + choosedMetric + "\nPrecision: " + Math.Round(Convert.ToDecimal(precision), 2) + "%\n----------\n");
                double procentage = (double)i / (maxK-1) * 100;
                bgw.ReportProgress((int)procentage);
            }
        }
        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            progBar.Value = e.ProgressPercentage;
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progBar.Visible = false;
            resultLabel.Visible = false;
            searchKtextBox.Text = "";
            foreach (string result in kResults)
            {
                searchKtextBox.Text += result;
            }
        }
        private void ComboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            if((string)comboBox.SelectedItem=="Minkowski Metric") {
                pBox.Visible = true;
                pLabel.Visible = true;
            }
            else
            {
                pBox.Visible = false;
                pLabel.Visible = false;
            }
        }
    }
}
