using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using ATNET.Gui.Components;
using ATNET.Project;

namespace ATNET.Gui.Pads
{
    public abstract class AbstractProjectBrowserTreeNode:ExtTreeNode
    {
        private IProject project;
        public IProject Project
        {
            get { return project; }
        }

        public AbstractProjectBrowserTreeNode(Image icon, string title)
            : base(icon, title)
        {

        }
    }
}
