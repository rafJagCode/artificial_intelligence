using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    public class XorNetwork
    {
        List<XorNeuron> neurons = new List<XorNeuron>();
        public XorNetwork()
        {
            neurons.Add(new XorNeuron(0, 0));
            neurons.Add(new XorNeuron(0, 1));
            neurons.Add(new XorNeuron(1, 0));
        }
        public void setWeights(int neuronNumber, int weightNumber, double value)
        {
            this.neurons[neuronNumber].weights[weightNumber] = value;
        }
        public double calculateOutput(double input1, double input2)
        {
            double[] startingInputs = { 1, input1, input2 };
            double outputFromNeuron1 = this.neurons[0].calculateActivation(startingInputs);
            double outputFromNeuron2 = this.neurons[1].calculateActivation(startingInputs);
            double[] outputsFromFirstLayer = { 1, outputFromNeuron1, outputFromNeuron2 };
            double outputFromNeuron3 = this.neurons[2].calculateActivation(outputsFromFirstLayer);
            return outputFromNeuron3;
        }
    }
}
