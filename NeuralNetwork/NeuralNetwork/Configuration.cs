using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{   
    public class Configuration
    {
        public int amountOfInputs;
        public int amountOfLayers;
        public List<int> networkStructure;
        public Dictionary<int, int> neuronConfiguration= new Dictionary<int, int>();
        public Configuration(string configurationString)
        {
            var configurationList = convertStringToList(configurationString);
            loadConfiguration(configurationList);
        }
        List<int> convertStringToList(string configurationString)
        {
            var configuration = new List<int>();
            string[] configurationArray = configurationString.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string configurationData in configurationArray)
            {
                configuration.Add(int.Parse(configurationData));
            }
            this.networkStructure = configuration;
            return configuration;
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
