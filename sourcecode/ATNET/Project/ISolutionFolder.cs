using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATNET.Project
{
    /// <summary>
		/// Gets the object used for thread-safe synchronization.
		/// Thread-safe members lock on this object, but if you manipulate underlying structures
		/// (such as the MSBuild project for MSBuildBasedProjects) directly, you will have to lock on this object.
		/// </summary>
		object SyncRoot {
			get;
		}
		
		/// <summary>
		/// Gets/Sets the container that contains this folder. This member is thread-safe.
		/// </summary>
		ISolutionFolderContainer Parent {
			get;
			set;
		}
		
		string TypeGuid {
			get;
			set;
		}
		
		string IdGuid {
			get;
			set;
		}
		
		string Location {
			get;
			set;
		}
		
		string Name {
			get;
			set;
		}
}
