using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class WeightsHandler
    {
        public static void saveWeights(Dictionary<int[], List<double>>weights, string path)
        {
            TextWriter tw = new StreamWriter(path);
            string line;
            foreach (var item in weights)
            {
                line = "";
                line += convertItemToString(item);
                tw.WriteLine(line);
            }
            tw.Close();
        }
        public static string convertItemToString(KeyValuePair<int[], List<double>> item)
        {
            string result = "";
            result += item.Key[0].ToString() + '\t';
            result += item.Key[1].ToString() + '\t';
            foreach(double weight in item.Value)
            {
                result += weight.ToString() + '\t';
            }
            return result;
        }
        public static Dictionary<int[], List<double>> loadWeights(string path)
        {
            var result = new Dictionary<int[], List<double>>();
            var content = File.ReadAllLines(path);
            foreach ( string line in content)
            {
                var item = convertStringToItem(line);
                result.Add(item.Key, item.Value);
            }
            return result;
        }
        public static KeyValuePair<int[], List<double>> convertStringToItem(string line)
        {
            KeyValuePair<int[], List<double>> result;
            var weights = new List<double>();
            var data = line.Trim().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var key = new int[] { int.Parse(data[0]), int.Parse(data[1]) };
            for (int i = 2; i < data.Length; i++)
            {
                weights.Add(double.Parse(data[i]));
            }
            result = new KeyValuePair<int[], List<double>>(key, weights);
            return result;
        }
    }
}
