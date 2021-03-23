using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmGenetyczny.Settings;

namespace AlgorytmGenetyczny
{
    class Individual
    {
        List<List<int>> DNA = new List<List<int>>();
        public double adaptationFunctionResult;
        public void addGene(List<int> gene)
        {
            this.DNA.Add(gene);
        }
        public Individual copy()
        {
            Individual clone = new Individual();
            foreach(var gene in this.DNA)
            {
                var cloneGene = new List<int>();
                foreach(int chromosome in gene)
                {
                    cloneGene.Add(chromosome);
                }
                clone.addGene(cloneGene);
            }
            clone.adaptationFunctionResult = this.adaptationFunctionResult;
            return clone;
        }
        public static Individual getRandomIndividual()
        {
            Individual individual = new Individual();
            for (int i = 0; i < amountOfParameters; i++)
            {
                var gene = Tools.getRandomGene(chromosomAmountPerParameter);
                individual.addGene(gene);
            }
            return individual;
        }
        public void calculateAdaptation()
        {
            var expectedReceivedList = new List<double[]>();
            for (int i = 0; i < this.DNA.Count; i++)
            {
                network.setWeights(i / 3, i % 3, Encoder.decode(DNA[i], minParameterValue, maxParameterValue));
            }
            double resultSample1 = network.calculateOutput(xorSample1[0], xorSample1[1]);
            double resultSample2 = network.calculateOutput(xorSample2[0], xorSample2[1]);
            double resultSample3 = network.calculateOutput(xorSample3[0], xorSample3[1]);
            double resultSample4 = network.calculateOutput(xorSample4[0], xorSample4[1]);
            expectedReceivedList.Add(new double []{ xorSample1[2], resultSample1});
            expectedReceivedList.Add(new double[] { xorSample2[2], resultSample2 });
            expectedReceivedList.Add(new double[] { xorSample3[2], resultSample3 });
            expectedReceivedList.Add(new double[] { xorSample4[2], resultSample4 });
            this.adaptationFunctionResult = Tools.adaptationFunction(expectedReceivedList);
        }
        public void changeChromosome()
        {
            int number = rnd.Next(0, amountOfParameters * chromosomAmountPerParameter);
            int geneNumber = number / chromosomAmountPerParameter;
            int chromosomeNumber = number % chromosomAmountPerParameter;
            this.DNA[geneNumber][chromosomeNumber] = this.DNA[geneNumber][chromosomeNumber] == 1 ? 0 : 1;
        }
        public string print()
        {
            string individual = "";
            for (int i = 0; i < DNA.Count; i++)
            {
                individual += "GENE " + i +": ";
                for (int j = 0; j < DNA[i].Count; j++)
                {
                    individual += DNA[i][j];
                }
                individual += " "+ Math.Round(Encoder.decode(DNA[i], minParameterValue, maxParameterValue),2)+", ";
            }
            individual += ", RESULT: " + Math.Round(this.adaptationFunctionResult,3);
            return individual;
        }
    }
}
