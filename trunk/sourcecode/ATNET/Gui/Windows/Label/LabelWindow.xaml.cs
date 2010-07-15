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
using ATNET.Services.PrintService;
using System.Printing;

namespace ATNET.Gui.Windows
{
    /// <summary>
    /// LabelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LabelWindow : Window
    {
        private Point? dragStartPoint = null;
        //private Vector initialMouseOffset;
        //private BarCode barCode;
        //private DraggedAdorner draggedAdorner = null;

        private bool isMouseLeftButtonDown = false;

        //private Visual selectedBrush = null;

        private Button selectedButton = null;//当前选中的button
        private UIElement selectedElement = null;//当前画布中选中的Visual
        public LabelWindow()
        {
            InitializeComponent();
            this.AllowDrop = false;
            this.Closed += new EventHandler(LabelWindow_Closed);
            //注册button事件
            this.btnBarcode.Click += new RoutedEventHandler(btn_Click);
            this.btnText.Click += new RoutedEventHandler(btn_Click);
            this.btnRect.Click += new RoutedEventHandler(btn_Click);
            this.btnLine.Click += new RoutedEventHandler(btn_Click);
            this.btnImg.Click += new RoutedEventHandler(btn_Click);

            this.mainCanvas.PreviewMouseMove += new MouseEventHandler(mainCanvas_PreviewMouseMove);
            this.mainCanvas.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(mainCanvas_PreviewMouseLeftButtonDown);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            selectedButton = btn;
        }

        private void mainCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (selectedButton == null) return;
            if (selectedButton.Name == "btnBarcode")
            {
                BarCode barCode = new BarCode("1234567");
                selectedElement = barCode;
            }
            else if (selectedButton.Name == "btnText")
            {
                TextBlock tb = new TextBlock();
                tb.Text = "1234567";
                selectedElement = tb;
            }
            else if (selectedButton.Name == "btnRect")
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Height = 50;
                rectangle.Width = 100;
                rectangle.Fill = Brushes.Red;
                selectedElement = rectangle;
            }
            else if (selectedButton.Name == "btnLine")
            {
                Line line = new Line();
                //line.Height = 1;
                //line.Width = 100;
                line.X1 = 10;
                line.X2 = 110;
                line.Y1 = 20;
                line.Y2 = 20;
                line.StrokeThickness = 2;
                line.Stroke = Brushes.Black;
                line.HorizontalAlignment = HorizontalAlignment.Left;
                line.VerticalAlignment = VerticalAlignment.Center;
                selectedElement = line;
            }
            else if (selectedButton.Name == "btnImg")
            {
                Image img = new Image();
                img.Width = 100;
                img.Height = 100;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("../../../icons/barcode.png", UriKind.Relative);
                bitmap.EndInit();
                img.Source = bitmap;
                img.Stretch = Stretch.Fill;
                selectedElement = img;
            }
            mainCanvas.Children.Add(selectedElement);
            if (selectedElement.GetType() != typeof(BarCode))
            {
                selectedElement.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(selectedElement_PreviewMouseLeftButtonDown);
                selectedElement.PreviewMouseMove += new MouseEventHandler(selectedElement_PreviewMouseMove);
                selectedElement.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(selectedElement_PreviewMouseLeftButtonUp);
            }
            Canvas.SetTop(selectedElement, e.GetPosition(this.mainCanvas).Y);
            Canvas.SetLeft(selectedElement, e.GetPosition(this.mainCanvas).X);

            selectedButton = null;
        }

        private void selectedElement_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown)
            {
                Canvas canvas = mainCanvas;
                Point pt;
                if (canvas != null)
                {
                    pt = e.GetPosition(canvas);
                    double top = pt.Y - ((FrameworkElement)sender).ActualHeight / 2;
                    double left = pt.X - ((FrameworkElement)sender).ActualWidth / 2;
                    Canvas.SetTop((UIElement)sender, top);
                    Canvas.SetLeft((UIElement)sender, left);
                }

            }
        }

        private void selectedElement_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((UIElement)sender).ReleaseMouseCapture();
            this.mainCanvas.Cursor = Cursors.Arrow;
            this.isMouseLeftButtonDown = false;
            RemoveAdorner((UIElement)sender);
        }

        private void selectedElement_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (((UIElement)sender).CaptureMouse())
            {
                this.mainCanvas.Cursor = Cursors.Cross;
                this.isMouseLeftButtonDown = true;
                Canvas canvas = mainCanvas;
                ShowAdorner((UIElement)sender);
            }
        }

        private void mainCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (selectedButton != null)
            {
                this.mainCanvas.Cursor = Cursors.Cross;
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Canvas.SetTop(selectedElement, e.GetPosition(this.mainCanvas).Y);
                    Canvas.SetLeft(selectedElement, e.GetPosition(this.mainCanvas).X);
                }
            }
            else
            {
                this.mainCanvas.Cursor = Cursors.Arrow;
                dragStartPoint = null;
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

        private void ShowAdorner(UIElement element)
        {

            AdornerLayer layer = AdornerLayer.GetAdornerLayer(element);
            if (layer != null)
            {
                LabelAdorner adorner = new LabelAdorner(element);
                if (adorner != null)
                {
                    layer.Add(adorner);
                }
            }

        }

        private void RemoveAdorner(UIElement element)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(element);
            if (layer != null)
            {
                LabelAdorner adorner = new LabelAdorner(element);
                if (adorner != null)
                {
                    layer.Remove(adorner);
                }
            }
        }
/*
        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            UIElement element = null;
            if (e.Data.GetData(typeof(BarCode)).GetType()== typeof(BarCode))
            {
                element = e.Data.GetData(typeof(BarCode)) as BarCode;
            }
            else if (e.Data.GetData(typeof(TextBlock)).GetType() == typeof(TextBlock))
            {
                element = e.Data.GetData(typeof(TextBlock)) as TextBlock;
            }
            else if (e.Data.GetData(typeof(Line)).GetType() == typeof(Line))
            {
                element = e.Data.GetData(typeof(Line)) as Line;
            }
            else if (e.Data.GetData(typeof(Rectangle)).GetType() == typeof(Rectangle))
            {
                element = e.Data.GetData(typeof(Rectangle)) as Rectangle;
            }

            if (element == null) return;
            if (mainCanvas.Children.Count >= 0)
            {
                Console.WriteLine(element);
                mainCanvas.Children.Add(element);
                Canvas.SetTop(element, e.GetPosition(this.mainCanvas).Y);
                Canvas.SetLeft(element, e.GetPosition(this.mainCanvas).X);
            }
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

        private int dragCount = 0;//ToolBar_PreviewMouseMove会被触发两次，剔除其中一次
        private void ToolBar_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (dragStartPoint.HasValue && e.LeftButton == MouseButtonState.Pressed)
            {
                if (IsMovementBigEnough(dragStartPoint.Value, e.GetPosition(this)))
                {
                    Button btn = selectedBrush as Button;
                    if (btn == null) return;
                    this.initialMouseOffset = this.dragStartPoint.Value - btn.TranslatePoint(new Point(0, 0), this);
                
                    DataObject dataObject = new DataObject();
                    if (btn.Name == "btnBarcode")
                    {
                        BarCode barCode = new BarCode("1234567");
                        dataObject.SetData(barCode);
                    }
                    else if (btn.Name == "btnText")
                    {
                        TextBlock tb = new TextBlock();
                        tb.AllowDrop = true;
                        tb.Text = "12345678";
                        dataObject.SetData(tb);
                    }
                    else if (btn.Name == "btnLine")
                    {
                        Line line = new Line();
                        line.Height = 1;
                        line.Width = 100;
                        line.X1 = 10;
                        line.X2 = 110;
                        line.Y1 = 20;
                        line.Y2 = 10;
                        line.Fill = Brushes.Black;
                        dataObject.SetData(line);
                    }
                    else if (btn.Name == "btnRect")
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Height = 50;
                        rectangle.Width = 100;
                        rectangle.Fill = Brushes.Transparent;
                        dataObject.SetData(rectangle);
                    }
                    else if (btn.Name == "btnImg")
                    {

                    }
                    try
                    {
                        dragCount++;
                        if (dragCount == 2)
                        {
                            DragDrop.DoDragDrop(this.toolBar, dataObject, DragDropEffects.Copy);
                            dragCount = 0;
                        }
                    }
                    catch { }
                }
            }
            else
            {
                selectedBrush = null;
            }
            e.Handled = true;
        }

        private void mainCanvas_PreviewDragEnter(object sender, DragEventArgs e)
        {
            BarCode bc = e.Data.GetData(typeof(BarCode)) as BarCode;
            if (bc != null)
            {
                //ShowDraggedAdorner(e.GetPosition(this));
            }
            e.Handled = true;
        }

        private void mainCanvas_PreviewDragOver(object sender, DragEventArgs e)
        {
            BarCode bc = e.Data.GetData(typeof(BarCode)) as BarCode;
            if (bc != null)
            {
                //ShowDraggedAdorner(e.GetPosition(this));
            }
            e.Handled = true;
        }

       
      
        private void mainCanvas_PreviewDragLeave(object sender, DragEventArgs e)
        {
            RemoveDraggedAdorner();
            e.Handled = true;
        }

*/
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            this.mainCanvas.Background = Brushes.White;
            // Display Printer dialog for user to
            // choose the printer to output to.
            XpsPrintHelper printHelper = new XpsPrintHelper(this.mainCanvas);
            PrintDialog printDialog = printHelper.GetPrintDialog();
            if (printDialog == null)
                return;     //user selected cancel
            PrintQueue printQueue = printDialog.PrintQueue;
            printHelper.OnAsyncPrintChange += new XpsPrintHelper.AsyncPrintChangeHandler(AsyncPrintEvent);
            printHelper.PrintVisualAsync(printQueue);

            this.Topmost = true;
        }


        // -------------------------- AsyncPrintEvent -------------------------
        /// <summary>
        ///   Called as the asynchronous save proceeds.</summary>
        /// <param name="saveHelper"></param>
        /// <param name="asyncInformation">
        ///   Progress information about the asynchronous save.</param>
        private void AsyncPrintEvent(object printHelper, AsyncPrintEventArgs asyncInformation)
        {
            if (asyncInformation.Completed)
            {
                this.mainCanvas.Background = (Brush)App.Current.FindResource("canvasBrushResource");
                MessageBox.Show("标签打印完成", "打印完成");
            }
        }

    }
}
