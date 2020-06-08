using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    class Settings
    {
        public int chromosomAmountPerParameter = 3;
        public int amountOfParameters = 2;
        public int iterationAmount = 20;
        public int populationSize = 9;
        public int turnamentSize = 2;
        public double minParameterValue = 0;
        public double maxParameterValue = 100;
    }
}
