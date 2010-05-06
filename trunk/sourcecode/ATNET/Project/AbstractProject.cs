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
    /// 工程的抽象类
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
        /// <summary>
        /// 获取工程子项
        /// </summary>
        public ReadOnlyCollection<ProjectItem> Items
        {
            get
            {
                return new ReadOnlyCollection<ProjectItem>(new ProjectItem[0]);
            }
        }

        bool isDisposed;
        /// <summary>
        /// 获取是否Disposed
        /// </summary>
        [Browsable(false)]
        public bool IsDisposed
        {
            get { return isDisposed; }
        }
        public EventHandler Disposed;
        /// <summary>
        /// Dispose方法
        /// </summary>
        public virtual void Dispose()
        {
            isDisposed = true;
            if (Disposed != null)
            {
                Disposed(this, EventArgs.Empty);
            }
        }

        private string fileName;
        /// <summary>
        /// 工程的完整路径
        /// </summary>
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
        /// <summary>
        /// 工程的路径
        /// </summary>
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
        /// <summary>
        /// 工程的名字
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get
            {
                if (name == null)
                {
                    try
                    {
                        int index = this.fileName.LastIndexOf("\\");
                        int index1 = this.fileName.IndexOf(".");
                        name = fileName.Substring(index + 1, index1 - index - 1);
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
        /// <summary>
        /// 获取是否保存
        /// </summary>
        public bool IsSaved
        {
            get { return isSaved; }
        }

        private Guid guidID;
        /// <summary>
        /// 获取工程GUID
        /// </summary>
        public Guid GuidID
        {
            get { return guidID; }
        }
        /// <summary>
        /// 保存工程
        /// </summary>
        public void Save()
        {
            Save(this.fileName);
        }
        /// <summary>
        /// 保存工程
        /// </summary>
        /// <param name="fileName">工程文件的完整路径</param>
        protected virtual void Save(string fileName)
        {
          
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
    }
}


