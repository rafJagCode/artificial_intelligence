using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnnAlgortihm
{
    class DataLoader
    {
        public bool isLoaded = false;
        public List<List<double>> data;
        public DataLoader(OpenFileDialog ofd)
        {
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var file = new FileInfo(ofd.FileName);
            if (file.Extension != ".txt")
            {
                MessageBox.Show("Dozwolone rozszerzenie to \"TXT\"");
                return;
            }
            try {
                var rows = File.ReadAllLines(ofd.FileName);
                data = new Data(rows).dataFromFile;
                isLoaded = true;
            }
            catch { isLoaded = false; }
            
            
        }
    }
}
