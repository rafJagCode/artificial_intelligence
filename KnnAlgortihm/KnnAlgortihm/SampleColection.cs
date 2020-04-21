using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class SampleColection
    {
        public List<Sample> samples = new List<Sample>();
        public SampleColection(List<List<double>> data)
        {
            addSamples(data);
        }
        public void removeSample(Sample sample)
        {
            this.samples.Remove(sample);
        }
        public void addSample(Sample sample)
        {
            this.samples.Add(sample);
        }
        public void addSamples(List<List<double>> data)
        {
            Sample sample;
            foreach (List<double> row in data)
            {
                sample = Sample.makeSample(row);
                addSample(sample);
            }
        }
        public HashSet<int> possibleDecisions()
        {
            var decisions = new HashSet<int>();
            foreach (Sample sample in samples)
            {
                decisions.Add(sample.decision);
            }
            return decisions;
        }
        public int countSamples()
        {
            int counter=0;
            foreach (Sample sample in samples) counter++;
            return counter;
        }
        public Dictionary<int, List<Sample>> segregateSamplesByDecision()
        {
            var samplesSegregated = new Dictionary<int, List<Sample>>();
            foreach (Sample sample in samples)
            {
                if (!samplesSegregated.ContainsKey(sample.decision))
                    samplesSegregated.Add(sample.decision, new List<Sample> { sample });
                else
                    samplesSegregated[sample.decision].Add(sample);
            }
            return samplesSegregated;
        }
        public SampleColection copy()
        {
            SampleColection newSampleColection = new SampleColection(new Data(new string[] { }).dataFromFile);
            foreach(Sample sample in samples)
            {
                newSampleColection.addSample(sample.copy());
            }
            return newSampleColection;
        }
    }
}
