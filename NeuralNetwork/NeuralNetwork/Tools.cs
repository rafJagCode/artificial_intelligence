using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Tools
    {
        public static List<double> convertStringToDoubleList(string text)
        {
            var list = new List<double>();
            string[] splitedText = text.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string value in splitedText)
            {
                double number = double.Parse(value);
                list.Add(number);
            }
            return list;
        }
        public static double findMinInDoubleList(List<double> list)
        {
            double min = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < min) min = list[i];
            }
            return min;
        }
        public static double findMaxInDoubleList(List<double> list)
        {
            double max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > max) max = list[i];
            }
            return max;
        }
        public static double getNormalizedValue(double value, double min, double max)
        {
            return (value - min) / (max - min);
        }
        public static double getDenormalizedValue(double value, double min, double max)
        {
            return value * (max - min) + min;
        }
    }
}
