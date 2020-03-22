using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Node
    {
        public Node ancestor { get; private set; }
        public string player { get; private set; }
        public int id { get; private set; }
        public int value { get; private set; }
        public int result { get; set; } //1: przegrana 2: remis 3: wygrana

        public Node(int _id=0, int _value=0, string _player = "prot", int _result = 0, Node _ancestor = null)
        {
            id = _id;
            value = _value;
            player = _player;
            result = _result;
            ancestor = _ancestor;
        }

        public string nodeAsString()
        {
            return "\"node id: " + id + "\\n current player: " + player + "\\n current score: " + value + "\\n result: " + result + "\"";
        }

    }
}
