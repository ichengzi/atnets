/******************************************
* 模块名称：实体 模块信息
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
	/// 实体 模块信息
	/// </summary>
	[Serializable(),Description("Primary:ModuleID")]
	public class tblModule
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 模块信息
	    /// </summary>
		public tblModule(){}
		#endregion

		#region 私有变量
		private string _moduleid;
		private string _superior;
		private string _modulename;
		private string _moduleurl;
		private string _creator;
		private DateTime _createdate;
		private string _remark;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 ModuleID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
		/// Superior
		/// </summary>
        [DataObjectField(false)]
		public string Superior
		{
			set{ _superior=value;}
			get{return _superior;}
		}
		/// <summary>
		/// ModuleName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string ModuleName
		{
			set{ _modulename=value;}
			get{return _modulename;}
		}
		/// <summary>
		/// ModuleURL (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string ModuleURL
		{
			set{ _moduleurl=value;}
			get{return _moduleurl;}
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
