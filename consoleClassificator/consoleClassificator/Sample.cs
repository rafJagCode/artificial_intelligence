using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleClassificator
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
    }
}
