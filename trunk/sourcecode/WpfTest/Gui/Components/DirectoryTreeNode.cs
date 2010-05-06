using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WpfTest.Gui.Components
{
    public class DirectoryTreeNode:AbstractProjectBrowserTreeNode
    {
        public DirectoryTreeNode(Image icon, string title)
            : base(icon, title)
        {
 
        }
    }
}
