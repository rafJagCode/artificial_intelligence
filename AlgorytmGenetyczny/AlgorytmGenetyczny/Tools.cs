using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmGenetyczny.Settings;

namespace AlgorytmGenetyczny
{
    class Tools
    {
        public static double adaptationFunction(double x1, double x2)
        {
            return Math.Sin(x1 * 0.05) + Math.Sin(x2 * 0.05) + 0.4 * Math.Sin(x1 * 0.15) * Math.Sin(x2 * 0.15);
        }
        public static int randomZeroOrOne()
        {
            return rnd.Next(0, 2);
        }
        public static List<double> generateRandomValues(int valuesAmount, double minValue, double maxValue)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < valuesAmount; i++)
            {
                result.Add(rnd.NextDouble() * (maxValue - minValue) + minValue);
            }
            return result;
        }
        public static List<int>getRandomGene(int chromosomeAmount)
        {
            List<int> gene = new List<int>();
            for (int i = 0; i < chromosomeAmount; i++)
            {
                int chromosome = randomZeroOrOne();
                gene.Add(chromosome);
            }
            return gene;
        }
        public static int[] getRandomIndexes(int indexesAmount, int indexesRange)
        {
            int[] selectedIndexes = new int[indexesRange];
            selectedIndexes = fillArray(selectedIndexes, 0);
            while (indexesAmount > 0)
            {
                int tmp = rnd.Next(indexesRange);
                if (selectedIndexes[tmp] == 0)
                {
                    selectedIndexes[tmp] = 1;
                    indexesAmount--;
                }
            }
            return selectedIndexes;
        }
        public static int[] fillArray(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
            return array;
        }


    }   
}
