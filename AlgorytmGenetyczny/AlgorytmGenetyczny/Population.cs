using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    class Population
    {
        List<Individual> population;
        public void addIndividual(Individual individual)
        {
            population.Add(individual);
        }
        public void generateRandomPopulation(Random rnd, Settings settings)
        {
            for (int i = 0; i < settings.populationSize; i++)
            {
                Individual individual = Individual.getRandomIndividual(rnd, settings);
                this.population.Add(individual);
            }
        }
    }
}
