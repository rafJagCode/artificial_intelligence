using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Tree
    {
        public List<Node> _nodes;
        public List<Edge> _edges;
        public Node _root { get; set; }

        public Tree()
        {
            _nodes = new List<Node>();
            _edges = new List<Edge>();
            _root = new Node();
            addNode(_root);
        }

        public void addNode(Node node)
        {
            _nodes.Add(node);
        }

        public void addEdge(Edge edge)
        {
            _edges.Add(edge);
        }

        private string changePlayer(string player)
        {
            return player == "ant" ? "prot" : "ant";
        }

        private void figureOutTheScore(Node node)
        {
            int value = node._value;
            string player = node._player;
            // Warunki przypisywania wyniku węzłom końcowym
            if ((value > MainWindow.limit) && (player == "ant")) node._result = 1;
            else if ((value > MainWindow.limit) && (player == "prot")) node._result = 3;
            else if (value == MainWindow.limit) node._result = 2;
        }
        public void createBranches(Node node)
        {
            // Jeżeli trafisz na węzeł końcowy przypisz wartość wyniku gry i zakończ
            if (node._value >= MainWindow.limit)
            {
                figureOutTheScore(node);
                return;
            }
            // Jeżeli to nie węzeł końcowy stwórz trzy węzły potomne
            Node tmp;
            string player = changePlayer(node._player);
            for (int i = 0; i < 3; i++)
            {
                tmp = new Node(node._id * 10 + 1 + i, node._value + 4 + i, player, 0, node);
                addNode(tmp);
                addEdge(new Edge(node, tmp, 4 + i));
                // Dla każdego stworzonego węzła utuchom metodę tworzącą węzły potomne
                createBranches(tmp);
            }
        }

        private List<Edge> findEdgeStartingWithId(int id)
        {
            List<Edge> result = new List<Edge>();
            for (int i = 0; i < _edges.Count(); i++)
            {
                if (_edges[i]._begin._id == id) result.Add(_edges[i]);
            }
            return result;
        }

        private Node findNode(int id)
        {
            for (int i = 0; i < _nodes.Count(); i++)
            {
                if (_nodes[i]._id == id) return _nodes[i];
            }
            return null;
        }

        public void chooseSolution(int id)
        {
            Node thisNode = findNode(id);
            // Przerwij gdy trafisz na węzeł końcowy
            if (thisNode._value >= MainWindow.limit) return;
            // W innym przypadku sprawdź którą krawędź oznaczyć czerwonym kolorem
            else
            {
                List<Edge> possibleEdges = findEdgeStartingWithId(id);
                for (int i = 0; i < possibleEdges.Count(); i++)
                {
                    // uruchom metodę wybierającą rozwiązanie dla każdego możliwego węzła potomnego
                    chooseSolution(possibleEdges[i]._end._id);
                }
                string player = thisNode._player;
                Edge choosed;
                if (player == "ant") choosed = findEdgeWithSmallestResult(possibleEdges);
                else choosed = findEdgeWithBiggestResult(possibleEdges);
                // Przepisz wynik z wybranego węzła na przodka
                choosed._begin._result = choosed._end._result;
                choosed._color = "red";
            }
        }

        private Edge findEdgeWithSmallestResult(List<Edge> possibleEdges)
        {
            Edge tmp = possibleEdges[0];
            for (int i = 1; i < possibleEdges.Count(); i++)
            {
                if (possibleEdges[i]._end._result < tmp._end._result) tmp = possibleEdges[i];
            }
            return tmp;
        }

        private Edge findEdgeWithBiggestResult(List<Edge> possibleEdges)
        {
            Edge tmp = possibleEdges[0];
            for (int i = 1; i < possibleEdges.Count(); i++)
            {
                if (possibleEdges[i]._end._result > tmp._end._result) tmp = possibleEdges[i];
            }
            return tmp;
        }
        public void copyTo(Tree result)
        {
            result._nodes = _nodes.ConvertAll(node => new Node(node._id,node._value,node._player,node._result,node._ancestor));
            result._edges = _edges.ConvertAll(edge => new Edge(edge._begin,edge._end,edge._value,edge._color));
        }
        // Wypisz drzewo w formie łańcucha znaków w formacie zgodnym z graphViz
        public string treeAsString()
        {
            StringBuilder sb = new StringBuilder("digraph G {\n");
            for (int i = 0; i < _edges.Count(); i++)
            {
                sb.Append(_edges[i]._begin.nodeAsString());
                sb.Append(" -> ");
                sb.Append(_edges[i]._end.nodeAsString());
                sb.Append("[label = \"");
                sb.Append(_edges[i]._value);
                sb.Append("\" color=\"");
                sb.Append(_edges[i]._color);
                sb.Append("\"];\n");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
