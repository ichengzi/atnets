using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATNET.Project
{
    /// <summary>
    /// 表示一个工程或者解决方案（不一定有）
    /// </summary>
    public interface IBuildable
    {
        /// <summary>
        /// Gets the list of projects on which this project depends.
        /// </summary>
        ICollection<IBuildable> GetBuildDependencies(ProjectBuildOptions buildOptions);

        /// <summary>
        /// Starts building the project using the specified options.
        /// This member must be implemented thread-safe.
        /// </summary>
        void StartBuild(ProjectBuildOptions buildOptions, IBuildFeedbackSink feedbackSink);

        /// <summary>
        /// Gets the name of the buildable item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the parent solution.
        /// </summary>
        Solution ParentSolution { get; }
    }
}
