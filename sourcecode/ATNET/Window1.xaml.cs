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


namespace ATNET
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        /// <summary>
        /// 当前正在使用的CanvaDocument对象
        /// </summary>
        private CanvasDocument currentCanvasDocument = new CanvasDocument();
        /// <summary>
        /// 当前正在使用的Canvas对象
        /// </summary>
        private DesignerCanvas currentCanvas = new DesignerCanvas();
        /// <summary>
        /// 当前被选中的DesignerItem对象
        /// </summary>
        private DesignerItem currentItem = new DesignerItem();

        public Window1()
        {
            RegeditCommands();
            InitializeComponent();

            InitMainWindowConfig();

            Title = "ATNET 机房管理系统 - Softart";
            this.ContentRendered += new EventHandler(Window1_ContentRendered);

            //this.IsEnabled = false;

        }


        private bool InitMainWindowConfig()
        {
            //从配置文件中读出当前用户的界面风格
            dockingManager.Show(toolWindow, AvalonDock.DockableContentState.Docked);
            return true;
        }

        private void Window1_ContentRendered(object sender, EventArgs e)
        {
            //StartWindow startWindow = new StartWindow();
            //startWindow.ShowDialog();

            //project = ATNetProject.GetProjectInstance("", null);
            //if (project.Status == ProjectStatus.New) {
            //    dockingManager.MainDocumentPane.Items.Add(project.ProjectDocument);
            //    project.ProjectDockingManager = dockingManager;
            //    projectWindow.Content = project.ItemTreeView;
            //    project.Status = ProjectStatus.Work;
            //}
            //this.IsEnabled = true;
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
                if (currentCanvas != null)
                {
                    currentCanvas.CoordinateRate = rate;
                }
            }
        }

        private void addNewProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //添加新的工程
            //“新工程”窗口
            NewProjectWindow newProjWindow = new NewProjectWindow();
            newProjWindow.ShowDialog();
            LoadProject();
        }
        /// <summary>
        /// 载入Project
        /// </summary>
        /// <returns></returns>
        private bool LoadProject()
        {

            //创建了新工程的xml文件，创建了Project的实例
            if (ATNetProject.ProjectInstance != null)
            {
                //将新工程的实例的画布添加到主界面上
                dockingManager.MainDocumentPane.Items.Add(ATNetProject.ProjectInstance.ProjectDocument);
                //将工程的TreeView视图添加到主界面上
                projectWindow.Content = ATNetProject.ProjectInstance.ItemTreeView;
                ((TreeView)projectWindow.Content).SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(Window1_SelectedItemChanged);
                toolWindow.DockableStyle = AvalonDock.DockableStyle.Dockable;
                toolBoxPanel.Visibility = Visibility.Visible;
                //将当前工程的画布添加到“属性”窗口
                propertyGrid.SelectedObject = currentCanvas;
                ChangeCurrentDocument();
                return true;
            }
            return false;
        }

        private void Window1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            propertyGrid.SelectedObject = ATNetProject.ProjectInstance;
        }

        private void addNewCanvas_Click(object sender, RoutedEventArgs e)
        {
            //CanvasDocument newDocument = new CanvasDocument();
            //newDocument.Title = "Page";
            //newDocument.InfoTip = "Test Page";
            //newDocument.ContentTypeDescription = "Sample Page";
            //dockingManager.MainDocumentPane.Items.Add(newDocument);
            //ProjectItem item=new ProjectItem("page1",newDocument);
            //project.AddProjectItem(item);
            //dockingManager.MainDocumentPane.SelectedIndex = dockingManager.MainDocumentPane.Items.Count - 1;
            //ChangeCurrentDocument();
        }
        /// <summary>
        /// 改变当前的文档信息
        /// </summary>
        /// <returns></returns>
        private bool ChangeCurrentDocument()
        {
            currentCanvasDocument = dockingManager.MainDocumentPane.SelectedItem as CanvasDocument;
            currentCanvas = currentCanvasDocument.FindName("mainCanvas") as DesignerCanvas;
            currentCanvas.PreviewMouseDown += new MouseButtonEventHandler(currentCanvas_PreviewMouseDown);
            currentItem = (DesignerItem)currentCanvas.CurrentItem;
            if (currentItem == null)
            {
                propertyGrid.SelectedObject = currentCanvas;
                currentCanvas.SelectedItemChangedEvent += new DesignerCanvas.SelectedItemChangedEventHandle(currentCanvas_SelectedItemChangedEvent);
                currentCanvas.PreviewMouseMove += new MouseEventHandler(currentCanvas_PreviewMouseMove);
            }
            else
            {
                propertyGrid.SelectedObject = currentItem;
            }
            statusBar.DataContext = currentCanvas;
            return true;
        }

        private void currentCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            ScrollViewer scroll = currentCanvas.Parent as ScrollViewer;
            RulerRectangle vRect = scroll.Template.FindName("verticalRuler", scroll) as RulerRectangle;
            //vRect.RulerLine = e.GetPosition(currentCanvas);
            RulerRectangle hRect = scroll.Template.FindName("horizontalRuler", scroll) as RulerRectangle;
            //hRect.RulerLine = e.GetPosition(currentCanvas);
        }

        private void currentCanvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //选中Canvas，将Canvas赋值给属性窗口
                propertyGrid.SelectedObject = currentCanvas;
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                //生成Canvas右键菜单
                ContextMenu canvasContextMenu = this.FindResource("canvasContextMenu") as ContextMenu;
                if (canvasContextMenu != null)
                {
                    DesignerCanvas canvas = sender as DesignerCanvas;
                    canvas.ContextMenu = canvasContextMenu;
                }
            }
        }

        private void currentItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //designerItem的右键菜单
            ContextMenu itemContextMenu = this.FindResource("itemContextMenu") as ContextMenu;
            if (itemContextMenu != null)
            {
                DesignerItem item = sender as DesignerItem;
                item.ContextMenu = itemContextMenu;
            }
        }

        private void currentCanvas_SelectedItemChangedEvent(object sender, ISelectable item)
        {
            currentItem = (DesignerItem)item;
            propertyGrid.SelectedObject = currentItem;
            currentItem.PreviewMouseRightButtonDown += new MouseButtonEventHandler(currentItem_PreviewMouseRightButtonDown);
        }

        private void openProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "projects";
            openFileDialog.DefaultExt = "atnprj";
            openFileDialog.Filter = "Atnet Project files (*.atnprj)|*.atnprj";
            openFileDialog.ShowDialog();
            ProjectService.LoadProject(openFileDialog.FileName);
            LoadProject();
        }
    }
}
