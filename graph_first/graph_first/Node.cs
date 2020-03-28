using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Node
    {
        public Node _ancestor { get; private set; }
        public string _player { get; private set; }
        public int _id { get; private set; }
        public int _value { get; private set; }
        public int _result { get; set; } //1: przegrana 2: remis 3: wygrana

        public Node(int id=0, int value=0, string player = "prot", int result = 0, Node ancestor = null)
        {
            _id = id;
            _value = value;
            _player = player;
            _result = result;
            _ancestor = ancestor;
        }

        public string nodeAsString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("\"node id: ");
            result.Append(_id);
            result.Append("\\n current player: ");
            result.Append(_player);
            result.Append("\\n current score: ");
            result.Append(_value);
            result.Append("\\n result: ");
            result.Append(_result);
            result.Append("\"");
            //return "\"node id: " + id + "\\n current player: " + player + "\\n current score: " + value + "\\n result: " + result + "\"";
            return result.ToString();
        }

    }
}
