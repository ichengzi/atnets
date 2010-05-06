using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WpfTest.Gui.Components
{
    public class CustomTreeNode:AbstractProjectBrowserTreeNode
    {
        public CustomTreeNode(Image icon, string title)
            : base(icon,title)
        {
 
        }
    }
}
