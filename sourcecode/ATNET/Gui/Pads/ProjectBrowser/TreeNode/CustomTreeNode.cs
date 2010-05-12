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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            //添加CanvasDocument
            CanvasDocumentService.AddCanvasDocument(projectItem.CanvasDocument);
        }
    }
}
