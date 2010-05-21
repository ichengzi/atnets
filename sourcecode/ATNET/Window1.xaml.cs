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
using System.Windows.Xps;
using System.Printing;
using Microsoft.Win32;
using System.IO;
using SoftArt.WPF.Styles.Common;
using System.Windows.Threading;
using SoftArt.WPF.Graph;
using System.Windows.Forms.Integration;

using ATNET.Project;
using ATNET.Services.ProjectService;
using ATNET.Gui.Pads.ProjectBrowser;
using AvalonDock;
using ATNET.Gui.Pads.PropertyBrowser;
using ATNET.Services.MenuService;


namespace ATNET
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            RegeditCommands();
            InitializeComponent();

            InitMainWindowConfig();

            Title = "ATNET 机房管理系统 - Softart";
            this.ContentRendered += new EventHandler(Window1_ContentRendered);
        }

        private void DockingManager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.DockingManager.SelectedItem != null)
            {
                CanvasDocumentService.SetDocumentSelected((CanvasDocument)this.DockingManager.SelectedItem);
            }
        }
        /// <summary>
        /// 获取Document的管理类
        /// </summary>
        public DocumentPane DockingManager
        {
            get { return dockingManager.MainDocumentPane; }
        }
        /// <summary>
        /// 获取属性窗口
        /// </summary>
        public PropertyBrowser PropertyBrowser
        {
            get { return (ATNET.Gui.Pads.PropertyBrowser.PropertyBrowser)winFormHost.Child; }
        }

        private bool InitMainWindowConfig()
        {
            //从配置文件中读出当前用户的界面风格
            dockingManager.Show(toolWindow, AvalonDock.DockableContentState.Docked);
            return true;
        }

        private void Window1_ContentRendered(object sender, EventArgs e)
        {
            MenuService.MenuServiceInit();
            PropertyBrowser propertyBrowser = new PropertyBrowser();
            winFormHost.Child = propertyBrowser;

            this.DockingManager.SelectionChanged += new SelectionChangedEventHandler(DockingManager_SelectionChanged);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //PrintDialog pDialog = new PrintDialog();
            //if ((bool)pDialog.ShowDialog())
            //{
            //    XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(pDialog.PrintQueue);
            //    VisualsToXpsDocument vToXpsD = (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();
            //    vToXpsD.Write(mainCanvas);
            //    vToXpsD.EndBatchWrite();
            //}

            //SaveFileDialog fileDialog = new SaveFileDialog();
            //fileDialog.DefaultExt = "*.png";
            //if ((bool)fileDialog.ShowDialog())
            //{
            //    int height = (int)mainCanvas.ActualHeight;
            //    int width = (int)mainCanvas.ActualWidth;

            //    RenderTargetBitmap bitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            //    bitmap.Render(mainCanvas);
            //    BitmapEncoder encoder = new PngBitmapEncoder();
            //    encoder.Frames.Add(BitmapFrame.Create(bitmap));
            //    using (Stream stream = File.Create(fileDialog.FileName))
            //    {
            //        encoder.Save(stream);
            //    }
            //}

        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;
            var stackPanel = expander.Parent as StackPanel;
            if (stackPanel != null)
            {
                foreach (var child in stackPanel.Children)
                {
                    if (child is Expander)
                    {
                        if (((Expander)child).Header != expander.Header)
                        {
                            ((Expander)child).IsExpanded = false;
                        }
                    }
                }
            }
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboxRate.SelectedValue != null)
            {
                ComboBoxItem item = comboxRate.SelectedValue as ComboBoxItem;
                var rate = double.Parse(item.Tag.ToString());
            }
        }

        private void addNewProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //添加新的工程
            //“新工程”窗口
            NewProjectWindow newProjWindow = new NewProjectWindow();
            newProjWindow.ShowDialog();
            ShowProjectTree();
        }
        /// <summary>
        /// 在主窗体上显示Project的Tree
        /// </summary>
        /// <returns></returns>
        private void ShowProjectTree()
        {
            ProjectBrowser projectBrowser = new ProjectBrowser();
            projectBrowser.ViewProject(ProjectService.CurrentProject);
            projectWindow.Content = projectBrowser;
        }

        private void openProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //打开已有的工程
            //“打开工程”窗口
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "projects";
            openFileDialog.DefaultExt = "atnprj";
            openFileDialog.Filter = "Atnet Project files (*.atnprj)|*.atnprj";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null && openFileDialog.FileName != "") 
            {
                ProjectService.LoadProject(openFileDialog.FileName);
                ShowProjectTree();
            }
            
        }
    }
}
