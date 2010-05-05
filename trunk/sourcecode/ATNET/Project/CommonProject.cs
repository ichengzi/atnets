using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATNET.Project
{
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
    }
}
