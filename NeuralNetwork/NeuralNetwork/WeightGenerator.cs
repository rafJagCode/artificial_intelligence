using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class WeightGenerator
    {
        static Random randomGenerator = new Random(); 
        public static Dictionary<int[], List<double>> getRandomWeights(List<int>networkStructure)
        {
            var result = new Dictionary<int[], List< double >>();
            for (int i = 1; i < networkStructure.Count; i++)
            {
                int inputs = networkStructure[i - 1];
                int neuronAmount = networkStructure[i];
                for (int j = 0; j < neuronAmount; j++)
                {
                    int[] neuronId = { i - 1, j };
                    var weights = getRandomNeuronWeights(inputs);
                    result.Add(neuronId, weights);
                }
            }
            return result;
        }
        public static List<double> getRandomNeuronWeights(int amount)
        {
            var result = new List<double>();
            for (int i = 0; i < amount+1; i++)
            {
                result.Add(getRandomDoubleInRange(0.1, 0.2) * getPlusOrMinusOne());
            }
            return result;
        }
        public static double getRandomDoubleInRange(double minNumber, double maxNumber)
        {
            return randomGenerator.NextDouble() * (maxNumber - minNumber) + minNumber;
        }
        public static double getPlusOrMinusOne()
        {
            return randomGenerator.NextDouble() < 0.5 ? -1 : 1;
        }
    }
}
