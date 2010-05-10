using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ATNET.Gui.Components
{
    /// <summary>
    /// 树节点
    /// </summary>
    public class ExtTreeNode:TreeViewItem
    {
        private string contextMenuAddInTreePath;
        public virtual string ContextMenuAddInTreePath
        {
            get { return contextMenuAddInTreePath; }
            set { contextMenuAddInTreePath = value; }
        }

        private TreeViewItem internalParent;
        public TreeViewItem InternalParent
        {
            get { return internalParent; }
        }

        public ExtTreeNode ParentNode
        {
            get
            {
                ExtTreeNode parentNode = this.Parent as ExtTreeNode;
                if (parentNode != null)
                {
                    return parentNode;
                }
                return null;
            }
        }

        public ExtTreeNode()
        {
            
        }

        private Image icon;
        /// <summary>
        /// 树节点的图片
        /// </summary>
        public Image Icon
        {
            get { return icon; }
        }

        private string title;
        /// <summary>
        /// 树节点的标题
        /// </summary>
        public string Title
        {
            get { return title; }
        }

        public ExtTreeNode(Image icon, string title)
        {
            this.icon = icon;
            this.title = title;
            icon.Width = 16;
            icon.Height = 16;
            TextBlock tb = new TextBlock();
            tb.Text = title;
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.Children.Add(icon);
            grid.Children.Add(tb);
            Grid.SetColumn(icon, 0);
            Grid.SetColumn(tb, 1);
            this.Header = grid;
        }
        /// <summary>
        /// 设置树节点的显示图标
        /// </summary>
        /// <param name="imageUrl"></param>
        public void SetIcon(string imageUrl)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imageUrl, UriKind.Relative);
            bitmap.EndInit();
            this.icon.Source = bitmap;
        }
        /// <summary>
        /// 设置树节点的标题
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// 将当前节点添加到其他节点上去
        /// </summary>
        /// <param name="item"></param>
        public void AddTo(TreeViewItem item)
        {
            internalParent = item;
            AddTo(item.Items);
        }

        public void AddTo(TreeView treeView)
        {
            internalParent = null;
            AddTo(treeView.Items);
        }

        /// <summary>
        /// 将当前子项添加到节点列表中
        /// </summary>
        /// <param name="items"></param>
        private void AddTo(ItemCollection items)
        {
            items.Add(this);
            Refresh();
        }
        /// <summary>
        /// 将当前节点添加到其他节点的某个位置
        /// </summary>
        /// <param name="index">位置索引</param>
        /// <param name="parentItem">添加的父节点</param>
        public void Insert(int index, TreeViewItem parentItem)
        {
            internalParent = parentItem;
            parentItem.Items.Insert(index, this);
            Refresh();
        }
        /// <summary>
        /// 将当前节点添加到树的某个位置
        /// </summary>
        /// <param name="index">位置索引</param>
        /// <param name="parentView">树</param>
        public void Insert(int index, TreeView parentView)
        {
            internalParent = null;
            parentView.Items.Insert(index, this);
            Refresh();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public virtual void Refresh()
        {
            foreach (TreeViewItem item in this.Items)
            {
                if (item is ExtTreeNode)
                {
                    ((ExtTreeNode)item).Refresh();
                }
            }
        }
    }
}
