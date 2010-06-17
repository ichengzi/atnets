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
            Button btn = sender as Button;
            selectedBrush = btn;
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
                mainCanvas.Children.Add(element);
                Canvas.SetTop(element, e.GetPosition(this.mainCanvas).Y);
                Canvas.SetLeft(element, e.GetPosition(this.mainCanvas).X);
            }
            dragStartPoint = null;
            selectedBrush = null;

            RemoveDraggedAdorner();

            //AdornerLayer adorberLayer = AdornerLayer.GetAdornerLayer(bc);
            //if (adorberLayer != null)
            //{
            //    LabelAdorner adorner = new LabelAdorner(bc);
            //    if (adorner != null)
            //    {
            //        adorberLayer.Add(adorner);
            //    }
            //}
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
            if (dragStartPoint.HasValue && e.LeftButton == MouseButtonState.Pressed)
            {
                if (IsMovementBigEnough(dragStartPoint.Value, e.GetPosition(this)))
                {
                    Button btn = selectedBrush as Button;
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
                        DragDrop.DoDragDrop(this.toolBar, dataObject, DragDropEffects.All);
                    }
                    catch { }
                }
            }
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

        private void ShowDraggedAdorner(Point currentPoint)
        {
            if (this.draggedAdorner == null)
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(this.mainCanvas);
                DataTemplate template = new DataTemplate();
                FrameworkElementFactory fef = new FrameworkElementFactory(typeof(Button));
                //fef.SetValue(Button.WidthProperty, 100);
                //fef.SetValue(Button.HeightProperty, 50);
                //fef.SetValue(Button.BackgroundProperty, Brushes.Red);
                template.VisualTree = fef;
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

        private void mainCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void mainCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void mainCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void CancelSelectedItem()
        {
            foreach (UIElement element in this.mainCanvas.Children)
            {
                if (element is BarCode)
                {
 
                }
            }
        }

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
                MessageBox.Show(asyncInformation.Status, "打印完成");
            }
        }

    }
}
