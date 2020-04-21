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
                datas[i] = datas[i].Trim();
                datas[i]=convertDoubleFormat(datas[i]);
                var tmp = double.Parse(datas[i]);
                attributes.Add(tmp);
            }
            return attributes;
        }
        public static string[] convertDoubleFormat(string[] numbers)
        {
            var result=new List<string>();
            foreach(string number in numbers)
            {
                var tmp=convertDoubleFormat(number);
                result.Add(tmp);
            }
            return result.ToArray();
        }
        public static string convertDoubleFormat(string number)
        {
            double result;
            bool parsed = double.TryParse(number, out result);
            if (parsed) return number;
            number = number.Replace('.', ',');
            parsed = double.TryParse(number, out result);
            if (parsed) return number;
            number = number.Replace(',', '.');
            parsed = double.TryParse(number, out result);
            return null;
        }
    }
}
