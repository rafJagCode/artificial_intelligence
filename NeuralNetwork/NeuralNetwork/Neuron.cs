using System.Collections.Generic;
namespace NeuralNetwork
{
    public class Neuron
    {
        public List<double> inputDifferences;
        public List<double> weightsCorrections;
        public int layerNumber;
        int neuronNumber;
        double hiddenInputValue=1;
        List<double> weights;
        double sum;
        double output;
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
        public KeyValuePair<int[],List<double>> getWeights()
        {
            var weights = new KeyValuePair<int[], List<double>>(new int[] { this.layerNumber, this.neuronNumber }, this.weights );
            return weights;
        }

        public double calculateOutput(List<double>inputs, double beta)
        {
            this.inputs = new List<double>(inputs);
            this.inputs.Insert(0,this.hiddenInputValue);
            this.sum = Calculation.calcualateSum(this.inputs, this.weights);
            this.output= Calculation.calcualateActivation(sum, beta);
            return this.output;

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
        public void setWeightsCorrections(double expected, double beta, double learningFactor, double inputDifference = 0)
        {
            var weightsCorrections = new List<double>();
            double outputDifference = calcualateOutputDifference(expected, learningFactor, inputDifference);
            double sumDifference = Calculation.calculateSumDifference(outputDifference, this.sum, beta);
            setInputDifferences(sumDifference);
            for (int i = 0; i < this.inputs.Count; i++)
            {
                double weightCorrection = getWeightCorrection(sumDifference, this.inputs[i]);
                weightsCorrections.Add(weightCorrection);
            }
            this.weightsCorrections = weightsCorrections;
        }
        public double calcualateOutputDifference(double expected, double learningFactor, double inputDifference = 0)
        {
            double outputDifference;
            if (this.isOutputNeuron)
            {
                outputDifference = Calculation.calculateCorrection(expected, this.output, learningFactor);
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
        public void applyWeightsCorrection()
        {
            for (int i = 0; i < this.weights.Count; i++)
            {
                this.weights[i] += this.weightsCorrections[i];
            }
        }
    }
   
}
