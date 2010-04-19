using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using AvalonDock;

namespace ATNET
{
    /// <summary>
    /// ATNET的工程类
    /// </summary>
    internal class ATNetProject
    {
        private string projectName;
        private Guid projectGuid;
        private ATNETProjectType projectType;
        private string configFile;
        private List<ProjectItem> projectItemList = new List<ProjectItem>();
        protected CanvasDocument projectDocument;
        private ProjectStatus status = ProjectStatus.None;
        private TreeView itemTreeView = new TreeView();
        private DockingManager projectDockingManager;
        /// <summary>
        /// Project的名字
        /// </summary>
        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }
        }
        /// <summary>
        /// Project的GUID
        /// </summary>
        public Guid ProjectGuid
        {
            get { return this.projectGuid; }
        }
        /// <summary>
        /// Project的类型
        /// </summary>
        public ATNETProjectType ProjectType
        {
            get { return this.projectType; }
            set { this.projectType = value; }
        }
        /// <summary>
        /// Project的配置文件
        /// </summary>
        public string ConfigFile
        {
            get { return this.configFile; }
            set { this.configFile = value; }
        }
        /// <summary>
        /// Project工程的子项
        /// </summary>
        public List<ProjectItem> ProjectItemList
        {
            get { return projectItemList; }
        }
        /// <summary>
        /// Project工程包含的画布
        /// </summary>
        public CanvasDocument ProjectDocument
        {
            get { return projectDocument; }
            set { projectDocument = value; }
        }
        /// <summary>
        /// 工程当前的状态
        /// </summary>
        public ProjectStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// 工程的TreeView视图
        /// </summary>
        public TreeView ItemTreeView
        {
            get { return itemTreeView; }
        }

        public DockingManager ProjectDockingManager
        {
            get { return projectDockingManager; }
            set { projectDockingManager = value; }
        }

        public static ATNetProject ProjectInstance
        {
            get { return instance; }
        }

        private static object helper = new object();
        private static ATNetProject instance = null;

        private ATNetProject(string name, CanvasDocument projectDocument)
        {
            this.projectGuid = Guid.NewGuid();
            this.projectName = name;
            this.projectDocument = projectDocument;
            this.projectDocument.Title = "工程'" + name + "'";
            this.projectDocument.Name = name;
            TreeViewItem baseItem = new TreeViewItem();
            baseItem.Header = "工程'" + name + "'";
            baseItem.Name = name;
            this.itemTreeView.Items.Add(baseItem);
            this.AddNewProjectItemCompletedEvent += new AddNewProjectItemCompletedEventHandler(ATNetProject_AddNewDocumentCompletedEvent);
        }

        protected void ATNetProject_AddNewDocumentCompletedEvent(object sender, ProjectItem newItem)
        {
            TreeViewItem item = itemTreeView.Items[0] as TreeViewItem;
            TreeViewItem addItem = new TreeViewItem();
            addItem.Header = newItem.ItemName;
            int index = item.Items.Add(addItem);
            addItem.IsSelected = true;
        }
        /// <summary>
        /// 建立一个新的工程
        /// </summary>
        /// <param name="name">工程名称</param>
        /// <param name="projectDocument">工程所对应的Canvas</param>
        /// <returns></returns>
        public static ATNetProject GetProjectInstance(string name, CanvasDocument projectDocument)
        {
            lock (helper)
            {
                if (instance == null)
                {
                    lock (helper)
                    {
                        instance = new ATNetProject(name, projectDocument);
                        return instance;
                    }
                }
            }
            return instance;
        }
        /// <summary>
        /// 添加新的工程子项的委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="newItem"></param>
        private delegate void AddNewProjectItemCompletedEventHandler(object sender, ProjectItem newItem);
        /// <summary>
        /// 添加新的工程子项的事件
        /// </summary>
        private event AddNewProjectItemCompletedEventHandler AddNewProjectItemCompletedEvent;
        protected void OnAddNewProjectItemCompleted(ProjectItem newItem)
        {
            if (AddNewProjectItemCompletedEvent != null)
            {
                AddNewProjectItemCompletedEvent(this, newItem);
            }
        }
        /// <summary>
        /// 添加新的工程子项
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public bool AddProjectItem(ProjectItem newItem)
        {
            projectItemList.Add(newItem);
            OnAddNewProjectItemCompleted(newItem);
            return true;
        }

        public static bool SaveProjectFile(string saveFielName)
        {
            int index = saveFielName.LastIndexOf("\\");
            string fileName = saveFielName.Substring(index + 1);
            int index1 = fileName.IndexOf(".");
            fileName = fileName.Substring(0, index1);
            ATNetProject project = GetProjectInstance(fileName, new CanvasDocument());
            XElement xElement = new XElement("Project",
                new XElement("Name", project.ProjectName),
                new XElement("GUID", project.ProjectGuid),
                new XElement("ProjectType", project.ProjectType),
                new XElement("ProjectItems", ""));
            xElement.Save(saveFielName);
            project.Status = ProjectStatus.New;
            return true;
        }
        /// <summary>
        /// 保存工程文件
        /// </summary>
        /// <param name="saveFielName">保存工程文件的文件名</param>
        /// <param name="fielPath">保存的路径</param>
        /// <returns>保存是否成功</returns>
        public static bool SaveProjectFile(string saveFielName, string fielPath)
        {
            ATNetProject project = GetProjectInstance(saveFielName, new CanvasDocument());
            XElement xElement = new XElement("Project",
                new XElement("Name", project.ProjectName),
                new XElement("GUID", project.ProjectGuid),
                new XElement("ProjectType", project.ProjectType),
                new XElement("ProjectItems", ""));
            xElement.Save(fielPath + "\\" + saveFielName + ".atnprj");
            project.Status = ProjectStatus.New;
            return true;
        }
        /// <summary>
        /// 打开工程文件
        /// </summary>
        /// <param name="openFielName">打开工程的文件</param>
        /// <returns>打开是否成功</returns>
        public static bool OpenProjectFile(string openFielName)
        {

            XElement root = XElement.Load(@openFielName);
            IEnumerable<XElement> element = from el in root.Elements() select el;
           
            ATNetProject project = GetProjectInstance(element.Where(el => el.Name == "Name").First<XElement>().Value, new CanvasDocument());
            project.projectGuid = new Guid(element.Where(el => el.Name == "GUID").First<XElement>().Value);
            project.projectType = GetProjectType(element.Where(el => el.Name == "ProjectType").First<XElement>().Value);
            return true;
        }

        private static ATNETProjectType GetProjectType(string type)
        {
            if (type == "StartFromBuilding")
            {
                return ATNETProjectType.StartFromBuilding;
            }
            else if (type == "StartFromBuilingFloor")
            {
                return ATNETProjectType.StartFromBuilingFloor;
            }
            else if (type == "StartFromPark")
            {
                return ATNETProjectType.StartFromPark;
            }
            else if (type == "StartFromRoom")
            {
                return ATNETProjectType.StartFromRoom;
            }
            return ATNETProjectType.Other;
        }

        public static bool AddNewProjectItem()
        {
            
            return true;
        }

    }
    /// <summary>
    /// ATNET工程的类型
    /// </summary>
    internal enum ATNETProjectType
    {
        /// <summary>
        /// 从楼宇开始
        /// </summary>
        StartFromBuilding,
        /// <summary>
        /// 从楼层开始
        /// </summary>
        StartFromBuilingFloor,
        /// <summary>
        /// 从园区开始
        /// </summary>
        StartFromPark,
        /// <summary>
        /// 从机房开始
        /// </summary>
        StartFromRoom,
        /// <summary>
        /// 其他
        /// </summary>
        Other
    }
    /// <summary>
    /// 工程的状态
    /// </summary>
    internal enum ProjectStatus
    {
        /// <summary>
        /// 新建工程
        /// </summary>
        New,
        /// <summary>
        /// 打开工程
        /// </summary>
        Open,
        /// <summary>
        /// 关闭工程
        /// </summary>
        Close,
        /// <summary>
        /// 删除工程
        /// </summary>
        Delete,
        /// <summary>
        /// 正在使用工程
        /// </summary>
        Work,
        /// <summary>
        /// 没有操作
        /// </summary>
        None
    }
}
