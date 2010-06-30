/******************************************
* 模块名称：实体 tblLogs
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
	/// 实体 tblLogs
	/// </summary>
	[Serializable(),Description("Primary:LogID")]
	public class tblLogs
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 tblLogs
	    /// </summary>
		public tblLogs(){}
		#endregion

		#region 私有变量
		private string _logid;
		private string _logcode;
		private string _logtype;
		private string _logresult;
		private string _logtable;
		private string _logmodule;
		private string _creator;
		private DateTime _createdate;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 LogID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string LogID
		{
			set{ _logid=value;}
			get{return _logid;}
		}
		/// <summary>
		/// LogCode (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string LogCode
		{
			set{ _logcode=value;}
			get{return _logcode;}
		}
		/// <summary>
		/// LogType (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string LogType
		{
			set{ _logtype=value;}
			get{return _logtype;}
		}
		/// <summary>
		/// LogResult (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string LogResult
		{
			set{ _logresult=value;}
			get{return _logresult;}
		}
		/// <summary>
		/// LogTable
		/// </summary>
        [DataObjectField(false)]
		public string LogTable
		{
			set{ _logtable=value;}
			get{return _logtable;}
		}
		/// <summary>
		/// LogModule
		/// </summary>
        [DataObjectField(false)]
		public string LogModule
		{
			set{ _logmodule=value;}
			get{return _logmodule;}
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
		#endregion
	}
}
