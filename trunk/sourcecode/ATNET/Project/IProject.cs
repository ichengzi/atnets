/*
 * Created by SharpDevelop.
 * User: eric
 * Date: 2010/5/4
 * Time: 19:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Xml;

namespace ATNET.Project
{
	/// <summary>
	/// Description of IProject.
	/// </summary>
	public interface IProject:IDisposable
	{
		/// <summary>
		/// 获取全部的ProjectItem
		/// </summary>
		IList<ProjectItem> Items{get;}

        Guid GuidID
        {
            get;
        }
		/// <summary>
		/// 获取或者设置工程文件的完整路径
		/// </summary>
		string FileName
		{
			get;
			set;
		}
		/// <summary>
		/// 获取或者设置工程的名字
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// 获取工程的路径
		/// </summary>
		string Directory
		{
			get;
		}
        /// <summary>
        /// 工程是否保存
        /// </summary>
        bool IsSaved
        {
            get;
        }
       		
        /// <summary>
		/// 获取指定的ItemType的ProjectItem
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		IEnumerable<ProjectItem> GetItemOfType(ItemType type);

		/// <summary>
		/// 获取指定文件的默认类型
		/// </summary>
		/// <param name="fileName">文件的完整路径</param>
		/// <returns></returns>
		ItemType GetDefaultItemType(string fileName);
 
		/// <summary>
		/// 保存工程，以当前的工程名
		/// </summary>
		void Save();

        /// <summary>
        /// 另存为工程
        /// </summary>
        /// <param name="fileName"></param>
        void SaveAs(string fileName);

        /// <summary>
        /// 关闭工程
        /// </summary>
        void Close();

        void SaveAll();

        /// <summary>
        /// 添加新的工程子项
        /// </summary>
        /// <param name="item"></param>
        void AddProjectItem(ProjectItem item);
        /// <summary>
        /// 删除工程子项
        /// </summary>
        /// <param name="item"></param>
        void RemoveProjectItem(ProjectItem item);

	}
}
