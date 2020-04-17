using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class Sample
    {
        public List<double> attributes;
        public int decision;
        public Sample(List<double> attributes, int decision)
        {
            this.attributes = attributes;
            this.decision = decision;
        }
        public static Sample makeSample(List<double> row)
        {
            List<double> attributes = new List<double>();
            int decision;
            for (int i = 0; i < row.Count - 1; i++)
            {
                attributes.Add(row[i]);
            }
            decision = (int)row[row.Count - 1];
            Sample sample = new Sample(attributes, decision);
            return sample;
        }
    }
}
