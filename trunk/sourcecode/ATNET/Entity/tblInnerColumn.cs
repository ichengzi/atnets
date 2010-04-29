/******************************************
* 模块名称：实体 保存固有的字段名称  比如：IP   、Manufacturer等
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

namespace ATNET.Entity.Common
{
	/// <summary>
	/// 实体 保存固有的字段名称  比如：IP   、Manufacturer等
	/// </summary>
	[Serializable(),Description("Primary:InnerColID")]
	public class tblInnerColumn
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存固有的字段名称  比如：IP   、Manufacturer等
	    /// </summary>
		public tblInnerColumn(){}
		#endregion

		#region 私有变量
		private string _innercolid;
		private string _innercolname;
		private string _innercolproperty;
		private string _creator;
		private DateTime _createdate;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 InnerColID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string InnerColID
		{
			set{ _innercolid=value;}
			get{return _innercolid;}
		}
		/// <summary>
		/// InnerColName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string InnerColName
		{
			set{ _innercolname=value;}
			get{return _innercolname;}
		}
		/// <summary>
		/// InnerColProperty (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string InnerColProperty
		{
			set{ _innercolproperty=value;}
			get{return _innercolproperty;}
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
