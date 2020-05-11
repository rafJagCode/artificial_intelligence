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
        public Layer(KeyValuePair<int, int> layerInfo, int lastLayerNumber)
        { 
            this.layerNumber = layerInfo.Key;
            bool isLastLayer = this.layerNumber == lastLayerNumber ? true : false;
            this.amountOfNeurons = layerInfo.Value;
            addNeuronsToLayer(this.layerNumber, this.amountOfNeurons, isLastLayer);
        }
        public void addNeuronsToLayer(int layerNumber, int amountOfNeurons, bool isLastLayer)
        {
            this.neurons = new Neuron[amountOfNeurons];
            for (int i = 0; i < amountOfNeurons; i++)
            {
                neurons[i] = new Neuron(layerNumber, i, isLastLayer);
            }
        }
        public void setWeights(int neuronNumber, List<double> weights)
        {
            neurons[neuronNumber].setWeights(weights);
        }
        public List<KeyValuePair<int[], List<double>>> getWeights()
        {
            var weights = new List<KeyValuePair<int[], List<double>>>();
            foreach (Neuron neuron in this.neurons)
            {
                weights.Add(neuron.getWeights());
            }
            return weights;
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
        public void applyWeightsCorrections()
        {
            foreach(Neuron neuron in this.neurons)
            {
                neuron.applyWeightsCorrection();
            }
        }
    }
}
