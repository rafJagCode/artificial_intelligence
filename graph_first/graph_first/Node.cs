using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Node
    {
        public Node ancestor { get; set; }
        public string player { get; set; }
        public int id { get; set; }
        public int value { get; set; }
        public int result { get; set; } //1: przegrana 2: remis 3: wygrana

        public Node(int _id, int _value, string _player = "prot", int _result = 0, Node _ancestor = null)
        {
            id = _id;
            value = _value;
            player = _player;
            result = _result;
            ancestor = _ancestor;
        }

        public void print()
        {
            Console.WriteLine(this.id + "=>" + this.value + "=>" + this.player + "=>" + this.result);
        }

        public string nodeAsString()
        {
            return "\"node id: " + id + "\\n current player: " + player + "\\n current score: " + value + "\\n result: " + result + "\"";
        }

    }
}
