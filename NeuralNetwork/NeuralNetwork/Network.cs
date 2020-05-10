using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Network
    {
        [JsonProperty] public Layer[] layers;
        public Network(Dictionary<int, int> networkConfiguration)
        {
            addLayers(networkConfiguration);
        }
        public void addLayers(Dictionary<int,int>networkConfiguration)
        {
            this.layers = new Layer[networkConfiguration.Count];
            foreach(var layerInfo in networkConfiguration)
            {
                Layer newLayer = new Layer(layerInfo);
                this.layers[layerInfo.Key] = newLayer;
            }
        }
        public string getNetworkAsJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        public void setWeights(Dictionary<int[],List<double>>weights)
        {
            foreach(var neuronWeights in weights)
            {
                layers[neuronWeights.Key[0]].setWeights(neuronWeights.Key[1], neuronWeights.Value);
            }
        }
        public double calculateOutput(List<double> inputs)
        {
            List<double> output = new List<double> ();

            foreach(Layer layer in this.layers)
            {
                if (layer == layers.First()) output = layer.calcualteOutput(inputs);
                else output = layer.calcualteOutput(output);
            }
            return output.First();
        }
        public Neuron getNeuron(int layerNumber, int neuronNumber)
        {
            return this.layers[layerNumber].neurons[neuronNumber];
        }
    }
}
