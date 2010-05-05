using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATNET.Services.ProjectService
{
    interface IProjectLoader
    {
        /// <summary>
        /// 加载工程
        /// </summary>
        /// <param name="fielName">工程的完整路径</param>
        void Load(string fielName);
    }
}
