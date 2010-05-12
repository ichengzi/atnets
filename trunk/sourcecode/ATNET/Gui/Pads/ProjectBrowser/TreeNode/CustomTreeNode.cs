using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ATNET.Project;
using ATNET.Services.ProjectService;
using System.Windows.Input;

namespace ATNET.Gui.Pads
{
    /// <summary>
    /// 树节点，不包含子节点的节点类
    /// </summary>
    public class CustomTreeNode:AbstractProjectBrowserTreeNode
    {
        public CustomTreeNode(Image icon, ProjectItem projectItem)
            : base(icon,projectItem.Name)
        {
            this.projectItem = projectItem;
        }

        protected override void ExtTreeNode_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            base.ExtTreeNode_Selected(sender, e);
            //选中节点的操作
            CanvasDocumentService.AddCanvasDocument(projectItem.CanvasDocument);
        }

        protected override void ExtTreeNode_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            base.ExtTreeNode_MouseDoubleClick(sender, e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
               
            }
        }
    }
}
