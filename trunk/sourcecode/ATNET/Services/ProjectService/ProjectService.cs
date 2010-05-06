using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ATNET.Project;

namespace ATNET.Services.ProjectService
{
    public static class ProjectService
    {
        private static IProject currentProject;
        /// <summary>
        /// 当前打开的工程
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

        public static ProjectEventHandler CurrentProjectChanged;
        public static EventHandler ProjectLoading;
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

        public static void AddProjectItem(IProject project, ATNET.Project.ProjectItem item)
        {
 
        }

        public static void RemoveProjectItem(IProject project, ATNET.Project.ProjectItem item)
        {
 
        }
    }
}
