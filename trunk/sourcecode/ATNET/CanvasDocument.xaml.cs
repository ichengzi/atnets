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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AvalonDock;
using SoftArt.WPF.Styles.Common;

namespace ATNET
{
    /// <summary>
    /// CanvasDocument.xaml 的交互逻辑
    /// </summary>
    public partial class CanvasDocument : DocumentContent
    {
        public CanvasDocument()
        {
            InitializeComponent();
        }

        private void mainCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = e.GetPosition(mainCanvas);
            RulerRectangle horizontalRect = mainScrollViewer.Template.FindName("horizontalRuler", mainScrollViewer) as RulerRectangle;
            //horizontalRect.RulerLine = mousePoint;
            //horizontalRect.InvalidateVisual();

            RulerRectangle verticalRect = mainScrollViewer.Template.FindName("verticalRuler", mainScrollViewer) as RulerRectangle;
            //verticalRect.RulerLine = mousePoint;
            //verticalRect.InvalidateVisual();
        }
    }
}
