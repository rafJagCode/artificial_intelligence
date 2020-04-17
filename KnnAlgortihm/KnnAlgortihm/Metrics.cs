using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class Metrics
    {
        public static double euklideanMetric(List<double> attrToCheck, List<double> attrToCompare)
        {
            double distance = 0;
            for (int i = 0; i < attrToCheck.Count; i++)
            {
                distance += Math.Pow(attrToCheck[i] - attrToCompare[i], 2);
            }
            return Math.Sqrt(distance);
        }
        public static double manhattanMetric(List<double> attrToCheck, List<double> attrToCompare)
        {
            double distance = 0;
            for (int i = 0; i < attrToCheck.Count; i++)
            {
                distance += Math.Abs(attrToCheck[i] - attrToCompare[i]);
            }
            return distance;
        }
        public static double czybaszewMetric(List<double> attrToCheck, List<double> attrToCompare)
        {
            double distance= Math.Abs(attrToCheck[0] - attrToCompare[0]);
            for (int i = 1; i < attrToCheck.Count; i++)
            {
                double tmp = Math.Abs(attrToCheck[i] - attrToCompare[i]);
                if (tmp > distance) distance = tmp;
            }
            return distance;
        }
    }
}
