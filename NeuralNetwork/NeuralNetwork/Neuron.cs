using Newtonsoft.Json;
using System.Collections.Generic;
namespace NeuralNetwork
{
    class Neuron
    {
        int layerNumber;
        [JsonProperty] int neuronNumber;
        [JsonProperty] double hiddenInputValue=1;
        [JsonProperty] List<double> weights;
        [JsonProperty] double sum;
        [JsonProperty] double output;
        List<double> inputs;
        public Neuron(int layerNumber, int neuronNumber)
        {
            this.layerNumber = layerNumber;
            this.neuronNumber = neuronNumber;
        }
        public void setWeights(List<double>weights)
        {
            this.weights = new List<double>(weights);
        }
        public void setHiddenInputValue(double value)
        {
            this.hiddenInputValue = value;
        }
        public List<double> getInputsWithAddedHiddenValue(List<double> inputs)
        {
            List<double> addedHiddenInput = new List<double> { this.hiddenInputValue };
            addedHiddenInput.AddRange(inputs);
            return addedHiddenInput;
        }
        public double calculateOutput(List<double>inputs)
        {
            this.inputs = new List<double>(inputs);
            var addedHiddenInput = getInputsWithAddedHiddenValue(inputs);
            this.sum = Calculation.calcualateSum(addedHiddenInput, this.weights);
            this.output= Calculation.calcualateActivation(sum);
            return this.output;

        }
        public string getNeuronAsJson()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented);
        }


    }
   
}
