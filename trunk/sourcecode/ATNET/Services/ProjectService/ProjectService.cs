using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ATNET.Project;

namespace ATNET.Services.ProjectService
{
    /// <summary>
    /// 工程服务类，工程的主要逻辑
    /// </summary>
    public static class ProjectService
    {
        private static bool Isinitialized = false;

        private static IProject currentProject;
        /// <summary>
        /// 当前使用的工程
        /// </summary>
        public static IProject CurrentProject
        {
            get
            {
                return currentProject;
            }
            set
            {
                if (currentProject != value)
                {
                    currentProject = value;
                    OnCurrentProjectChanged(new ProjectEventArgs(currentProject));
                }
            }
        }
        /// <summary>
        /// 当前工程变化
        /// </summary>
        public static ProjectEventHandler CurrentProjectChanged;
        /// <summary>
        /// 工程正在加载时
        /// </summary>
        public static EventHandler ProjectLoading;
        /// <summary>
        /// 工程加载完成时
        /// </summary>
        public static ProjectEventHandler ProjectLoaded;

        private static void OnCurrentProjectChanged(ProjectEventArgs e)
        {
            if (CurrentProjectChanged != null)
            {
                CurrentProjectChanged(null, e);
            }
        }
        /// <summary>
        /// 加载工程之前的操作
        /// </summary>
        private static void BeforeLoadProject()
        {
            if (!Isinitialized)
            {
                Isinitialized = true;
                ProjectService.ProjectLoaded += ProjectSeviceProjectLoaded;
            }
        }

        private static void ProjectSeviceProjectLoaded(object sender, ProjectEventArgs e)
        {
            CanvasDocumentService.AddCanvasDocument(e.Project.CanvasDocument);
        }

        /// <summary>
        /// 正在加载工程
        /// </summary>
        /// <param name="fileName"></param>
        private static void OnProjectLoading(string fileName)
        {
            if (ProjectLoading != null)
            {
                ProjectLoading(fileName, EventArgs.Empty);
            }
        }
        /// <summary>
        /// 工程加载完毕
        /// </summary>
        /// <param name="e"></param>
        private static void OnProjectLoaded(ProjectEventArgs e)
        {
            if (ProjectLoaded != null)
            {
                ProjectLoaded(null, e);
            }
        }

        /// <summary>
        /// 加载工程
        /// </summary>
        /// <param name="fileName"></param>
        public static void LoadProject(string fileName)
        {
            if (!Path.IsPathRooted(fileName))
            {
                throw new ArgumentException("Path must be rooted!");
            }
            BeforeLoadProject();
            OnProjectLoading(fileName);
            try
            {
                currentProject = CommonProject.Load(fileName);
                if (currentProject == null)
                    return;
            }
            catch (IOException ex)
            {
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                return;
            }
            OnProjectLoaded(new ProjectEventArgs(currentProject));
        }
        /// <summary>
        /// 添加工程子项
        /// </summary>
        /// <param name="project"></param>
        /// <param name="item"></param>
        public static void AddProjectItem(IProject project, ATNET.Project.ProjectItem item)
        {

        }
        /// <summary>
        /// 移除工程子项
        /// </summary>
        /// <param name="project"></param>
        /// <param name="item"></param>
        public static void RemoveProjectItem(IProject project, ATNET.Project.ProjectItem item)
        {

        }
        /// <summary>
        /// 保存工程
        /// </summary>
        /// <param name="project"></param>
        public static void SaveProject(IProject project)
        {
 
        }
        /// <summary>
        /// 关闭工程
        /// </summary>
        /// <param name="project"></param>
        public static void CloseProject(IProject project)
        {
 
        }
        /// <summary>
        /// 保存工程子项
        /// </summary>
        /// <param name="project"></param>
        /// <param name="projectItem"></param>
        private static void SaveProjectItem(IProject project, ProjectItem projectItem)
        {
 
        }
    }
}
