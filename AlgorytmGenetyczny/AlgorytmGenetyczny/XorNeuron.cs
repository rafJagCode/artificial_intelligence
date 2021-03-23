using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmGenetyczny.Settings;

namespace AlgorytmGenetyczny
{
    class XorNeuron
    {
        int layerNumber;
        int neuronNumber;
        public double[] weights = new double[3];
        public XorNeuron(int layerNumber, int neuronNumber)
        {
            this.layerNumber = layerNumber;
            this.neuronNumber = neuronNumber;
        }
        public double calculateSum(double [] inputs)
        {
            double result = 0;
            for (int i = 0; i < 3; i++)
            {
                result+=this.weights[i] * inputs[i];
            }
            return result;
        }
        public double calculateActivation(double [] inputs)
        {
            double sum = calculateSum(inputs);
            return 1 / (1 + Math.Pow(Math.E, (-1 * 1 * sum)));
        }
    }
}
