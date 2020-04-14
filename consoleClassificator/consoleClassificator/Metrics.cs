using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleClassificator
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
    }
}
