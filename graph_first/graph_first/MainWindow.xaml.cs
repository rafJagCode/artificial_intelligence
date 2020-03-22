using System;
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
    public partial class MainWindow : Window
    {
        static public int limit = 21;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void test_click(object sender, RoutedEventArgs e)
        {
            Tree tree = new Tree();
            tree.createBranches(tree.root);
            tree.chooseSolution(0);
            tree.treeAsString();
        }
    }
}
