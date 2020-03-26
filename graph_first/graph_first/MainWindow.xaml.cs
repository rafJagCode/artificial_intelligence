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

namespace graph_first
{
    public partial class MainWindow : Window
    {
        static public int limit = 21;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void generateBtn(object sender, RoutedEventArgs e)
        {

            Tree startingTree = new Tree();
            startingTree.createBranches(startingTree.root);
            Tree solutionTree = startingTree.copy();
            solutionTree.chooseSolution(0);
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
            popupText.Text = "Copied to clipboard";


        }
        private void copySolutionBtn(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(solutionTextField.Text);
        }

        private void popup_MouseMove(object sender, MouseEventArgs e)
        {
            if (!popup.IsOpen)
                popup.IsOpen = true;

            var mousePosition = e.GetPosition(myWindow);
            popup.HorizontalOffset = mousePosition.X+20;
            popup.VerticalOffset = mousePosition.Y-20;

        }
    }
}
