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
    }
}
