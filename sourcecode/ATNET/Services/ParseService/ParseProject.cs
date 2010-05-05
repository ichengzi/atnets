using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

using ATNET.Project;

namespace ATNET.Services.ParseService
{
    public static class ParseProject
    {

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
            return project;
        }

     
    }
}
