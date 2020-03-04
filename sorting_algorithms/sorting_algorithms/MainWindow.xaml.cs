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
        int n = 50;
        int speed = 100;
        int range = 150;
        bool thread_started = false;
        bool sorted = false;
        List<Line> lines = new List<Line>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void generate_data(object sender, RoutedEventArgs e)
        {
            if (!thread_started)
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
                    objLine.Y2 = rnd.Next(1, range);
                    lines.Add(objLine);
                }
                draw_lines(lines);
                sorted = false;
            }
            else System.Windows.MessageBox.Show("Inny wątek jest aktualnie aktywny");
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
            if (!t.IsAlive && !thread_started)
            {
                if (sorted) System.Windows.MessageBox.Show("Wygeneruj nowe dane do posortowania");
                else
                {
                    thread_started = true;
                    t.Start();
                }
            }
            else System.Windows.MessageBox.Show("Inny wątek jest aktualnie aktywny");
        }
        private void bubble_sort()
        {
            bool result;
            for (int i = 1; i < n; i++)
                for (int j = n - 1; j >= i; j--)
                {
                    Thread.Sleep(speed);
                    result = Dispatcher.Invoke(new Func<bool>(() => {return is_decreasing(lines, j);}));
                    if (result) Dispatcher.Invoke(new Action(() => { swap(lines, j, j - 1); }));
                    Dispatcher.Invoke( new Action( () => { draw_lines(lines); }));
                }
            thread_started = false;
            sorted = true;
        }
        private void insertion_click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(insertion_sort));
            if (!t.IsAlive && !thread_started)
            {
                if (sorted) System.Windows.MessageBox.Show("Wygeneruj nowe dane do posortowania");
                else
                {
                    thread_started = true;
                    t.Start();
                }
            }
            else System.Windows.MessageBox.Show("Inny wątek jest aktualnie aktywny");
        }
        private void choosing_click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(choosing_sort));
            if (!t.IsAlive && !thread_started)
            {
                if (sorted) System.Windows.MessageBox.Show("Wygeneruj nowe dane do posortowania");
                else
                {
                    thread_started = true;
                    t.Start();
                }
            }
            else System.Windows.MessageBox.Show("Inny wątek jest aktualnie aktywny");
        }
        private void counting_click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(couting_sort));
            if (!t.IsAlive && !thread_started)
            {
                if (sorted) System.Windows.MessageBox.Show("Wygeneruj nowe dane do posortowania");
                else
                {
                    thread_started = true;
                    t.Start();
                }
            }
            else System.Windows.MessageBox.Show("Inny wątek jest aktualnie aktywny");
        }
        private void insertion_sort()
        {
            for (int i = 0; i < n; i++)
            {
                int j = i;
                Line temp = lines[j];
                while ((j > 0) && Dispatcher.Invoke(new Func<bool>(() => { return is_smaller(temp, lines[j-1]); })))
                {
                    lines[j] = lines[j - 1];
                    j--;
                    Dispatcher.Invoke(new Action(() => { draw_lines_socond(lines); }));
                    Thread.Sleep(speed);
                }
                lines[j] = temp;
            }
            Dispatcher.Invoke(new Action(() => { draw_lines_socond(lines); }));
            thread_started = false;
            sorted = true;
        }
        private void choosing_sort()
        {
            int min;
            for (int i = 0; i < n; i++)
            {
                min = find_min(lines, i);
                swap(lines, i, min);
                Dispatcher.Invoke(new Action(() => { draw_lines_socond(lines); }));
                Thread.Sleep(speed);
            }
            thread_started = false;
            sorted = true;
        }
        private void couting_sort()
        {
            int j = 0;
            List<int>count = new List<int>();
            for (int i = 0; i < range+ 1; i++)
            {
                count.Add(0);
            }
            for (int i = 0; i < n; i++)
            {
                Dispatcher.Invoke(new Action(() => { increment(count, lines, i); }));
                
            }
            for (int i = 0; i < range+ 1; i++)
            {
                while (count[i] > 0)
                {
                    Dispatcher.Invoke(() => { lines[j].Y2 = i; });
                    Thread.Sleep(speed);
                    j++;
                    count[i]--;
                }
            }
            thread_started = false;
            sorted = true;
        }
        void increment(List<int> count, List<Line> lines, int i)
        {
            count[(int)lines[i].Y2]++;
        }
        int find_min(List<Line>lines, int start)
        {
            Line tmp = lines[start];
            int result = start;
            for (int i = start + 1; i < n; i++)
            {
                if (Dispatcher.Invoke(new Func<bool>(() => { return is_smaller(lines[i], tmp); })))
                {
                    tmp = lines[i];
                    result = i;
                }
            }
            return result;
        }
        public bool is_decreasing(List<Line> lines, int j)
        {
            if (lines[j].Y2 < lines[j - 1].Y2)
                return true;
            return false;
        }
        public bool is_smaller (Line a, Line b)
        {
            if (a.Y2 < b.Y2) return true;
            return false;
        }
        private void swap(List<Line> lines, int index1, int index2)
        {
            Line temp = lines[index1];
            lines[index1] = lines[index2];
            lines[index2] = temp;
        }
        private void change(List<Line>lines, int j)
        {
            lines[j + 1] = lines[j];
        }
        public void draw_lines_socond(List<Line>lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].X1 = lines[i].X2 = 8 + i * 8;
            }
        }
    }
}
