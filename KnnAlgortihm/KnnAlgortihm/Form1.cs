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
        public Form1()
        {
            InitializeComponent();
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
            }
            var rows = File.ReadAllLines(ofd.FileName);
            var data = new Data(rows);
            var sampleColection = new SampleColection(data.dataFromFile);
            string userSampleString= "4.6\t3.4\t1.4\t0.3";
            List<double> userSampleAttr = Data.rowToList(userSampleString);
            sampleColection.normalizeAttributes(userSampleAttr);
            sampleColection.normalizeSamples();
            int? decision=Algorithm.chooseDecision(userSampleAttr, sampleColection, 3, Metrics.euklideanMetric);
            double precision=Algorithm.precision(sampleColection,3,Metrics.euklideanMetric);
        }
    }
}
