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
using System.Drawing.Text;
using SoftArt.WPF.Graph;
using ATNET.Gui.Windows.Label;
using System.IO;

namespace ATNET.Gui.Windows
{
    /// <summary>
    /// LabelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LabelWindow : Window
    {
        private Point? dragStartPoint = null;
        private Vector initialMouseOffset;
        private BarCode barCode;
        private DraggedAdorner draggedAdorner = null;

        private Visual selectedBrush = null;
        
        public LabelWindow()
        {
            InitializeComponent();
            this.Closed += new EventHandler(LabelWindow_Closed);
            foreach (UIElement children in toolBar.Items)
            {
                if (children is Button)
                {
                    ((Button)children).PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Button_PreviewMouseLeftButtonDown);
                }
            }
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (selectedBrush == null)
            {
                Button btn = sender as Button;
                selectedBrush = btn;
            }
        }

        private void LabelWindow_Closed(object sender, EventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window.IsVisible == false)
                {
                    window.Close();
                }
            }
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            BarCode bc = e.Data.GetData(typeof(BarCode)) as BarCode;
            if (bc == null) return;

            mainCanvas.Children.Add(bc);
            Canvas.SetTop(bc, e.GetPosition(this.mainCanvas).Y);
            Canvas.SetLeft(bc, e.GetPosition(this.mainCanvas).X);

            dragStartPoint = null;
            selectedBrush = null;

            RemoveDraggedAdorner();
            e.Handled = true;
        }

        public static bool IsMovementBigEnough(Point initialMousePosition, Point currentPosition)
        {
            return (Math.Abs(currentPosition.X - initialMousePosition.X) >= SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(currentPosition.Y - initialMousePosition.Y) >= SystemParameters.MinimumVerticalDragDistance);
        }

        private void ToolBar_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dragStartPoint = new Point?(Mouse.GetPosition(this));
        }

        private void ToolBar_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (dragStartPoint.HasValue)
            {
                if (IsMovementBigEnough(dragStartPoint.Value, e.GetPosition(this)))
                {
                    Button btn = selectedBrush as Button;
                    this.initialMouseOffset = this.dragStartPoint.Value - btn.TranslatePoint(new Point(0, 0), this);

                    DataObject dataObject = new DataObject();
                    this.barCode = new BarCode("1234567");
                    dataObject.SetData(this.barCode);
                    DragDrop.DoDragDrop(this, dataObject, DragDropEffects.Copy);
                }
            }
        }

        private void mainCanvas_PreviewDragEnter(object sender, DragEventArgs e)
        {
            BarCode bc = e.Data.GetData(typeof(BarCode)) as BarCode;
            if (bc != null)
            {
                ShowDraggedAdorner(e.GetPosition(this));
            }
            e.Handled = true;
        }

        private void mainCanvas_PreviewDragOver(object sender, DragEventArgs e)
        {
            BarCode bc = e.Data.GetData(typeof(BarCode)) as BarCode;
            if (bc != null)
            {
                ShowDraggedAdorner(e.GetPosition(this));
            }
            e.Handled = true;
        }

        private void ShowDraggedAdorner(Point currentPoint)
        {
            if (this.draggedAdorner == null)
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(this.mainCanvas);
                DataTemplate template = new DataTemplate();
                template.VisualTree = new FrameworkElementFactory(typeof(TextBlock));
                this.draggedAdorner = new DraggedAdorner(adornerLayer, this.mainCanvas, template);
            }
            double leftChange = currentPoint.X - this.dragStartPoint.Value.X + this.initialMouseOffset.X;
            double topChange = currentPoint.Y - this.dragStartPoint.Value.Y + this.initialMouseOffset.Y;
            this.draggedAdorner.SetPosition(leftChange, topChange);
        }

        private void RemoveDraggedAdorner()
        {
            if (this.draggedAdorner != null)
            {
                this.draggedAdorner.Detach();
                this.draggedAdorner = null;
            }
        }

        private void mainCanvas_PreviewDragLeave(object sender, DragEventArgs e)
        {
            RemoveDraggedAdorner();
            e.Handled = true;
        }

    }
}
