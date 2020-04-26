using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Neuron
    {
        int layerNumber;
        [JsonProperty] int neuronNumber;
        [JsonProperty] double hiddenInputValue=1;
        [JsonProperty] List<double> weights;
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
            var addedHiddenInput = getInputsWithAddedHiddenValue(inputs);
            double sum = Calculation.calcualateSum(addedHiddenInput, this.weights);
            return Calculation.calcualateActivation(sum);

        }
        public string getNeuronAsJson()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented);
        }
    }
}
