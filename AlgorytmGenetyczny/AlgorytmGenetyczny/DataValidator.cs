using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    class DataValidator
    {
        public static bool areInputsOk(string iterationAmount, string populationSize, string turnamentSize, string mutationRate, string chromosomeAmount, out string message)
        {
            string error;
            if(!isIterationAmountOk(iterationAmount, out error)){
                message = error;
                return false;
            }
            if (!isPopulationSizeOk(populationSize, out error))
            {
                message = error;
                return false;
            }
            int populationSizeValue = int.Parse(populationSize);
            if(!isTurnamentSizeOk(turnamentSize, populationSizeValue, out error))
            {
                message = error;
                return false;
            }
            int turnamentSizeValue = int.Parse(turnamentSize);
            if(!isMutationRateOk(mutationRate, populationSizeValue, out error))
            {
                message = error;
                return false;
            }
            if(!isChromosomeAmountOk(chromosomeAmount, out error))
            {
                message = error;
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isInt(string text)
        {
            int result;
            bool canBeParsed = int.TryParse(text, out result);
            return canBeParsed;
        }
        public static bool isDouble(string text)
        {
            double result;
            bool canBeParsed = double.TryParse(text, out result);
            return canBeParsed;
        }
        public static bool isIterationAmountOk(string text, out string message)
        {
            if (!isInt(text))
            {
                message = "Ilość iteracji musi być lilczbą naturalną";
                return false;
            }
            int iterationAmountValue = int.Parse(text);
            if(iterationAmountValue < 20)
            {
                message = "Ilość iiteracji powinna być równa co najmniej 20";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isPopulationSizeOk(string text, out string message)
        {
            if (!isInt(text))
            {
                message = "Rozmiar populajci musi być lilczbą naturalną";
                return false;
            }
            int populationSizeValue = int.Parse(text);
            if (populationSizeValue % 2 == 0)
            {
                message = "Wielkość populacji powinna być liczbą nieparzystą";
                return false;
            }
            if (populationSizeValue < 9)
            {
                message = "Wielkość populacji powinna wynosić co najmniej 9";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isTurnamentSizeOk(string text, int populationSize, out string message)
        {
            if (!isInt(text))
            {
                message = "Rozmiar turnieju musi być lilczbą naturalną";
                return false;
            }
            int turnamentSize = int.Parse(text);
            if (!((turnamentSize>=2) && (turnamentSize <= 0.25*populationSize)))
            {
                message = "Rozmiar turnieju musi wynosić co najmniej 2 i co najwyżej 25% rozmiaru populacji";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isMutationRateOk(string text, int populationSize, out string message)
        {
            if (!isInt(text))
            {
                message = "Współczynnik mutacji musi być lilczbą naturalną";
                return false;
            }
            int mutationRate = int.Parse(text);
            if(mutationRate > populationSize-1)
            {
                message = "Współczynnk mutacji maksymalnie może być równy wielkości populacji minus jeden";
                return false;
            }
            message = "OK";
            return true;
        }
        public static bool isChromosomeAmountOk(string text, out string message)
        {
            if (!isInt(text))
            {
                message = "Ilość chromosomów musi być lilczbą naturalną";
                return false;
            }
            int chromosomeAmount = int.Parse(text);
            if (chromosomeAmount < 3)
            {
                message = "Ilość chromosomów powinna wynosić co najmniej 3";
                return false;
            }
            message = "OK";
            return true;
        }
    }
}
