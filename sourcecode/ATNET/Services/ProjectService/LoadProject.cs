using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATNET.Services.ProjectService
{
    public class LoadProject:IProjectLoader
    {
        public void Load(string fileName)
        {
            ProjectService.LoadProject(fileName);
        }
    }
}
