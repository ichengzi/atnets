using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ATNET.Project
{
    /// <summary>
    /// 包含子项的工程子项类
    /// </summary>
    public class DirectoryProjectItem:ProjectItem
    {
        public DirectoryProjectItem(IProject project)
            : base(project)
        {
            this.canvasDocument = new CanvasDocument();
            this.canvasDocument.Name =  this.Name;
            this.canvasDocument.Title = this.Name;
        }

        public DirectoryProjectItem(IProject project, ItemType itemType)
            : base(project, itemType)
        {
            this.canvasDocument = new CanvasDocument();
            this.canvasDocument.Name =  this.Name;
            this.canvasDocument.Title = this.Name;
        }

        public DirectoryProjectItem(IProject project, ItemType itemType,string name)
            : base(project, itemType)
        {
            this.Name = name;
            this.canvasDocument = new CanvasDocument();
            this.canvasDocument.Name =  this.Name;
            this.canvasDocument.Title = this.Name;
        }


        private IList<ProjectItem> items = new List<ProjectItem>();
        /// <summary>
        /// 获取工程子项包含的子项
        /// </summary>
        public IList<ProjectItem> Items
        {
            get { return items; }
        }

        private CanvasDocument canvasDocument;
        /// <summary>
        /// 获取目录型工程子项包含的CanvasDocument对象
        /// </summary>
        public CanvasDocument CanvasDocument
        {
            get { return canvasDocument; }
        }

        public void AddProjectItem(ProjectItem item)
        {
            items.Add(item);
        }
    }
}
