using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Inputs
    {
        List<Input> inputs;
        public void setInputs(List<double> data)
        {
            int i = 0;
            foreach(double value in data)
            {
                Input newInput = new Input(i++, value);
            }
        }
    }
}
