using System;

using ATNET.Project;

namespace ATNET.Services.ProjectService
{
    public delegate void ProjectEventHandler(object sender,ProjectEventArgs e);
    /// <summary>
    /// 工程事件参数
    /// </summary>
    public class ProjectEventArgs:EventArgs
    {
        protected IProject project;

        public IProject Project
        {
            get { return this.project; }
        }

        public ProjectEventArgs(IProject project)
        {
            this.project = project;
        }
    }
}
