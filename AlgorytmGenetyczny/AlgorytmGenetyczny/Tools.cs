using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    class Tools
    {
        public static double adaptationFunction(double x1, double x2)
        {
            return Math.Sin(x1 * 0.05) + Math.Sin(x2 * 0.05) + 0.4 * Math.Sin(x1 * 0.15) * Math.Sin(x2 * 0.15);
        }
        public static int randomZeroOrOne(Random rnd)
        {
            return rnd.Next(0, 2);
        }
        public static List<double> generateRandomValues(Random rnd, int valuesAmount, double minValue, double maxValue)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < valuesAmount; i++)
            {
                result.Add(rnd.NextDouble() * (maxValue - minValue) + minValue);
            }
            return result;
        }
        public static List<int>getRandomGene(Random rnd, int chromosomeAmount)
        {
            List<int> gene = new List<int>();
            for (int i = 0; i < chromosomeAmount; i++)
            {
                int chromosome = randomZeroOrOne(rnd);
                gene.Add(chromosome);
            }
            return gene;
        }
    }
}
