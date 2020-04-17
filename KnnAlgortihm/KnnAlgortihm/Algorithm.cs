using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class Algorithm
    {
        public delegate double metric(List<double> attrToCheck, List<double> attrToCompare);
        static Dictionary<int, List<double>> countDistances(List<double> sampleToCheck, SampleColection data, metric choosedMetric)
        {
            var distances = new Dictionary<int, List<double>>();
            double distance;
            foreach (Sample sample in data.samples)
            {
                distance = choosedMetric(sampleToCheck, sample.attributes);
                if (!distances.ContainsKey(sample.decision))
                    distances.Add(sample.decision, new List<double> { distance });
                else
                    distances[sample.decision].Add(distance);
            }
            return distances;
        }
        static Dictionary<int, double> countSumOfKminDistances(List<double> sampleToCheck, SampleColection data, int k,metric choosedMetric)
        {
            Dictionary<int, List<double>> distances = countDistances(sampleToCheck, data,choosedMetric);
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
        public static int? chooseDecision(List<double> sampleToCheck, SampleColection data, int k,metric choosedMetric)
        {
            Dictionary<int, double> minDistances = countSumOfKminDistances(sampleToCheck, data, k,choosedMetric);
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
        public static double precision(SampleColection sampleColection,int k, metric choosedMetric)
        {
            int probes = 0;
            int correct = 0;
            Normalization.normalizeSamples(sampleColection);
            foreach(Sample sample in sampleColection.samples)
            {
                probes++;
                sampleColection.removeSample(sample);
                int? result=chooseDecision(sample.attributes, sampleColection, k, choosedMetric);
                if (result == sample.decision) correct++;
                sampleColection.addSample(sample);
            }
            return (double)correct / probes * 100;
        }
        
    }
}
