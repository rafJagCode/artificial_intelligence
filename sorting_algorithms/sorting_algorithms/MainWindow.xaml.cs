using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace sorting_algorithms
{

    public partial class MainWindow : Window
    {
        int n = 8;
        int speed = 300;
        List<Line> lines = new List<Line>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void generate_data(object sender, RoutedEventArgs e)
        { 
            line_display.Children.Clear();
            lines.Clear();
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;
                objLine.StrokeThickness = 2;
                objLine.X1 = 8 + i * 8;
                objLine.X2 = objLine.X1;
                objLine.Y1 = line_display.ActualHeight;
                objLine.Y2 = rnd.Next(1, 150);
                lines.Add(objLine);
            }
            draw_lines(lines);
        }
        public void draw_lines(List<Line> lines)
        {
            line_display.Children.Clear();
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].X1 = lines[i].X2 = 8 + i * 8;
                line_display.Children.Add(lines[i]);
            }
            Trace.WriteLine(write_list(lines));
        }
        public string write_list(List<Line> lines)
        {
            string whole_list = "";
            foreach (Line x in lines) whole_list += x.Y2 + "=>" + x.X1 + ", ";
            return whole_list;
        }
        private void bubble_click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(bubble_sort));
            t.Start();
        }
        private void bubble_sort()
        {
            for (int i = 1; i < n; i++)
                for (int j = n - 1; j >= i; j--)
                {
                    Thread.Sleep(speed);
                    Dispatcher.Invoke(new Action(() => { decide_whether_to_change_order(lines, j); }));
                    Dispatcher.Invoke( new Action( () => { draw_lines(lines); }));
                }
        }
        public void decide_whether_to_change_order(List<Line> lines, int j)
        {
            if (lines[j].Y2 < lines[j - 1].Y2)
            {
                swap(lines, j, j - 1);
            }
        }
        private void swap(List<Line> lines, int index1, int index2)
        {
            Line temp = lines[index1];
            lines[index1] = lines[index2];
            lines[index2] = temp;
        }
    }
}
