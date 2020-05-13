using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace NeuralNetwork.Unit.Tests
{
    [TestClass]
    public class NeuralNetworTests
    {
        [TestMethod]
        public void Propagate_ExampleFromClasses_ReturnsPreciselyDefinedWeights()
        {
            //Arrange
            var configuration = new Configuration(new List<int> { 2, 2, 1 });
            var network = new Network(configuration);
            var weights = new Dictionary<int[], List<double>>
            {
                { new int[]{0,0}, new List<double>{0.3,0.1,0.2} },
                { new int[]{0,1}, new List<double>{0.6,0.4,0.5} },
                { new int[]{1,0}, new List<double>{0.9,0.7,-0.8} }
            };
            var inputs = new List<double> { 1, 0 };
            double beta = 1;
            var expected = 1;
            var learningFactor = 0.1;
            //Act
            network.setWeights(weights);
            var output = network.calculateOutput(inputs,beta);
            network.propagate(network.getOutputNeuron(), expected, beta, learningFactor);
            network.applyWeightsCorrections();
            var newWeights = network.getWeights();
            //Assert
            double expectedOutput = 0.67573381557191681;
            var expectedWeights = new Dictionary<int[], List<double>>
            {
                { new int[]{0,0}, new List<double>
                    {
                        0.30119497779737187,
                        0.1011949777973719,
                        0.2
                    }
                },
                { new int[]{0,1}, new List<double>
                    {
                        0.59888241944715137,
                        0.39888241944715142,
                        0.5
                    }
                },
                { new int[]{1,0}, new List<double>
                    {
                        0.90710524365448864,
                        0.70425382169803463,
                        -0.79480565067312969
                    }
                },
            };
            Assert.AreEqual(expectedOutput, output);
            Assert.IsTrue(isDictEqual(expectedWeights, newWeights));

        }
        public bool isListEqual(List<double>expectedList, List<double> receivedList)
        {
            if (expectedList.Count != receivedList.Count) return false;
            for (int i = 0; i < expectedList.Count; i++)
            {
                if (Math.Abs(expectedList[i]-receivedList[i])!=0) return false;
            }
            return true;
        }
        public bool isDictEqual(Dictionary<int[], List<double>> expected, Dictionary<int[], List<double>>received)
        {
            if (expected.Count != received.Count) return false;
            for (int i = 0; i < expected.Count; i++)
            {
                if (!isListEqual(expected.ElementAt(i).Value, received.ElementAt(i).Value)) return false;
            }
            return true;
        }
    }
}
