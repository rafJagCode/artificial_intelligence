using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class Algorithm
    {
        
        static Dictionary<int, List<double>> countDistances(List<double> sampleToCheck, SampleColection data, Metrics.metric choosedMetric,int p)
        {
            var distances = new Dictionary<int, List<double>>();
            double distance;
            foreach (Sample sample in data.samples)
            {
                distance = choosedMetric(sampleToCheck, sample.attributes,p);
                if (!distances.ContainsKey(sample.decision))
                    distances.Add(sample.decision, new List<double> { distance });
                else
                    distances[sample.decision].Add(distance);
            }
            return distances;
        }
        static Dictionary<int, double> countSumOfKminDistances(List<double> sampleToCheck, SampleColection data, int k,Metrics.metric choosedMetric,int p)
        {
            var distances = new Dictionary<int, List<double>>();
            distances = countDistances(sampleToCheck, data,choosedMetric,p);
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
                sumOfKminDistances = 0;
            }
            return minDistances;
        }
        static bool isOnlyOneMin(Dictionary<int, double> minDistances, double min)
        {
            int count = 0;
            foreach (var item in minDistances)
                if (item.Value == min) count++;
            if (count > 1) return false;
            return true;
        }
        public static int? chooseDecision(List<double> attributesToCheck, SampleColection sampleColection, int k,Metrics.metric choosedMetric,int p)
        {
            var normalizedAttributes = Normalization.normalizeAttributes(sampleColection, attributesToCheck);
            var normalizedSampleColection = Normalization.normalizeSampleColection(sampleColection);
            var minDistances = new Dictionary<int, double>();
            minDistances = countSumOfKminDistances(normalizedAttributes, normalizedSampleColection, k,choosedMetric,p);
            double min = minDistances.First().Value;
            int decision = minDistances.First().Key;
            foreach(var item in minDistances)
            {
                if (item.Value < min)
                {
                    min = item.Value;
                    decision = item.Key;
                }
            }
            if (isOnlyOneMin(minDistances, min)) return decision;
            return null;
        }
    }
}
