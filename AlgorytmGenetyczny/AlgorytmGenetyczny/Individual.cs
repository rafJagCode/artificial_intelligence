using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    class Individual
    {
        List<List<int>> DNA;
        double adaptationFunctionResult;
        public void addGene(List<int> gene)
        {
            this.DNA.Add(gene);
        }
        public static Individual getRandomIndividual(Random rnd, Settings settings)
        {
            Individual individual = new Individual();
            for (int i = 0; i < settings.amountOfParameters; i++)
            {
                var gene = Tools.getRandomGene(rnd, settings.chromosomAmountPerParameter);
                individual.addGene(gene);
            }
            return individual;
        }
        public void calculateAdaptation(Settings settings)
        {
            double x1 = Encoder.decode(this.DNA[0], settings.minParameterValue, settings.maxParameterValue);
            double x2 = Encoder.decode(this.DNA[1], settings.minParameterValue, settings.maxParameterValue);
            this.adaptationFunctionResult = Tools.adaptationFunction(x1, x2);
        }
        public void changeChromosome(Random rnd, Settings settings)
        {
            int number = rnd.Next(0, settings.amountOfParameters * settings.chromosomAmountPerParameter);
            int geneNumber = number / settings.chromosomAmountPerParameter;
            int chromosomeNumber = number % settings.chromosomAmountPerParameter;
            this.DNA[geneNumber][chromosomeNumber] = this.DNA[geneNumber][chromosomeNumber] == 1 ? 0 : 1;
        }
    }
}
