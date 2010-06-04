using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Drawing.Text;

namespace ATNET.Gui.Windows.Label
{
    /// <summary>
    /// 条形码的显示类
    /// </summary>
    public class BarCode:Grid
    {
        private System.Drawing.FontFamily barcodeFont;

        private string barCodeString;
        /// <summary>
        /// 条形码显示的字符
        /// </summary>
        public string BarCodeString
        {
            set { barCodeString = value; }
        }

        public BarCode()
        {
 
        }

        public BarCode(string barCodeString)
        {
            this.barCodeString = barCodeString;
            InitializeBarCode();
        }

        private void InitializeBarCode()
        {
            InstalledFontCollection fc = new InstalledFontCollection();
            foreach (System.Drawing.FontFamily ff in fc.Families)
            {
                if (ff.Name.Contains("3 of 9"))
                {
                    barcodeFont = ff;
                    break;
                }
            }
            if (barcodeFont == null) throw new Exception("条形码字体不存在");

            TextBlock barGraph = new TextBlock();
            barGraph.FontFamily = new FontFamily(barcodeFont.Name);
            barGraph.FontSize = 50;
            barGraph.Text = barCodeString;
            TextBox barString = new TextBox();
            barString.HorizontalAlignment = HorizontalAlignment.Center;
            barString.VerticalAlignment = VerticalAlignment.Center;
            barString.FontSize = 50;
            barString.TextChanged += new TextChangedEventHandler(barString_TextChanged);
            barString.Text = barCodeString;
            barString.BorderBrush = Brushes.Transparent;
            barString.Background = Brushes.Transparent;
            RowDefinition row1 = new RowDefinition();
            row1.Height = GridLength.Auto;
            RowDefinition row2 = new RowDefinition();
            row2.Height = GridLength.Auto;
            this.RowDefinitions.Add(row1);
            this.RowDefinitions.Add(row2);
            this.Children.Add(barGraph);
            this.Children.Add(barString);
            Grid.SetColumn(barGraph, 0);
            Grid.SetRow(barGraph, 0);
            Grid.SetColumn(barString, 0);
            Grid.SetRow(barString, 1);
        }

        private void barString_TextChanged(object sender, TextChangedEventArgs e)
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
