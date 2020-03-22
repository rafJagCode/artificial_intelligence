using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_first
{
    public class Tree
    {
        public List<Node> nodes;
        public List<Edge> edges;

        public Tree()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
        }

        public void addNode(Node node)
        {
            nodes.Add(node);
        }

        public void addEdge(Edge edge)
        {
            edges.Add(edge);
        }

        public void createBranches(Node root)
        {
            if ((root != null) && (root.value >= MainWindow.limit)) return;
            Node newRoot = root;
            Node tmp;
            int id;
            int value;
            int result = 0;
            string player;
            if (newRoot == null)
            {
                newRoot = new Node(0, 0);
                this.addNode(newRoot);
                //Console.WriteLine("new root created \n");
            }
            if (newRoot.player == "prot") player = "ant";
            else player = "prot";
            for (int i = 0; i < 3; i++)
            {
                value = newRoot.value + 4 + i;
                if ((value > MainWindow.limit) && (player == "prot")) result = 1;
                else if ((value > MainWindow.limit) && (player == "ant")) result = 3;
                else if (value == MainWindow.limit) result = 2;
                id = newRoot.id * 10 + 1 + i;
                tmp = new Node(id, value, player, result, newRoot);
                this.addNode(tmp);
                this.addEdge(new Edge(newRoot, tmp, 4 + i));
                this.createBranches(tmp);
                //tmp.print();
            }
        }

        public List<Edge> findEdgeStartingWithId(int id)
        {
            List<Edge> result = new List<Edge>();
            for (int i = 0; i < edges.Count(); i++)
            {
                if (edges[i].begin.id == id) result.Add(edges[i]);
            }
            return result;
        }

        public Node findNode(int id)
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
            if (thisNode.value >= MainWindow.limit) return;
            else
            {
                List<Edge> possibleEdges = findEdgeStartingWithId(id);
                for (int i = 0; i < possibleEdges.Count(); i++)
                {
                    chooseSolution(possibleEdges[i].end.id);
                }
                string player = thisNode.player;
                Edge choosed;
                if (player == "ant") choosed = findEdgeWithSmallestResult(possibleEdges);
                else choosed = findEdgeWithBiggestResult(possibleEdges);
                choosed.begin.result = choosed.end.result;
                choosed.color = "red";
            }
        }

        public Edge findEdgeWithSmallestResult(List<Edge> possibleEdges)
        {
            Edge tmp = possibleEdges[0];
            for (int i = 1; i < possibleEdges.Count(); i++)
            {
                if (possibleEdges[i].end.result < tmp.end.result) tmp = possibleEdges[i];
            }
            return tmp;
        }

        public Edge findEdgeWithBiggestResult(List<Edge> possibleEdges)
        {
            Edge tmp = possibleEdges[0];
            for (int i = 1; i < possibleEdges.Count(); i++)
            {
                if (possibleEdges[i].end.result > tmp.end.result) tmp = possibleEdges[i];
            }
            return tmp;
        }

        public void print()
        {
            for (int i = 0; i < this.edges.Count(); i++)
            {
                edges[i].print();
                Console.WriteLine("\n");
            }
        }

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
