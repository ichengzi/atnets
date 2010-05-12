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
            foreach (ATNET.Project.ProjectItem item in project.Items)
            {
                ExtTreeNode node = BuildNode(item);
                node.AddTo(treeView.BaseNode);
            }
            treeView.BaseNode.Refresh();
            mainGrid.Children.Add(treeView);
            Grid.SetRow(treeView, 0);
            Grid.SetColumn(treeView, 0);
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
    }
}
