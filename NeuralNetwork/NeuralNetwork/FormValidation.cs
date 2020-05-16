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
                message = "Zły format bety";
                return false;
            }
            if (beta <= 0)
            {
                message = "Beta musi być większa od zera";
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
                message = "Zły format współczynnika nauki";
                return false;
            }
            if (learningFactor <= 0 || learningFactor >=1)
            {
                message = "Współczynnik nauczania musi być liczbą z zakresu 0 do 1";
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
                message = "Liczba epok musi być liczbą całkowitą";
                return false;
            }
            if (epochAmount <= 0)
            {
                message = "Liczba epok musi być większa od zera";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isConfigurationValid(TextBox configurationBox, out string message)
        {
            string configurationString = configurationBox.Text;
            if (configurationString == string.Empty)
            {
                message = "Konfiguracja jest wymagana do stworzenia sieci";
                return false;
            }
            string[] configuration = configurationString.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < configuration.Length; i++)
            {
                int parsed;
                bool isInt = int.TryParse(configuration[i], out parsed);
                if (!isInt)
                {
                    message = "Konfiguracja musi składać się z liczb naturalnych oddzielonych tabulatorem";
                    return false;
                }
                if (parsed <= 0)
                {
                    message = "Konfiguracja powinna składać się z liczb większych od zera";
                    return false;
                }
                if (i == configuration.Length - 1)
                    if (parsed != 1)
                    {
                        message = "Sieć powinna mieć jeden neuron wyjściowy";
                        return false;
                    }
            }
            message = "OK";
            return true;
        }
        public static bool isInputValid(Configuration configuration, TextBox inputBox, out string message)
        {
            string inputString = inputBox.Text;
            string[] input = inputString.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length != configuration.amountOfInputs)
            {
                message = "Podano ilość danych wejściowych nie zgadza się z konfiguracją";
            }
            for (int i = 0; i < input.Length; i++)
            {
                double parsed;
                bool isDouble = double.TryParse(input[i], out parsed);
                if (!isDouble)
                {
                    message = "Dane wejściowe powinny być podane za pomocą liczb zmiennoprzecinkowych";
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
                    message = "Wystąpił problem z numerem warstwy lub neuronu";
                    return false;
                }
                if (neuronNumber > configuration[layerNumber + 1])
                {
                    message = "Ilość neuronów nie zgadza się z konfiguracją sieci";
                    return false;
                }
                if (configuration[layerNumber] != splited.Length - 3)
                {
                    message = "Ilość wag nie zgadza się z ustawioną konfiguracja sieci";
                    return false;
                }
                for (int i = 2; i < splited.Length; i++)
                {
                    double weight;
                    bool weightCanBeParsed = double.TryParse(splited[i], out weight);
                    if (!weightCanBeParsed)
                    {
                        message = "Wagi musza być zapisane jako liczby zmiennoprzecinkowe";
                        return false;
                    }
                }
            }
            message = "OK";
            return true;
        }
        public static bool areLearningSamplesValid(Configuration configuration, string[]text, out string message )
        {
            foreach(string sample in text)
            {
                string[] splitedSample = sample.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitedSample.Length - 1 != configuration.amountOfInputs)
                {
                    message = "Ilość danych wejściowych nie zgodna z konfiguracją";
                    return false;
                }
                foreach (string number in splitedSample)
                {
                    double value;
                    bool canBeParsed = double.TryParse(number, out value);
                    if (!canBeParsed)
                    {
                        message = "Próbki powinny zapisane być jako liczby zmiennoprzecinkowe";
                        return false;
                    }
                }
            }
            message = "OK";
            return true;
        }
        public static bool isMinValid(TextBox minBox, out string message)
        {
            double parsed;
            bool canBeParsed = double.TryParse(minBox.Text, out parsed);
            if (!canBeParsed)
            {
                message = "Zły format min";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isMaxValid(TextBox maxBox, out string message)
        {
            double parsed;
            bool canBeParsed = double.TryParse(maxBox.Text, out parsed);
            if (!canBeParsed)
            {
                message = "Zły format max";
                return false;
            }
            message = "OK";
            return true;
        }
    }
}
