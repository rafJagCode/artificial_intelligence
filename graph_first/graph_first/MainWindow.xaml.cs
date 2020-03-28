using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace graph_first
{
    public partial class MainWindow : Window
    {
        static public int limit = 21;
        public BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
        }

        private void generateBtn(object sender, RoutedEventArgs e)
        {
            int x = 0;
            int y = 0;
            Tree startingTree = new Tree();
            Tree solutionTree = new Tree();
            startingTree.createBranches(startingTree._root);
            startingTree.copyTo(solutionTree);
            solutionTree.chooseSolution(0);
            //solutionTree._edges[0]._end._result = 223;
            //solutionTree._nodes[1]._result = 223;
            //startingTree._nodes[1]._result = 223;
            //foreach (Edge node in startingTree._edges) x++;
            //foreach (Edge node in solutionTree._edges) y++;
            //treeTextField.Text = x.ToString();
            //solutionTextField.Text = y.ToString();
            treeTextField.Text = startingTree.treeAsString();
            solutionTextField.Text = solutionTree.treeAsString();

            copySolutionButton.Visibility = Visibility.Visible;
            copyTreeButton.Visibility = Visibility.Visible;
            generateButton.Visibility = Visibility.Hidden;
            okImage.Visibility = Visibility.Visible;
        }

        private void copyTreeBtn(object sender, RoutedEventArgs e)
        {

            Clipboard.SetText(treeTextField.Text);
            popupText.Text = "Tree copied to clipboard";
            backgroundWorker1.RunWorkerAsync();


        }
        private void copySolutionBtn(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(solutionTextField.Text);
            popupText.Text = "Solution copied to clipboard";
            backgroundWorker1.RunWorkerAsync();
        }

        private void popup_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePosition = e.GetPosition(myWindow);
            popup.HorizontalOffset = mousePosition.X+20;
            popup.VerticalOffset = mousePosition.Y-20;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
                Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            popupText.Text = "";
        }
    }
}
