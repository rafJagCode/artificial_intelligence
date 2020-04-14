using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleClassificator
{
    class SampleColection
    {
        public List<Sample> samples = new List<Sample>();
        public List<string> takeLinesFromFile()
        {
            List<string> lines = new List<string>();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Lenovo\Desktop\iris.txt");
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }
            file.Close();
            return lines;
        }
        public List<double> numberRow(string line)
        {
            NumberFormatInfo formatProvider = new NumberFormatInfo();
            formatProvider.NumberDecimalSeparator = ".";
            formatProvider.NumberGroupSeparator = ".";
            formatProvider.NumberGroupSizes = new int[] { 2 };
            List<double> numbers = new List<double>();
            string[] numberRowAsString = line.Split('\t');
            foreach (string number in numberRowAsString)
            {
                numbers.Add(Convert.ToDouble(number, formatProvider));
            }
            return numbers;
        }
        public List<List<double>> convertDataFromFileToList()
        {
            List<List<double>> data = new List<List<double>>();
            List<string> lines = takeLinesFromFile();
            foreach (string line in lines)
            {
                data.Add(numberRow(line));
            }
            return data;
        }
        public Sample makeSample(List<double> row)
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
        public void addSamples()
        {
            List<List<double>> data = convertDataFromFileToList();
            foreach (List<double> row in data)
            {
                this.samples.Add(makeSample(row));
            }
        }
        public double findMinAttr(int attrNumber)
        {
            double min = this.samples[0].attributes[attrNumber];
            foreach (Sample sample in this.samples)
            {
                if (sample.attributes[attrNumber] < min) min = sample.attributes[attrNumber];
            }
            return min;
        }
        public double findMaxAttr(int attrNumber)
        {
            double max = this.samples[0].attributes[attrNumber];
            foreach (Sample sample in this.samples)
            {
                if (sample.attributes[attrNumber] > max) max = sample.attributes[attrNumber];
            }
            return max;
        }
        public double normalizeAttribute(double attribute, int attrNumber)
        {
            double normalized;
            double min = findMinAttr(attrNumber);
            double max = findMaxAttr(attrNumber);
            return normalized = (attribute - min) / (max - min);
        }
        public void normalizeAttributes(List<double> attributes)
        {
            for (int i = 0; i < attributes.Count; i++)
            {
                attributes[i] = normalizeAttribute(attributes[i], i);
            }
        }
        public void normalizeSamples()
        {
            foreach (Sample sample in this.samples)
            {
                normalizeAttributes(sample.attributes);
            }
        }
    }
}
