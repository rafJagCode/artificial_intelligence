using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class TestingObjects
    {
        public List<double> inputs = new List<double> { 1, 0 };
        public Configuration configuration = new Configuration(new List<int> { 2, 2, 1 });
        public Dictionary<int[], List<double>> weights = new Dictionary<int[], List<double>>();
        public TestingObjects()
        {
            weights.Add(new int[] { 0, 0 }, new List<double> { 0.3, 0.1, 0.2 });
            weights.Add(new int[] { 0, 1 }, new List<double> { 0.6, 0.4, 0.5 });
            weights.Add(new int[] { 1, 0 }, new List<double> { 0.9, 0.7, -0.8 });
        }
    }
}
