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
 
        }

        public DirectoryProjectItem(IProject project, ItemType itemType)
            : base(project, itemType)
        { 

        }

        public DirectoryProjectItem(IProject project, ItemType itemType,string name)
            : base(project, itemType)
        {
            this.Name = name;
        }


        private IList<ProjectItem> items = new List<ProjectItem>();
        public IList<ProjectItem> Items
        {
            get { return items; }
        }

        public void AddProjectItem(ProjectItem item)
        {
            items.Add(item);
        }
    }
}
