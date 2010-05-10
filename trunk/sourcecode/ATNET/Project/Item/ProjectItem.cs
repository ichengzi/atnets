/*
 * Created by SharpDevelop.
 * User: eric
 * Date: 2010/5/4
 * Time: 22:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace ATNET.Project
{
	/// <summary>
	/// Description of ProjectItem.
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
        }
        protected ProjectItem(IProject project, ItemType type)
        {
            this.project = project;
            this.itemType = type;
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
