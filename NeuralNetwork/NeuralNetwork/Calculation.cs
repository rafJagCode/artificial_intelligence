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
        public static double calculateCorrection(double expected, double received, double learningFactor=0.1)
        {
            double correction = learningFactor * Math.Abs(expected - received);
            return correction;
        }
        public static double calculateOutputDifference(double outputSumDifference, double weight)
        {
            double outputDifference;
            outputDifference = outputSumDifference * weight;
            return 1;
        }
        public static double calculateSumDifference(double outputDifference, double sum, double beta = 1)
        {
            double sumDifference;
            double fx = calcualateActivation(sum);
            sumDifference = outputDifference * beta * fx * (1 - fx);
            return sumDifference;
        }
        public static double calculateWeightDifference(double sumDifference, double input)
        {
            double weightDifference;
            weightDifference = sumDifference * input;
            return weightDifference;
        }
    }
}
