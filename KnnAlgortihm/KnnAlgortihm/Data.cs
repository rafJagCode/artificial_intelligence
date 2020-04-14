using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnAlgortihm
{
    class Data
    {
        public List<List<double>> dataFromFile = new List<List<double>>();
        public Data(string[] rows)
        {
            foreach (var row in rows)
            {
                this.dataFromFile.Add(rowToList(row));
            }
        }
        public static List<double> rowToList(string row)
        {
            var attributes = new List<double>();
            var datas = row.Trim().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < datas.Length; i++)
            {
                double result;
                bool comma = double.TryParse(datas[i], out result);
                var tmp = datas[i].Trim();
                tmp = comma ? tmp.Replace(",", ".") : tmp.Replace(".", ",");
                var number = double.Parse(tmp);
                attributes.Add(number);
            }
            return attributes;
        }
    }
}
