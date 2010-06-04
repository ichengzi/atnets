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

namespace ATNET.Gui.Windows
{
    /// <summary>
    /// LabelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LabelWindow : Window
    {
        public LabelWindow()
        {
            InitializeComponent();
            this.Closed += new EventHandler(LabelWindow_Closed);
        }
        private Point? dragStartPoint = null;
        private BarCode barCode;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dragStartPoint = new Point?(Mouse.GetPosition((Button)sender));
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            BarCode bc = e.Data.GetData(typeof(BarCode)) as BarCode;
            if (bc == null) return;

            mainCanvas.Children.Add(bc);
            Canvas.SetTop(bc, e.GetPosition(this.mainCanvas).Y);
            Canvas.SetLeft(bc, e.GetPosition(this.mainCanvas).X);

            dragStartPoint = null;
        }

        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (dragStartPoint.HasValue)
            {
                DataObject dataObject = new DataObject();
                this.barCode = new BarCode("1234567");
                dataObject.SetData(this.barCode);
                DragDrop.DoDragDrop((Button)sender, dataObject, DragDropEffects.Copy);
            }
        }

    }
}
