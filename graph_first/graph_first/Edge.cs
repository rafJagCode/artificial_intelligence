using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Edge
    {
        public Node _begin { get; private set; }
        public Node _end { get; private set; }
        public int _value { get; private set; }
        public string _color { get; set; }

        public Edge(Node begin, Node end, int value, string color = "black")
        {
            _begin = begin;
            _end = end;
            _value = value;
            _color = color;
        }
    }
}
