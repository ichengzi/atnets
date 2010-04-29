using System;
using System.Collections.Generic;

namespace ATNET.Project
{
    /// <summary>
    /// Specifies options for building a single project.
    /// </summary>
    public class ProjectBuildOptions
    {
        BuildTarget target;
        IDictionary<string, string> properties = new SortedList<string, string>();

        public BuildTarget Target
        {
            get { return target; }
        }

        public IDictionary<string, string> Properties
        {
            get { return properties; }
        }

        public ProjectBuildOptions(BuildTarget target)
        {
            this.target = target;
        }

        /// <summary>
        /// Specifies the project configuration used for the build.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Specifies the project platform used for the build.
        /// </summary>
        public string Platform { get; set; }
    }
	
}
