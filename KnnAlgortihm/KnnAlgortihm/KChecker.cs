using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class KChecker
    {
        public static int maxK(SampleColection sampleColection)
        {
            var segregatedSamples = sampleColection.segregateSamplesByDecision();
            int minAmount = segregatedSamples.First().Value.Count;
            foreach (var item in segregatedSamples)
            {
                if (item.Value.Count < minAmount) minAmount = item.Value.Count;
            }
            return minAmount;
        }
    }
}
