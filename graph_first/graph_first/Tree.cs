using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Tree
    {
        private List<Node> nodes;
        private List<Edge> edges;
        public Node root { get; protected set; }

        public Tree()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
            root = new Node();
            addNode(root);
        }

        private void addNode(Node node)
        {
            nodes.Add(node);
        }

        private void addEdge(Edge edge)
        {
            edges.Add(edge);
        }

        private string changePlayer(string player)
        {
            return player == "ant" ? "prot" : "ant";
        }

        private void figureOutTheScore(Node node)
        {
            int value = node.value;
            string player = node.player;
            // Warunki przypisywania wyniku węzłom końcowym
            if ((value > MainWindow.limit) && (player == "ant")) node.result = 1;
            else if ((value > MainWindow.limit) && (player == "prot")) node.result = 3;
            else if (value == MainWindow.limit) node.result = 2;
        }
        public void createBranches(Node node)
        {
            // Jeżeli trafisz na węzeł końcowy przypisz wartość wyniku gry i zakończ
            if (node.value >= MainWindow.limit)
            {
                figureOutTheScore(node);
                return;
            }
            // Jeżeli to nie węzeł końcowy stwórz trzy węzły potomne
            Node tmp;
            string player = changePlayer(node.player);
            for (int i = 0; i < 3; i++)
            {
                tmp = new Node(node.id * 10 + 1 + i, node.value + 4 + i, player, 0, node);
                addNode(tmp);
                addEdge(new Edge(node, tmp, 4 + i));
                // Dla każdego stworzonego węzła utuchom metodę tworzącą węzły potomne
                createBranches(tmp);
            }
        }

        private List<Edge> findEdgeStartingWithId(int id)
        {
            List<Edge> result = new List<Edge>();
            for (int i = 0; i < edges.Count(); i++)
            {
                if (edges[i].begin.id == id) result.Add(edges[i]);
            }
            return result;
        }

        private Node findNode(int id)
        {
            for (int i = 0; i < nodes.Count(); i++)
            {
                if (nodes[i].id == id) return nodes[i];
            }
            return null;
        }

        public void chooseSolution(int id)
        {
            Node thisNode = findNode(id);
            // Przerwij gdy trafisz na węzeł końcowy
            if (thisNode.value >= MainWindow.limit) return;
            // W innym przypadku sprawdź którą krawędź oznaczyć czerwonym kolorem
            else
            {
                List<Edge> possibleEdges = findEdgeStartingWithId(id);
                for (int i = 0; i < possibleEdges.Count(); i++)
                {
                    // uruchom metodę wybierającą rozwiązanie dla każdego możliwego węzła potomnego
                    chooseSolution(possibleEdges[i].end.id);
                }
                string player = thisNode.player;
                Edge choosed;
                if (player == "ant") choosed = findEdgeWithSmallestResult(possibleEdges);
                else choosed = findEdgeWithBiggestResult(possibleEdges);
                // Przepisz wynik z wybranego węzła na przodka
                choosed.begin.result = choosed.end.result;
                choosed.color = "red";
            }
        }

        private Edge findEdgeWithSmallestResult(List<Edge> possibleEdges)
        {
            Edge tmp = possibleEdges[0];
            for (int i = 1; i < possibleEdges.Count(); i++)
            {
                if (possibleEdges[i].end.result < tmp.end.result) tmp = possibleEdges[i];
            }
            return tmp;
        }

        private Edge findEdgeWithBiggestResult(List<Edge> possibleEdges)
        {
            Edge tmp = possibleEdges[0];
            for (int i = 1; i < possibleEdges.Count(); i++)
            {
                if (possibleEdges[i].end.result > tmp.end.result) tmp = possibleEdges[i];
            }
            return tmp;
        }
        // Wypisz drzewo w formie łańcucha znaków w formacie zgodnym z graphViz
        public void treeAsString()
        {

            string result = "digraph G {\n";
            for (int i = 0; i < this.edges.Count(); i++)
            {
                result += this.edges[i].begin.nodeAsString() + " -> " + this.edges[i].end.nodeAsString() + "[label = \"" + this.edges[i].value + "\" color=\"" + this.edges[i].color + "\"];\n";
            }
            result += "}";
            Console.WriteLine(result);
        }
    }
}
