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
        public static int chromosomAmountPerParameter = 3;
        public static int amountOfParameters = 9;
        public static int iterationAmount = 1000;
        public static int populationSize = 100;
        public static int turnamentSize = 30;
        public static double minParameterValue = -10;
        public static double maxParameterValue = 10;
        public static int mutationRate = 5;
        public static XorNetwork network = new XorNetwork();
        public static double[] xorSample1 = { 0, 0, 0 };
        public static double[] xorSample2 = { 0, 1, 1 };
        public static double[] xorSample3 = { 1, 0, 1 };
        public static double[] xorSample4 = { 1, 1, 0 };
    }
}
