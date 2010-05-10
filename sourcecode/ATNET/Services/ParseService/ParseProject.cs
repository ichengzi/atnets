using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

using ATNET.Project;
using System.Collections;

namespace ATNET.Services.ParseService
{
    /// <summary>
    /// 从文件转换为Project对象
    /// </summary>
    public static class ParseProject
    {
        /// <summary>
        /// 转换文件到Project对象
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IProject ParseToProject(string fileName)
        {
            IProject project;
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }
            XElement rootElement = XElement.Load(fileName);
            IEnumerable<XElement> element = from el in rootElement.Elements() select el;
            string guid = element.Where(el => el.Name == "GuidID").First<XElement>().Value;
            project = new CommonProject(fileName, guid);
            ParseToProjectItem(rootElement,project);
            return project;
        }

        private static void ParseToProjectItem(XElement rootElement,IProject project)
        {
            IEnumerable<XElement> element = from el in rootElement.Elements() select el;
            IEnumerable<XElement> element1 = element.Where(el => el.Name == "Items");
            foreach (XElement e1 in element1.Nodes<XElement>())
            {
                int count = e1.Elements().Count<XElement>();
                string type = e1.Attribute("Type").Value;
                string name = e1.Attribute("Name").Value;

                if (count == 0)//CustomProjectItem
                {
                    project.AddProjectItem(new CustomProjectItem(project, new ItemType(type), name));
                }
                else//DirectoryProjectItem
                {
                    DirectoryProjectItem projectItem = new DirectoryProjectItem(project, new ItemType(type), name);
                    project.AddProjectItem(projectItem);
                    BuildDirectoryItem(project, projectItem, e1);
                }
            }
        }

        private static void BuildDirectoryItem(IProject project,DirectoryProjectItem projectItem, XElement el)
        {
            foreach (XElement e1 in el.Elements())
            {
                int count = e1.Elements().Count<XElement>();
                string type = e1.Attribute("Type").Value;
                string name = e1.Attribute("Name").Value;
                if (count == 0)
                {
                    projectItem.Items.Add(new CustomProjectItem(project, new ItemType(type), name));
                }
                else
                {
                    projectItem.Items.Add(new DirectoryProjectItem(project, new ItemType(type), name));
                    BuildDirectoryItem(project, projectItem.Items[0] as DirectoryProjectItem, e1);
                }
            }
        }


        //private static ATNET.Project.ProjectItem BuildProjectItem(IEnumerable<XElement> element)
        //{
        //    foreach (XElement el in element.Nodes())
        //    {
        //        ATNET.Project.ProjectItem projectItem = BuildProjectItem(el.Elements());
        
        //        //XElement el2 = el1.First<XElement>();
        //    }
        //    return new CustomProjectItem(new CommonProject());
        //}
     
    }
}
