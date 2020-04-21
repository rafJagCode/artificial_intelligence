using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnnAlgortihm
{
    class Metrics
    {
        public delegate double metric(List<double> attrToCheck, List<double> attrToCompare,int p=0);
        //public delegate double metric(List<double> attrToCheck, List<double> attrToCompare,int p);
        public static metric chooseMetric(ComboBox comboBox)
        {
            if ((string)comboBox.SelectedItem == "Euclidean Metric") return euklideanMetric;
            if ((string)comboBox.SelectedItem == "Manhattan Metric") return manhattanMetric;
            if ((string)comboBox.SelectedItem == "Logarithmic Metric") return logarithmicMetric;
            if((string)comboBox.SelectedItem == "Czybaszew Metric") return czybaszewMetric;
            return minkowskiMetric;

        }
        public static double euklideanMetric(List<double> attrToCheck, List<double> attrToCompare, int p=0)
        {
            double distance = 0;
            for (int i = 0; i < attrToCheck.Count; i++)
            {
                distance += Math.Pow(attrToCheck[i] - attrToCompare[i], 2);
            }
            return Math.Sqrt(distance);
        }
        public static double manhattanMetric(List<double> attrToCheck, List<double> attrToCompare, int p=0)
        {
            double distance = 0;
            for (int i = 0; i < attrToCheck.Count; i++)
            {
                distance += Math.Abs(attrToCheck[i] - attrToCompare[i]);
            }
            return distance;
        }
        public static double czybaszewMetric(List<double> attrToCheck, List<double> attrToCompare, int p=0)
        {
            double distance= Math.Abs(attrToCheck[0] - attrToCompare[0]);
            for (int i = 1; i < attrToCheck.Count; i++)
            {
                double tmp = Math.Abs(attrToCheck[i] - attrToCompare[i]);
                if (tmp > distance) distance = tmp;
            }
            return distance;
        }
        public static double logarithmicMetric(List<double> attrToCheck, List<double> attrToCompare, int p=0)
        {
            double distance = 0;
            for (int i = 0; i < attrToCheck.Count; i++)
            {
                distance += Math.Abs(Math.Log(attrToCheck[i]) - Math.Log(attrToCompare[i]));
            }
            return distance;
        }
        public static double minkowskiMetric(List<double> attrToCheck, List<double> attrToCompare, int p)
        {
            double distance = 0;
            for (int i = 0; i < attrToCheck.Count; i++)
            {
                distance += Math.Pow(Math.Abs(attrToCheck[i] - attrToCompare[i]), p);
            }
            return Math.Pow(distance,(double)1/p);
        }
    }
}
