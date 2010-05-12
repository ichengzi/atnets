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
    /// 包含子节点的树节点类
    /// </summary>
    public class DirectoryTreeNode:AbstractProjectBrowserTreeNode
    {
        public DirectoryTreeNode(Image icon, ProjectItem projectItem)
            : base(icon, projectItem.Name)
        {
            this.projectItem = projectItem;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            //添加CnavasDocument
            CanvasDocumentService.AddCanvasDocument(projectItem.CanvasDocument);
        }

    }
}
