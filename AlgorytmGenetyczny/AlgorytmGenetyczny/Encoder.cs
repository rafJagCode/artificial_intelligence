using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    class Encoder
    {
        public static List<int>encode(double value, double min, double max, int chromosomAmount)
        {
            List<int> result = new List<int>(); 
            double resultDec = Math.Round((value - min) / (max - min) * (Math.Pow(2, chromosomAmount) - 1));
            for (int i = chromosomAmount-1; i >=0; i--)
            {
                int bit = (int)Math.Floor(resultDec / Math.Pow(2, i)) % 2;
                result.Add(bit);
            }
            return result;
        }
        public static double decode(List<int>value, double min, double max)
        {
            double valueDec=0;
            double result;
            for (int i = 0, j = value.Count-1; i<value.Count; i++, j--)
            {
                valueDec += value[i] * Math.Pow(2, j);
            }
            result = min + valueDec / (Math.Pow(2, value.Count)-1) * (max - min);
            return result;
        }
    }
}
