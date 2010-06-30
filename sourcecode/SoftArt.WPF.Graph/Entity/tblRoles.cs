/******************************************
* 模块名称：实体 保存用户角色
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
	/// 实体 保存用户角色
	/// </summary>
	[Serializable(),Description("Primary:RoleID")]
	public class tblRoles
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存用户角色
	    /// </summary>
		public tblRoles(){}
		#endregion

		#region 私有变量
		private string _roleid;
		private string _rolename;
		private string _rolecode;
		private string _creator;
		private DateTime _createdate;
		private string _remark;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 RoleID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// RoleName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// RoleCode
		/// </summary>
        [DataObjectField(false)]
		public string RoleCode
		{
			set{ _rolecode=value;}
			get{return _rolecode;}
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
		/// remark
		/// </summary>
        [DataObjectField(false)]
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion
	}
}
