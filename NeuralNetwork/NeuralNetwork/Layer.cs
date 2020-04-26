using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Layer
    {
        int amountOfNeurons;
        [JsonProperty] int layerNumber;
        [JsonProperty] public Neuron[] neurons;
        public Layer(KeyValuePair<int, int> layerInfo)
        {
            this.layerNumber = layerInfo.Key;
            this.amountOfNeurons = layerInfo.Value;
            addNeuronsToLayer(this.layerNumber, this.amountOfNeurons);
        }
        public void addNeuronsToLayer(int layerNumber, int amountOfNeurons)
        {
            this.neurons = new Neuron[amountOfNeurons];
            for (int i = 0; i < amountOfNeurons; i++)
            {
                neurons[i] = new Neuron(layerNumber, i);
            }
        }
        public void setWeights(int neuronNumber, List<double> weights)
        {
            neurons[neuronNumber].setWeights(weights);
        }
        public List<double> calcualteOutput(List<double>inputs)
        {
            List<double> outputsFromLayer = new List<double>();
            foreach(Neuron neuron in this.neurons)
            {
                double neuronOutput = neuron.calculateOutput(inputs);
                outputsFromLayer.Add(neuronOutput);
            }
            return outputsFromLayer;
        }
    }
}
