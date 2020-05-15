using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NeuralNetwork
{
    class FormValidation
    {
        public static bool isBetaValid(TextBox betaBox, out string message)
        {
            string betaString = betaBox.Text;
            double beta;
            bool isDouble = double.TryParse(betaString, out beta);
            if (!isDouble)
            {
                message = "Bad beta format";
                return false;
            }
            if (beta <= 0)
            {
                message = "Beta must be greater than 0";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isLearningFactorValid(TextBox learningFactorBox, out string message)
        {
            string learningFactorString = learningFactorBox.Text;
            double learningFactor;
            bool isDouble = double.TryParse(learningFactorString, out learningFactor);
            if (!isDouble)
            {
                message = "Bad learning factor format";
                return false;
            }
            if (learningFactor <= 0 || learningFactor >=1)
            {
                message = "Learning factor must be between 0 and 1";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isEpochAmountValid(TextBox epochAmountBox, out string message)
        {
            string epochAmountString = epochAmountBox.Text;
            int epochAmount;
            bool isInt = int.TryParse(epochAmountString, out epochAmount);
            if (!isInt)
            {
                message = "Epoch amount must be an integer";
                return false;
            }
            if (epochAmount <= 0)
            {
                message = "Epoch amount must be greater than 0";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isConfigurationValid(TextBox configurationBox, out string message)
        {
            string configurationString = configurationBox.Text;
            string[] configuration = configurationString.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < configuration.Length; i++)
            {
                int parsed;
                bool isInt = int.TryParse(configuration[i], out parsed);
                if (!isInt)
                {
                    message = "Configuration must consist of integers";
                    return false;
                }
                if (i == configuration.Length - 1)
                    if (parsed != 1)
                    {
                        message = "Should be only one output";
                        return false;
                    }
            }
            message = "OK";
            return true;
        }
        public static bool isInputValid(TextBox inputBox, out string message)
        {
            string inputString = inputBox.Text;
            string[] input = inputString.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                double parsed;
                bool isDouble = double.TryParse(input[i], out parsed);
                if (!isDouble)
                {
                    message = "Configuration must consist of doubles";
                    return false;
                }
            }
            message = "OK";
            return true;
        }
        public static bool areWeightsValid(List<int>configuration, string[] weights, out string message)
        {
            foreach(string neuronWeights in weights)
            {
                string[] splited = neuronWeights.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int layerNumber;
                int neuronNumber;
                bool layerNumberCanBeParsed = int.TryParse(splited[0], out layerNumber);
                bool neuronNumberCanBeParsed = int.TryParse(splited[1], out neuronNumber);
                if(!layerNumberCanBeParsed || !neuronNumberCanBeParsed)
                {
                    message = "There was some problem with parsing in neuron identificator";
                    return false;
                }
                if (neuronNumber > configuration[layerNumber + 1])
                {
                    message = "Amount of neurons in layers is specified otherwise in configuration";
                    return false;
                }
                if (configuration[layerNumber] != splited.Length - 2)
                {
                    message = "There is different weight amount specified by configuration then in file";
                    return false;
                }
                for (int i = 2; i < splited.Length; i++)
                {
                    double weight;
                    bool weightCanBeParsed = double.TryParse(splited[i], out weight);
                    if (!weightCanBeParsed)
                    {
                        message = "weights must be double";
                        return false;
                    }
                }
            }
            message = "OK";
            return true;
        }
    }
}
