using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ATNET.Gui.Pads
{
    /// <summary>
    /// 包含子节点的树节点类
    /// </summary>
    public class DirectoryTreeNode:AbstractProjectBrowserTreeNode
    {
        public DirectoryTreeNode(Image icon, string title)
            : base(icon, title)
        {
 
        }
    }
}
