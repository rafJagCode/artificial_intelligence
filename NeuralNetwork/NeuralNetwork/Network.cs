using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Network
    {
        int lastLayerNumber;
        public Layer[] layers;
        public Network(Configuration networkConfiguration)
        {
            this.lastLayerNumber = networkConfiguration.amountOfLayers - 1;
            addLayers(networkConfiguration.neuronConfiguration);
        }
        public void addLayers(Dictionary<int,int>networkConfiguration)
        {
            this.layers = new Layer[networkConfiguration.Count];
            foreach(var layerInfo in networkConfiguration)
            {
                Layer newLayer = new Layer(layerInfo, this.lastLayerNumber);
                this.layers[layerInfo.Key] = newLayer;
            }
        }
        public void setWeights(Dictionary<int[],List<double>>weights)
        {
            foreach(var neuronWeights in weights)
            {
                layers[neuronWeights.Key[0]].setWeights(neuronWeights.Key[1], neuronWeights.Value);
            }
        }
        public Dictionary<int[], List<double>> getWeights()
        {
            var weights = new Dictionary<int[], List<double>>();
            foreach(Layer layer in this.layers)
            {
                foreach(var neuronWeights in layer.getWeights())
                {
                    weights.Add(neuronWeights.Key, neuronWeights.Value);
                }
            }
            return weights;
        }
        public double calculateOutput(List<double> inputs,double beta)
        {
            List<double> output = new List<double> ();

            foreach(Layer layer in this.layers)
            {
                if (layer == layers.First()) output = layer.calcualteOutput(inputs,beta);
                else output = layer.calcualteOutput(output,beta);
            }
            return output.First();
        }
        public Neuron getNeuron(int layerNumber, int neuronNumber)
        {
            return this.layers[layerNumber].neurons[neuronNumber];
        }
        public Neuron getOutputNeuron()
        {
            Neuron outputNeuron = this.layers.Last().neurons[0];
            return outputNeuron;
        }
        public void propagate(Neuron neuron, double expected, double beta, double learningFactor, double inputDifference = 0)
        {
            neuron.setWeightsCorrections(expected, beta, learningFactor, inputDifference);
            if (neuron.layerNumber == 0) return;
            for (int i = 0; i < neuron.inputs.Count-1; i++)
            {
                this.propagate(this.getNeuron(neuron.layerNumber - 1, i), expected,beta, learningFactor, neuron.inputDifferences[i]);
            }
        }
        public void applyWeightsCorrections()
        {
            foreach(Layer layer in this.layers)
            {
                layer.applyWeightsCorrections();
            }
        }
    }
}
