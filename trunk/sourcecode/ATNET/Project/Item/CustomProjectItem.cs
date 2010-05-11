using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATNET.Project
{
    /// <summary>
    /// 不包括子项的工程子项类
    /// </summary>
    public class CustomProjectItem:ProjectItem
    {
        public CustomProjectItem(IProject project)
            : base(project)
        {
 
        }

        public CustomProjectItem(IProject project, ItemType itemType)
            : base(project, itemType)
        {

        }

        public CustomProjectItem(IProject project, ItemType itemType, string name):base(project,itemType)
        {
            this.Name = name;
        }
    }
}
