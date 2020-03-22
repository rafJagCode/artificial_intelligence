using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Edge
    {
        public Node begin { get; private set; }
        public Node end { get; private set; }
        public int value { get; private set; }
        public string color { get; set; }

        public Edge(Node _begin, Node _end, int _value, string _color = "black")
        {
            begin = _begin;
            end = _end;
            value = _value;
            color = _color;
        }
    }
}
