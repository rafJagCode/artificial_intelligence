using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    public static class Settings
    {
        public static readonly Random rnd = new Random();
        public const int chromosomAmountPerParameter = 3;
        public const int amountOfParameters = 2;
        public const int iterationAmount = 100;
        public const int populationSize = 1000;
        public const int turnamentSize = 100;
        public const double minParameterValue = 0;
        public const double maxParameterValue = 100;
        public const int mutationRate = 1;
    }
}
