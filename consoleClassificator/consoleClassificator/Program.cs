using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleClassificator
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleColection sampleColection = new SampleColection();
            sampleColection.addSamples();
            sampleColection.normalizeSamples();
            foreach(double att in sampleColection.samples[0].attributes)
            {
                Console.WriteLine(att);
            }
            Console.WriteLine(sampleColection.samples[0].decision);
            System.Console.ReadLine();
        }
    }
    

    

}
