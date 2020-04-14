using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleClassificator
{
    class KnnAlgorithm
    {
        Dictionary<int, List<double>> countDistances(Sample sampleToCheck, SampleColection data)
        {
            var distances = new Dictionary<int, List<double>>();
            double distance;
            foreach (Sample sample in data.samples)
            {
                distance = Metrics.euklideanMetric(sampleToCheck.attributes, sample.attributes);
                if (!distances.ContainsKey(sample.decision))
                    distances.Add(sample.decision, new List<double> { distance });
                else
                    distances[sample.decision].Add(distance);
            }
            return distances;
        }
        Dictionary<int, double> countSumOfKminDistances(Sample sampleToCheck, SampleColection data, int k)
        {
            Dictionary<int, List<double>> distances = countDistances(sampleToCheck, data);
            double sumOfKminDistances = 0;
            var minDistances = new Dictionary<int, double>();
            foreach (var item in distances)
            {
                item.Value.Sort();
                for (int i = 0; i < k; i++)
                {
                    sumOfKminDistances += item.Value[i];
                }
                minDistances.Add(item.Key, sumOfKminDistances);
            }
            return minDistances;
        }
        public bool isOnlyOneMin(Dictionary<int, double> minDistances, double min)
        {
            int count = 0;
            foreach (var item in minDistances)
                if (item.Value == min) count++;
            if (count > 1) return false;
            return true;
        }
        public int? chooseDecision(Sample sampleToCheck, SampleColection data, int k)
        {
            Dictionary<int, double> minDistances = countSumOfKminDistances(sampleToCheck, data, k);
            double min = minDistances.First().Value;
            int decision = minDistances.First().Key;
            for (int i = 1; i < minDistances.Count; i++)
            {
                decision = minDistances.Keys.ElementAt(i);
                if (minDistances[decision] < min) min = minDistances[decision];

            }
            if (isOnlyOneMin(minDistances, min)) return decision;
            return null;
        }
    }
}
