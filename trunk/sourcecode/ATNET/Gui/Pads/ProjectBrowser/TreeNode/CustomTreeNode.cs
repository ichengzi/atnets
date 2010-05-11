using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ATNET.Gui.Pads
{
    /// <summary>
    /// 树节点，不包含子节点的节点类
    /// </summary>
    public class CustomTreeNode:AbstractProjectBrowserTreeNode
    {
        public CustomTreeNode(Image icon, string title)
            : base(icon,title)
        {
 
        }
    }
}
