using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class Normalization
    {
        public static void normalizeSamples(SampleColection sampleColection)
        {
            foreach (Sample sample in sampleColection.samples)
            {
                normalizeAttributes(sampleColection, sample.attributes);
            }
        }
        public static double normalizeAttribute(double attribute,double min, double max)
        {
            return (attribute - min) / (max - min);
        }
        public static void normalizeAttributes(SampleColection sampleColection, List<double> attributes)
        {
            Dictionary<int, double> minDict = minAttributes(sampleColection, attributes.Count);
            Dictionary<int, double> maxDict = maxAttributes(sampleColection, attributes.Count);
            for (int i = 0; i < attributes.Count; i++)
            {
                attributes[i] = normalizeAttribute(attributes[i],minDict[i],maxDict[i]);
            }
        }
        public static Dictionary<int, double> minAttributes(SampleColection sampleColection, int numberOfAttr)
        {
            var minAttributes = new Dictionary<int, double>();
            double min;
            for (int i = 0; i < numberOfAttr; i++)
            {
                min = findMinAttr(sampleColection, i);
                minAttributes.Add(i, min);
            }
            return minAttributes;
        }
        public static Dictionary<int, double> maxAttributes(SampleColection sampleColection, int numberOfAttr)
        {
            var maxAttributes = new Dictionary<int, double>();
            double max;
            for (int i = 0; i < numberOfAttr; i++)
            {
                max = findMaxAttr(sampleColection, i);
                maxAttributes.Add(i, max);
            }
            return maxAttributes;
        }
        public static double findMinAttr(SampleColection sampleColection, int attrNumber)
        {
            double min = sampleColection.samples[0].attributes[attrNumber];
            foreach (Sample sample in sampleColection.samples)
            {
                if (sample.attributes[attrNumber] < min) min = sample.attributes[attrNumber];
            }
            return min;
        }
        public static double findMaxAttr(SampleColection sampleColection, int attrNumber)
        {
            double max = sampleColection.samples[0].attributes[attrNumber];
            foreach (Sample sample in sampleColection.samples)
            {
                if (sample.attributes[attrNumber] > max) max = sample.attributes[attrNumber];
            }
            return max;
        }
    }
}
