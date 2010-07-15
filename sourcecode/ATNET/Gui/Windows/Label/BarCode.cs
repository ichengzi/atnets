using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Drawing.Text;
using System.Windows.Input;
using System.Windows.Documents;

namespace ATNET.Gui.Windows.Label
{
    /// <summary>
    /// 条形码的显示类
    /// </summary>
    public class BarCode:Grid
    {
        private System.Drawing.FontFamily barcodeFont;
        private bool isMouseLeftButtonDown = false;
        //private Point? startPoint;
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
            this.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(BarCode_PreviewMouseLeftButtonDown);
            this.PreviewMouseMove += new MouseEventHandler(BarCode_PreviewMouseMove);
            this.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(BarCode_PreviewMouseLeftButtonUp);
        }

        private void BarCode_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.CaptureMouse();
            this.Cursor = Cursors.Cross;
            this.isMouseLeftButtonDown = true;
            Canvas canvas = this.Parent as Canvas;
            if (canvas != null)
            {
                ShowAdorner();
            }
        }

        private void BarCode_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ReleaseMouseCapture();
            this.Cursor = Cursors.Arrow;
            this.isMouseLeftButtonDown = false;
            RemoveAdorner();
        }

        private void BarCode_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown)
            {
                Canvas canvas = this.Parent as Canvas;
                Point pt;
                if (canvas != null)
                {
                    pt = e.GetPosition(canvas);
                    double top = pt.Y - this.ActualHeight / 2;
                    double left = pt.X - this.ActualWidth / 2;
                    Canvas.SetTop(this, top);
                    Canvas.SetLeft(this, left);
                }
                
            }
        }

        public BarCode(string barCodeString):this()
        {
            this.barCodeString = barCodeString;
            InitializeBarCode();
        }

        private void ShowAdorner()
        {

            AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);
            if (layer != null)
            {
                LabelAdorner adorner = new LabelAdorner(this);
                if (adorner != null)
                {
                    layer.Add(adorner);
                }
            }

        }

        private void RemoveAdorner()
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);
            if (layer != null)
            {
                LabelAdorner adorner = new LabelAdorner(this);
                if (adorner != null)
                {
                    layer.Remove(adorner);
                }
            }
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
            barString.PreviewMouseDoubleClick += new MouseButtonEventHandler(barString_PreviewMouseDoubleClick);
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

        private void barString_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;
            this.ReleaseMouseCapture();
            tb.SelectionLength = tb.Text.Length;
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
