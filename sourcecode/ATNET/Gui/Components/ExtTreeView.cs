using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ATNET.Gui.Components
{
    public class ExtTreeView:TreeView
    {
        private ExtTreeNode baseItem;
        /// <summary>
        /// 树的根节点
        /// </summary>
        public ExtTreeNode BaseItem
        {
            get { return baseItem; }
        }

        public ExtTreeView(ExtTreeNode item)
        {
            this.baseItem = item;
            this.Items.Add(baseItem);
        }
    }
}
