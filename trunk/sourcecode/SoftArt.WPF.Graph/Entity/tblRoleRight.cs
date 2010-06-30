/******************************************
* 模块名称：实体 保存角色权限
* 当前版本：1.0
* 开发人员：Eric
* 完成时间：2010-4-29
* 版本历史：此代码由 VB/C#.Net实体代码生成工具(EntitysCodeGenerate v4.1) 自动生成。
* 
******************************************/
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace  SoftArt.WPF.Graph.Entity
{
	/// <summary>
	/// 实体 保存角色权限
	/// </summary>
	[Serializable(),Description("Primary:RoleRightID")]
	public class tblRoleRight
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存角色权限
	    /// </summary>
		public tblRoleRight(){}
		#endregion

		#region 私有变量
		private string _rolerightid;
		private string _moduleid;
		private string _roleid;
		private DateTime _createdate;
		private string _creator;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 RoleRightID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string RoleRightID
		{
			set{ _rolerightid=value;}
			get{return _rolerightid;}
		}
		/// <summary>
		/// ModuleID
		/// </summary>
        [DataObjectField(false)]
		public string ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
		/// RoleID
		/// </summary>
        [DataObjectField(false)]
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// CreateDate (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// Creator (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		#endregion
	}
}
