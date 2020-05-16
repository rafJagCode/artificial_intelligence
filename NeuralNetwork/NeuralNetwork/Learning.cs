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
        List<List<double>> samples = new List<List<double>>();
        Random rnd = new Random();
        public Learning(string[] text)
        {
            addSamples(text);
        }
        List<List<double>> convertTextToList(string[] text)
        {
            var samples = new List<List<double>>();
            foreach(string row in text)
            {
                var sample = convertStringToList(row);
                samples.Add(sample);
            }
            return samples;
        }
        List<double>convertStringToList(string row)
        {
            var sample = new List<double>();
            string[] splitedSample = row.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string value in splitedSample)
            {
                double data = double.Parse(value);
                sample.Add(data);
            }
            return sample;
        }
        public void addSample(List<double> sample)
        {
            var copiedSample = new List<double>(sample);
            this.samples.Add(copiedSample);
        }
        public void addSamples(string[] text)
        {
            var samples = convertTextToList(text);
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
