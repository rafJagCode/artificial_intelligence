using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NeuralNetwork
{
    class Learning
    {
        public List<List<double>> learningSamples = new List<List<double>> {
            new List<double>{0, 0, 0},
            new List<double> { 0, 1, 1 },
            new List<double> { 1, 0, 1 },
            new List<double> { 1, 1, 0 }
        };
        public void addLearningSamples()
        {
            addSamples(this.learningSamples);
        }
        public string checkError(Network network, List<List<double>> samples, double beta)
        {
            string raport = "";
            foreach(var sample in this.learningSamples)
            {
                List<double> inputs = sample.GetRange(0, sample.Count - 1);
                double output = network.calculateOutput(inputs, beta);
                double error = Calculation.calculateError(sample.Last(), output);
                raport += "**********Sample*********\n";
                raport += '\t' + "expected output: " + sample.Last().ToString() + '\n';
                raport += '\t' + "received output: " + output.ToString() + '\n';
                raport += '\t' + "error: " + error.ToString() + '\n';
            }
            return raport;
        }

        List<List<double>> samples = new List<List<double>>();
        Random rnd = new Random();
        public void addSample(List<double> sample)
        {
            var copiedSample = new List<double>(sample);
            this.samples.Add(copiedSample);
        }
        public void addSamples(List<List<double>>samples)
        {
            foreach(var sample in samples)
            {
                addSample(sample);
            }
        }
        public static void shuffle<T>(List<T> list, Random rnd)
        {
            for (var i = list.Count; i > 0; i--)
                swap(list,0, rnd.Next(0, i));
        }

        public static void swap<T>(List<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public void learn(Network network, int epochAmount, BackgroundWorker worker, double beta, double learningFactor)
        {
            double progress = 0;
            for (int i = 0; i < epochAmount; i++)
            {
                epoch(network, beta, learningFactor);
                shuffle(this.samples, this.rnd);
                double progressNow = (double)(i+1) / epochAmount * 100;
                if(progressNow >= progress + 1)
                {
                    progress = progressNow;
                    worker.ReportProgress((int)progress);
                }
            }
            worker.ReportProgress(100);
        }
        public void epoch(Network network, double beta, double learningFactor)
        {
            foreach (var sample in this.samples)
            {
                var inputs = sample.GetRange(0, sample.Count - 1);
                var output = network.calculateOutput(inputs, beta);
                var error = Calculation.calculateCorrection(sample.Last(), output, learningFactor);
                network.propagate(network.getOutputNeuron(),sample.Last(), beta, learningFactor);
                network.applyWeightsCorrections();
            }
        }
    }
}
