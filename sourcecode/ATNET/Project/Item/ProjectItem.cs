
using System;
using System.ComponentModel;

namespace ATNET.Project
{
	/// <summary>
	/// 工程子项类.
	/// </summary>
    public abstract class ProjectItem : IDisposable, ICloneable
    {
        private IProject project;
        private ItemType itemType;
        private string name;

        private bool isDisposed;

        protected ProjectItem(IProject project)
        {
            if (project == null)
            {
                throw new ArgumentNullException("project");
            }
            this.project = project;
            this.canvasDocument = new CanvasDocument();
            this.canvasDocument.Name = this.Name;
            this.canvasDocument.Title = this.Name;
        }
        protected ProjectItem(IProject project, ItemType type)
        {
            this.project = project;
            this.itemType = type;
            this.canvasDocument = new CanvasDocument();
            this.canvasDocument.Name = this.Name;
            this.canvasDocument.Title = this.Name;
        }

        protected ProjectItem(IProject project, ItemType type,string name)
        {
            this.project = project;
            this.itemType = type;
            this.name = name;
            this.canvasDocument = new CanvasDocument();
            this.canvasDocument.Name = this.Name;
            this.canvasDocument.Title = this.Name;
        }

        protected CanvasDocument canvasDocument;
        /// <summary>
        /// 获取目录型工程子项包含的CanvasDocument对象
        /// </summary>
        public CanvasDocument CanvasDocument
        {
            get { return canvasDocument; }
        }

        [Browsable(false)]
        public IProject Project
        {
            get { return this.project; }
        }
        [Browsable(false)]
        public ItemType ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }
        [Browsable(false)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public bool IsDisposed
        {
            get { return isDisposed; }
        }

        public virtual void Dispose()
        {
            isDisposed = true;
        }

        public object Clone()
        {
            return this.Clone();
        }

    }
}
