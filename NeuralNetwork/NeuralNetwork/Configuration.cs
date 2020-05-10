using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{   
    class Configuration
    {
        int amountOfInputs;
        public int amountOfLayers;
        public Dictionary<int, int> neuronConfiguration= new Dictionary<int, int>();
        public Configuration(List<int> data)
        {
            loadConfiguration(data);
        }
        public void loadConfiguration(List<int>data)
        {
            this.amountOfLayers = data.Count-1;
            this.amountOfInputs = data.First();
            for (int i = 1; i < data.Count; i++)
            {
                this.neuronConfiguration.Add(i-1,data[i]);
            }
        }
    }
}
