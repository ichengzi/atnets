using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ATNET.Project;
using ATNET.Services.ProjectService;

namespace ATNET.Gui.Pads
{
    /// <summary>
    /// 包含子节点的树节点类
    /// </summary>
    public class DirectoryTreeNode:AbstractProjectBrowserTreeNode
    {
        public DirectoryTreeNode(Image icon, ProjectItem projectItem)
            : base(icon, projectItem.Name)
        {
            this.projectItem = projectItem;
        }

        protected override void ExtTreeNode_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            base.ExtTreeNode_Selected(sender, e);
            //选中节点的操作
            CanvasDocumentService.AddCanvasDocument(((DirectoryProjectItem)projectItem).CanvasDocument);
        }

    }
}
