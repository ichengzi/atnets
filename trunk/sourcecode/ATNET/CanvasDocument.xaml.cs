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
using SoftArt.WPF.Graph;
using ATNET.Services.MenuService;

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
            this.Loaded += new RoutedEventHandler(CanvasDocument_Loaded);
        }

        private void CanvasDocument_Loaded(object sender, RoutedEventArgs e)
        {
            this.mainCanvas.ContextMenu = (ContextMenu)MenuService.ContextMenuResource["canvas"];
            this.mainCanvas.SelectedItemChangedEvent += new DesignerCanvas.SelectedItemChangedEventHandle(mainCanvas_SelectedItemChangedEvent);
        }

        private void mainCanvas_SelectedItemChangedEvent(object sender, ISelectable item)
        {
            DesignerItem designerItem = item as DesignerItem;
            if (designerItem != null)
            {
                designerItem.ContextMenu=(ContextMenu)MenuService.ContextMenuResource["item"];
            }
        }
        /// <summary>
        /// 获取Document中的Canvas
        /// </summary>
        public DesignerCanvas Canvas
        {
            get { return mainCanvas; }
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
