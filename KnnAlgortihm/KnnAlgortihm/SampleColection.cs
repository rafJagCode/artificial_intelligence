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
        public SampleColection(List<List<double>>data)
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
    }
}
