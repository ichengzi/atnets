using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATNET
{
    /// <summary>
    /// 工程的子项类
    /// </summary>
    public class ProjectItem
    {
        private string itemName;
        private Guid itemGuid;
        private CanvasDocument itemDocument;
        private ProjectItemType itemType;
        private List<ProjectItem> projectItemList = new List<ProjectItem>();
        /// <summary>
        /// 子项的名称
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        /// <summary>
        /// 子项的GUID
        /// </summary>
        public Guid ItemGuid
        {
            get { return itemGuid; }
        }
        /// <summary>
        /// 工程子项的类别
        /// </summary>
        public ProjectItemType ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }
        /// <summary>
        /// 工程子项的子项
        /// </summary>
        public List<ProjectItem> ProjectItemList
        {
            get { return projectItemList; }
        }
        /// <summary>
        /// 子项的画布
        /// </summary>
        public CanvasDocument ItemDocument
        {
            get { return itemDocument; }
        }

        public ProjectItem(string name, CanvasDocument itemDocument)
        {
            this.itemName = name;
            this.itemDocument = itemDocument;
            this.itemGuid = new Guid();
        }

        public bool AddNewProjectItem(ProjectItem newItem)
        {
            projectItemList.Add(newItem);
            return true;
        }
    }

    public enum ProjectItemType
    {
        /// <summary>
        /// 楼宇
        /// </summary>
        Building,
        /// <summary>
        /// 楼层
        /// </summary>
        Floor,
        /// <summary>
        /// 机房
        /// </summary>
        Room,
        /// <summary>
        /// 机柜
        /// </summary>
        Cabinet
    }
}
