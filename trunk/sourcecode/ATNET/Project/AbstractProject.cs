/*
 * Created by SharpDevelop.
 * User: eric
 * Date: 2010/5/4
 * Time: 21:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Xml.Linq;
using ATNET.Services.ParseService;

namespace ATNET.Project
{
    /// <summary>
    /// Description of AbstractProject.
    /// </summary>
    public abstract class AbstractProject : IProject
    {
        public AbstractProject()
        {

        }
        /// <summary>
        /// 构造函数，新建工程时使用
        /// </summary>
        /// <param name="fileName"></param>
        public AbstractProject(string fileName)
        {
            this.fileName = fileName;
            this.guidID = Guid.NewGuid();
        }
        /// <summary>
        /// 构造函数，打开工程时使用
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="guid"></param>
        public AbstractProject(string fileName, string guid)
        {
            this.fileName = fileName;
            this.guidID = new Guid(guid);
        }

        public ReadOnlyCollection<ProjectItem> Items
        {
            get
            {
                return new ReadOnlyCollection<ProjectItem>(new ProjectItem[0]);
            }
        }

        bool isDisposed;
        [Browsable(false)]
        public bool IsDisposed
        {
            get { return isDisposed; }
        }
        public EventHandler Disposed;
        public virtual void Dispose()
        {
            isDisposed = true;
            if (Disposed != null)
            {
                Disposed(this, EventArgs.Empty);
            }
        }

        private string fileName;
        [ReadOnly(true)]
        public string FileName
        {
            get { return fileName ?? ""; }
            set
            {
                fileName = value;
                directory = null;
                name = null;
            }
        }

        private string directory;
        [Browsable(true)]
        public string Directory
        {
            get
            {
                if (directory == null)
                {
                    try
                    {
                        directory = Path.GetDirectoryName(fileName);
                    }
                    catch
                    {
                        directory = "";
                    }

                }
                return directory;
            }
        }

        private string name;
        [Browsable(false)]
        public string Name
        {
            get
            {
                if (name == null)
                {
                    try
                    {
                        int index = this.fileName.LastIndexOf("//");
                        int index1 = this.fileName.IndexOf("/.");
                        name = fileName.Substring(index, index1);
                    }
                    catch
                    {
                        name = "";
                    }
                }
                return name;
            }
            set
            {
                name = value;
            }
        }

        private bool isSaved;
        public bool IsSaved
        {
            get { return isSaved; }
        }

        private Guid guidID;
        public Guid GuidID
        {
            get { return guidID; }
        }

        public void Save()
        {
            Save(this.fileName);
        }

        public virtual void Save(string fileName)
        {
            IProject project = new CommonProject(fileName);
            XElement xElement = new XElement("Project",
                new XElement("Name", project.Name),
                new XElement("GuidID", project.GuidID),
                new XElement("Items", ""));
            xElement.Save(fileName);
        }

        public virtual void SaveAs(string fileName)
        {
 
        }

        public virtual void AddProjectItem(ProjectItem item)
        {
 
        }

        public virtual void RemoveProjectItem(ProjectItem item)
        {
 
        }

        public virtual void Close()
        {
 
        }

        public virtual void SaveAll()
        {
 
        }

        public IEnumerable<ProjectItem> GetItemOfType(ItemType type)
        {
            foreach (ProjectItem item in this.Items)
            {
                if (item.ItemType == type)
                {
                    yield return item;
                }
            }
        }

        public ItemType GetDefaultItemType(string fileName)
        {
            return new ItemType();
        }

        /// <summary>
        /// 载入工程
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IProject Load(string fileName)
        {
            IProject project = ParseProject.ParseToProject(fileName);
            return project;
        }
    }
}


