using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmGenetyczny.Settings;

namespace AlgorytmGenetyczny
{
    class Population
    {
        List<Individual> population = new List<Individual>();
        public void addIndividual(Individual individual)
        {
            population.Add(individual);
        }
        public void generateRandomPopulation()
        {
            this.population.Clear();
            for (int i = 0; i < populationSize; i++)
            {
                Individual individual = Individual.getRandomIndividual();
                this.population.Add(individual);
            }
        }
        public Individual turnamentSelection(int turnamentSize)
        {
            Individual selected;
            List<Individual> competitors = new List<Individual>();
            int[] selectedIndexes = Tools.getRandomIndexes(turnamentSize, this.population.Count);
            for (int i = 0; i < selectedIndexes.Length; i++)
            {
                if (selectedIndexes[i] == 1)
                {
                    competitors.Add(this.population[i]);
                }
            }
            selected = competitors.First();
            foreach(Individual competitor in competitors)
            {
                competitor.calculateAdaptation();
                if (competitor.adaptationFunctionResult < selected.adaptationFunctionResult) selected = competitor;
            }
            return selected;
        }
        public Population selectNewPopulationUsingTurnament(int newPopulationSize)
        {
            Population selected = new Population();
            for (int i = 0; i < newPopulationSize; i++)
            {
                var selectedIndividual = turnamentSelection(turnamentSize);
                selected.addIndividual(selectedIndividual.copy());
            }
            return selected;
        }
        public string print()
        {
            string population = "";
            for (int i = 0; i < this.population.Count; i++)
            {
                population += "Individual " + i + " => ";
                population += this.population[i].print()+'\n';
            }
            return population;
        }
        public void calculateAdaptation()
        {
            foreach(Individual individual in this.population)
            {
                individual.calculateAdaptation();
            }
        }
        public void mutateOneChromosome()
        {
            int[] selectedToMutate = Tools.getRandomIndexes(mutationRate, this.population.Count);
            for (int i = 0; i < this.population.Count; i++)
            {
                if (selectedToMutate[i] == 1) this.population[i].changeChromosome();
            }
        }
        public Individual hotDeck()
        {
            Individual selected = this.population.First().copy();
            foreach(Individual individual in this.population)
            {
                if (individual.adaptationFunctionResult < selected.adaptationFunctionResult) selected = individual;
            }
            return selected;
        }
        public double calcualteAvg()
        {
            double sum=0;
            foreach(Individual individual in this.population)
            {
                sum += individual.adaptationFunctionResult;
            }
            return sum / populationSize;
        }
    }
}
