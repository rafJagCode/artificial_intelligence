using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Input
    {
        (int layerNumber, int inputNumber) id;
        double value;
        public Input(int inputNumber, double value)
        {
            this.id = (0, inputNumber);
            this.value = value;
        }
    }
}
