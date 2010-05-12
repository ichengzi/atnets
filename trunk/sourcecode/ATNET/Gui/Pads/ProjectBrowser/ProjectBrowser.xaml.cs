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

using ATNET.Gui.Components;
using ATNET.Gui.Pads;
using ATNET.Project;
using ATNET.Services.ProjectService;
using ATNET.Gui.Pads.PropertyBrowser;

namespace ATNET.Gui.Pads.ProjectBrowser
{
    /// <summary>
    /// ProjectBrowser.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectBrowser : UserControl
    {
        private ExtTreeView treeView;
        /// <summary>
        ///树
        /// </summary>
        public ExtTreeView TreeView
        {
            get { return treeView; }
        }
        /// <summary>
        /// 树中选中的节点
        /// </summary>
        public AbstractProjectBrowserTreeNode SelectedTreeNode
        {
            get
            {
                return treeView.SelectedItem as AbstractProjectBrowserTreeNode;
            }
        }
        /// <summary>
        /// 树的根节点
        /// </summary>
        public AbstractProjectBrowserTreeNode RootNode
        {
            get
            {
                if (treeView.Items.Count > 0)
                {
                    return treeView.Items[0] as AbstractProjectBrowserTreeNode;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 选中的目录节点
        /// </summary>
        public DirectoryTreeNode SelectedDirectoryNode
        {
            get
            {
                ExtTreeNode selectedNode = treeView.SelectedItem as AbstractProjectBrowserTreeNode;
                DirectoryTreeNode node = null;
                while (selectedNode != null && node == null)
                {
                    node = selectedNode as DirectoryTreeNode;
                    selectedNode = selectedNode.ParentNode; 
                }
                return node;
            }
        }

        public ProjectBrowser()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// 显示工程的树
        /// </summary>
        /// <param name="project"></param>
        public void ViewProject(IProject project)
        {
            treeView = new ExtTreeView(new ExtTreeNode(null, project.Name));
            treeView.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(treeView_SelectedItemChanged);
            foreach (ATNET.Project.ProjectItem item in project.Items)
            {
                ExtTreeNode node = BuildNode(item);
                node.AddTo(treeView.BaseNode);
            }
            treeView.BaseNode.Refresh();
            mainGrid.Children.Add(treeView);
            Grid.SetRow(treeView, 1);
            Grid.SetColumn(treeView, 0);
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ExtTreeNode treeNode = e.NewValue as ExtTreeNode;
            Window1 mainWindow = CanvasDocumentService.MainWindow;
            CanvasDocumentService.SetDocumentSelected(((AbstractProjectBrowserTreeNode)treeNode).ProjectItem.CanvasDocument);
            CustomProperty property = new CustomProperty(CanvasDocumentService.CurrentCanvas);
            mainWindow.PropertyBrowser.SelectedObject = property;
        }
        /// <summary>
        /// 返回这个工程子项的生成的节点
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ExtTreeNode BuildNode(ATNET.Project.ProjectItem item)
        {
            ExtTreeNode node = new CustomTreeNode(null, item);
            DirectoryProjectItem directoryItem = item as DirectoryProjectItem;
            if (directoryItem != null)
            {
                node = new DirectoryTreeNode(null, item);
                if (directoryItem.Items.Count > 0)
                {
                    foreach (ATNET.Project.ProjectItem pitem in directoryItem.Items)
                    {
                        ExtTreeNode node1 = BuildNode(pitem);
                        node.Items.Add(node1);
                    }
                }
                return node as DirectoryTreeNode;
            }
            return node as CustomTreeNode;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ExtTreeNode baseNode = treeView.BaseNode;
            if (btn.Name == "btnExpand")
            {
                SetExpand(baseNode, true);
            }
            else if (btn.Name == "btnCollapse")
            {
                SetExpand(baseNode, false);
            }
            else if (btn.Name == "btnMoveUp")
            {
                treeView.Items.MoveCurrentToPrevious();
                treeView.Items.Refresh();
            }
            else
            {
             
            }

        }
        /// <summary>
        /// 设置ExTreeNode的IsExpand属性
        /// </summary>
        /// <param name="baseNode">ExTreeNode</param>
        /// <param name="isExpand">isExpand</param>
        private void SetExpand(ExtTreeNode baseNode,bool isExpand)
        {
            baseNode.IsExpanded = isExpand;
            foreach (ExtTreeNode node in baseNode.Items)
            {
                node.IsExpanded = isExpand;
                SetExpand(node, isExpand);
            }
        }
    }
}
