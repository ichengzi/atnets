using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ATNET.Gui.Components
{
    public class ExtTreeView:TreeView
    {
        private ExtTreeNode baseNode;
        /// <summary>
        /// 树的根节点
        /// </summary>
        public ExtTreeNode BaseNode
        {
            get { return baseNode; }
        }

        public ExtTreeView(ExtTreeNode item)
        {
            if (base.Items.Count == 0)
            {
                this.baseNode = item;
                this.Items.Add(baseNode);
            }
        }
    }
}
