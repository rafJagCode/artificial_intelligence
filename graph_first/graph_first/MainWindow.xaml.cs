﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace graph_first
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

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
                if ((root!=null)&&(root.value >= 7)) return;
                Node newRoot = root;
                Node tmp;
                int id;
                int value;
                int result = 2;
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
                    if ((value > 7) && (player == "prot")) result = 1;
                    else if ((value > 7) && (player == "ant")) result = 3;
                    id = newRoot.id * 10 + 1 + i;
                    tmp = new Node(id, value, player, result, newRoot);
                    this.addNode(tmp);
                    this.addEdge(new Edge(newRoot, tmp, 4 + i));
                    this.createBranches(tmp);
                    //tmp.print();
                }
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
                
                string result = "";
                for (int i = 0; i < this.edges.Count(); i++)
                {
                    result += "\"" + this.edges[i].begin.id + ";\\n " + this.edges[i].begin.player + ";\\n " + this.edges[i].begin.value + ";\\n wynik= " + this.edges[i].begin.result +
                        "\" -> \"" + this.edges[i].end.id + ";\\n " + this.edges[i].end.player + ";\\n " + this.edges[i].end.value + ";\\n wynik= " + this.edges[i].end.result+"\" " +
                        "[label = \"" + this.edges[i].value + "\"];\n";
                }
                Console.WriteLine(result);
            }
        }
        public class Node
        {
            public Node ancestor { get; set; }
            public string player { get; set; }
            public int id { get; set; }
            public int value { get; set; }
            public int result { get; set; } //1: przegrana 2: remis 3: wygrana

            public Node(int _id, int _value, string _player = "prot", int _result = 2, Node _ancestor=null)
            {
                id=_id;
                value=_value;
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
                return this.id + "=>" + this.value + "=>" + this.player + "=>" + this.result;
            }

        }
        public class Edge
        {
            public Node begin { get; set; }
            public Node end { get; set; }
            public int value { get; set; }

            public Edge(Node _begin, Node _end, int _value)
            {
                begin=_begin;
                end=_end;
                value = _value;
            }
            public void print()
            {
                Console.WriteLine(begin.nodeAsString()+"---"+end.nodeAsString());
            }

        }

        private void test_click(object sender, RoutedEventArgs e)
        {
        //    Node a = new Node(0, 0);
        //    Node b = new Node(1, 4);
        //    Node c = new Node(2, 5);
        //    Node d = new Node(3, 6);


        //    Edge ab = new Edge(a, b);
        //    ab.print();
        Tree tree = new Tree();
        tree.createBranches(null);
        tree.treeAsString();

        }
    }
}