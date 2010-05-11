using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using ATNET.Gui.Components;
using ATNET.Project;

namespace ATNET.Gui.Pads
{
    /// <summary>
    /// 应用于Project的树节点抽象类
    /// </summary>
    public abstract class AbstractProjectBrowserTreeNode:ExtTreeNode
    {
        protected IProject project;
        /// <summary>
        /// 节点所属的工程
        /// </summary>
        public IProject Project
        {
            get { return project; }
        }

        protected ProjectItem projectItem;
        /// <summary>
        /// 节点所对应的工程子项
        /// </summary>
        public ProjectItem ProjectItem
        {
            get { return projectItem; }
        }

        public AbstractProjectBrowserTreeNode(Image icon, string title)
            : base(icon, title)
        {
            
        }
    }
}
