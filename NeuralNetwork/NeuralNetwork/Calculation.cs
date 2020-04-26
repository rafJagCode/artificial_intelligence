using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Calculation
    {
        public static double calcualateSum(List<double>inputs, List<double> weights)
        {
            double result = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                result += inputs[i] * weights[i];
            }
            return result;
        }
        public static double calcualateActivation(double sum)
        {
            return 1 / (1+Math.Pow(Math.E, (-1 * sum)));
        }
    }
}
