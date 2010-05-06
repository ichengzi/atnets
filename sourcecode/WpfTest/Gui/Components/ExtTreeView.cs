using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WpfTest.Gui.Components
{
    public class ExtTreeView:TreeView
    {
        private TreeViewItem baseItem;
        public TreeViewItem BaseItem
        {
            get { return baseItem; }
        }

        public ExtTreeView(TreeViewItem item)
        {
            this.baseItem = item;
            this.Items.Add(baseItem);
        }
    }
}
