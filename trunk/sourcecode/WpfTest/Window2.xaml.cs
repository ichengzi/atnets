using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTest
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid();
            TextBlock barGraph = new TextBlock();
            barGraph.FontSize = 50;
            TextBox barString = new TextBox();
            barString.HorizontalAlignment = HorizontalAlignment.Center;
            barString.VerticalAlignment = VerticalAlignment.Center;
            barString.FontSize = 50;
            barString.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
            barString.Text = "2";
            barString.BorderBrush = Brushes.Transparent;
            barString.Background = Brushes.Transparent;
            RowDefinition row1 = new RowDefinition();
            row1.Height = GridLength.Auto;
            RowDefinition row2 = new RowDefinition();
            row2.Height = GridLength.Auto;
            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            grid.Children.Add(barGraph);
            grid.Children.Add(barString);
            Grid.SetColumn(barGraph, 0);
            Grid.SetRow(barGraph, 0);
            Grid.SetColumn(barString, 0);
            Grid.SetRow(barString, 1);

            mainGrid.Children.Add(grid);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Grid parent = tb.Parent as Grid;
            if (parent != null)
            {
                TextBlock graph = parent.Children[0] as TextBlock;
                graph.Text = tb.Text;
            }
        }
    }
}
