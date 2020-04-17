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
        public Form1()
        {
            InitializeComponent();
            attrBox.AcceptsTab = true;
            comboBox.Items.Add("Euclidean Metric");
            comboBox.Items.Add("Manhattan Metric");
            comboBox.Items.Add("Czybaszew Metric");

        }
        
        private void loadData_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var file = new FileInfo(ofd.FileName);
            if (file.Extension != ".txt")
            {
                MessageBox.Show("Dozwolone rozszerzenie to \"TXT\"");
                return;
            }
            var rows = File.ReadAllLines(ofd.FileName);
            var data = new Data(rows);
            sampleColection = new SampleColection(data.dataFromFile);
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            attrBox.Visible = true;
            kBox.Visible = true;
            comboBox.Visible = true;
            loadData.Visible = false;
            confirm.Visible = true;

            //double precision=Algorithm.precision(sampleColection,3,Metrics.euklideanMetric);
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            int k;
            bool correctK = int.TryParse(kBox.Text,out k);
            if (!correctK)
            {
                MessageBox.Show("Podaj K ktore jest liczba calkowita");
                return;
            }
            Algorithm.metric metric= Metrics.euklideanMetric;
            
            string userSampleString = attrBox.Text;
            if (comboBox.SelectedItem == "Euclidean Metric") metric = Metrics.euklideanMetric;
            if (comboBox.SelectedItem == "Manhattan Metric") metric = Metrics.manhattanMetric;
            if (comboBox.SelectedItem == "Czybaszew Metric") metric = Metrics.czybaszewMetric;
            List<double> attributesToCheck = Data.rowToList(userSampleString);
            Normalization.normalizeAttributes(sampleColection, attributesToCheck);
            Normalization.normalizeSamples(sampleColection);
            int? decision = Algorithm.chooseDecision(attributesToCheck, sampleColection, k, metric);
            MessageBox.Show("Decyzja dla podanych argumentow to: " +decision);
        }

    }
}
