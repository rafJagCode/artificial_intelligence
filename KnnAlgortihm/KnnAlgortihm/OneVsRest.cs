using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class OneVsRest
    {
        public static double precision(SampleColection sampleColection, int k, Metrics.metric choosedMetric,int p)
        {
            SampleColection newSampleColection = sampleColection.copy();
            int probes = 0;
            int correct = 0;
            var samples = newSampleColection.samples;
            Sample tmp;
            for (int i=0; i<samples.Count; i++)
            {
                probes++;
                tmp = newSampleColection.samples.First();
                newSampleColection.removeSample(tmp);
                int? result = Algorithm.chooseDecision(tmp.attributes, newSampleColection, k, choosedMetric,p);
                if (result == tmp.decision) correct++;
                newSampleColection.addSample(tmp);
            }
            return (double)correct / probes * 100;
        }
    }
}
