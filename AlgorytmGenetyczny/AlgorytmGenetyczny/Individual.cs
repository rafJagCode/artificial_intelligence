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
            double x1 = Encoder.decode(this.DNA[0], minParameterValue, maxParameterValue);
            double x2 = Encoder.decode(this.DNA[1], minParameterValue, maxParameterValue);
            this.adaptationFunctionResult = Tools.adaptationFunction(x1, x2);
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
                individual += ", ";
            }
            individual += ", RESULT: " + Math.Round(this.adaptationFunctionResult,3);
            return individual;
        }
    }
}
