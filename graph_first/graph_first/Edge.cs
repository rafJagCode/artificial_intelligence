using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Edge
    {
        public Node begin { get; set; }
        public Node end { get; set; }
        public int value { get; set; }
        public string color { get; set; }

        public Edge(Node _begin, Node _end, int _value, string _color = "black")
        {
            begin = _begin;
            end = _end;
            value = _value;
            color = _color;
        }
        public void print()
        {
            Console.WriteLine(begin.nodeAsString() + "---" + end.nodeAsString());
        }

    }
}
