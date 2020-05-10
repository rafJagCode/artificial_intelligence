using Newtonsoft.Json;
using System.Collections.Generic;
namespace NeuralNetwork
{
    class Neuron
    {
        public List<double> inputDifferences;
        public List<double> weightsCorrections;
        public int layerNumber;
        [JsonProperty] int neuronNumber;
        [JsonProperty] double hiddenInputValue=1;
        [JsonProperty] List<double> weights;
        [JsonProperty] double sum;
        [JsonProperty] double output;
        public List<double> inputs;
        bool isOutputNeuron = false;
        public Neuron(int layerNumber, int neuronNumber, bool isOutputNeuron)
        {
            this.isOutputNeuron = isOutputNeuron;
            this.layerNumber = layerNumber;
            this.neuronNumber = neuronNumber;
        }
        public void setWeights(List<double>weights)
        {
            this.weights = new List<double>(weights);
        }

        public double calculateOutput(List<double>inputs)
        {
            this.inputs = new List<double>(inputs);
            this.inputs.Insert(0,this.hiddenInputValue);
            this.sum = Calculation.calcualateSum(this.inputs, this.weights);
            this.output= Calculation.calcualateActivation(sum);
            return this.output;

        }
        public string getNeuronAsJson()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented);
        }
        public void setInputDifferences(double sumDifference)
        {
            var inputDifferences = new List<double>();
            for (int i = 1; i < this.weights.Count; i++)
            {
                double inputDifference = sumDifference * weights[i];
                inputDifferences.Add(inputDifference);
            }
            this.inputDifferences = inputDifferences;
        }
        public void setWeightsCorrections(double expected = 0, double inputDifference = 0)
        {
            var weightsCorrections = new List<double>();
            double outputDifference = calcualateOutputDifference(expected, inputDifference);
            double sumDifference = Calculation.calculateSumDifference(outputDifference, this.sum);
            setInputDifferences(sumDifference);
            for (int i = 0; i < this.inputs.Count; i++)
            {
                double weightCorrection = getWeightCorrection(sumDifference, this.inputs[i]);
                weightsCorrections.Add(weightCorrection);
            }
            this.weightsCorrections = weightsCorrections;
        }
        public double calcualateOutputDifference(double expected = 0, double inputDifference = 0)
        {
            double outputDifference;
            if (this.isOutputNeuron)
            {
                outputDifference = Calculation.calculateCorrection(expected, this.output);
            }
            else
            {
                outputDifference = inputDifference;
            }
            return outputDifference;
        }
        public double getWeightCorrection(double sumDifference, double input)
        {
            double weightCorrection;
            weightCorrection = Calculation.calculateWeightDifference(sumDifference, input);
            return weightCorrection;
        }
    }
   
}
