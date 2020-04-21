using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnnAlgortihm
{
    class DataValidation
    {
        public bool isValid = false;
        public string message = "Correct those errors:\n";
        public DataValidation(SampleColection sampleColection, DataLoader dataLoader, ComboBox comboBox, RichTextBox kBox,RichTextBox attrBox)
        {
            if (!isDataLoaded(dataLoader, out string dataError))
            {
                message += dataError;
                return;
            }
            if (!isSampleColectionLoaded(sampleColection, out string sampleColectionError))
            {
                message += sampleColectionError;
                return;
            }
            if (!isSampleOk(attrBox,sampleColection, out string sampleError))
            {
                message += sampleError;
                return;
            }
            if (!isCorrectK(kBox, sampleColection, out string kError))
            {
                message += kError;
                return;
            }
            if (!isMetricChosen(comboBox, out string metricError))
            {
                message += metricError;
                return;
            }
            isValid = true;
        }
        public static bool isDataLoaded(DataLoader dataLoader, out string error)
        {
            if (dataLoader == null)
            {
                error = "You must select a file first\n";
                return false;
            }
            if (!dataLoader.isLoaded)
            {
                error = "There was a problem with loading your file\n";
                return false;
            }
            error = "Ok";
            return true;
        }
        public static bool isSampleColectionLoaded(SampleColection sampleColection, out string error)
        {
            if (sampleColection == null)
            {
                error= "You must load correct file first";
                return false;
            }
            error = "Ok";
            return true;
        }
        public static bool isMetricChosen(ComboBox comboBox, out string error)
        {
            if (comboBox.SelectedIndex == -1)
            {
                error = "Metric is not selected\n";
                return false;
            }
            error = "Ok";
            return true;
        }
        public static bool isCorrectK(RichTextBox kBox, SampleColection sampleColection, out string error)
        {
            int maxK = KChecker.maxK(sampleColection);
            int result;
            bool parsed = int.TryParse(kBox.Text, out result);
            if (!parsed)
            {
                error = "K must be an integer\n";
                return false;
            }
            if (result < 1 || result > maxK)
            {
                error = "K must be an integer between 1 and " + maxK+ "\n";
                return false;
            }
            error = "Ok";
            return true;
        }
        public static bool isSampleOk(RichTextBox attrBox, SampleColection samplesColection, out string error)
        {
            if (attrBox.Text == "")
            {
                error = "You must enter a sample\n";
                return false;
            }
            var text = attrBox.Text.Trim().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < text.Length; i++)
            {
                text[i]=Data.convertDoubleFormat(text[i].Trim());
                double result;
                bool parsed = double.TryParse(text[i], out result);
                if (!parsed)
                {
                    error = "Wrong sample format\n";
                    return false;
                }
            }
            int fileSamplesLength = samplesColection.samples.First().attributes.Count;
            if (text.Length != fileSamplesLength)
            {
                error = "There must be the same amount of attributes in attributes filed like in samples in file";
                return false;
            }
            error = "Ok";
            return true;
        }
        public static bool isCorrectP(RichTextBox pBox, out string error)
        {
            int p;
            bool parsed = int.TryParse(pBox.Text, out p);
            if (!parsed)
            {
                error = "P must be an integer";
                return false;
            }
            if (p < 1)
            {
                error = "P must be bigger than 0";
                return false;
            }
            error = "P is Ok";
            return true;
        }

    }
}
