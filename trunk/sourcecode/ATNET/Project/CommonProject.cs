using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATNET.Services.ParseService;
using System.Xml.Linq;
using System.IO;

namespace ATNET.Project
{
    /// <summary>
    /// 普通工程类
    /// </summary>
    public class CommonProject:AbstractProject
    {
        public CommonProject()
        {
 
        }

        public CommonProject(string fielName)
            : base(fielName)
        {
 
        }

        public CommonProject(string fileName, string guid)
            : base(fileName, guid)
        {

        }

        protected override void Save(string fileName)
        {
            fileName = fileName + ".atnprj";
            IProject project = new CommonProject(fileName);
            XElement xElement = new XElement("Project",
                new XElement("Name", project.Name),
                new XElement("GuidID", project.GuidID),
                new XElement("Items", ""));
            xElement.Save(fileName);
        }

        /// <summary>
        /// 建立一个新的工程
        /// </summary>
        /// <param name="fileName">新建工程文件的完整路径</param>
        public static IProject NewProject(string fileName)
        {
            fileName = fileName + ".atnprj";
            IProject project = new CommonProject(fileName);
            XElement xElement = new XElement("Project",
                new XElement("Name", project.Name),
                new XElement("GuidID", project.GuidID),
                new XElement("Items", ""));
            xElement.Save(fileName);
            return project;
        }

        /// <summary>
        /// 载入工程
        /// </summary>
        /// <param name="fileName">工程文件的完整路径</param>
        /// <returns></returns>
        public static IProject Load(string fileName)
        {
            IProject project = ParseProject.ParseToProject(fileName);
            return project;
        }
    }
}
