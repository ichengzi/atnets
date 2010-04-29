/******************************************
* 模块名称：实体 标识类型
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
	/// 实体 标识类型
	/// </summary>
	[Serializable(),Description("Primary:LTypeID")]
	public class tblLabelType
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 标识类型
	    /// </summary>
		public tblLabelType(){}
		#endregion

		#region 私有变量
		private string _ltypeid;
		private string _ltypename;
		private string _ltypecode;
		private string _shapeproperty;
		private DateTime _createdate;
		private string _creator;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 LTypeID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string LTypeID
		{
			set{ _ltypeid=value;}
			get{return _ltypeid;}
		}
		/// <summary>
		/// LTypeName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string LTypeName
		{
			set{ _ltypename=value;}
			get{return _ltypename;}
		}
		/// <summary>
		/// LTypeCode
		/// </summary>
        [DataObjectField(false)]
		public string LTypeCode
		{
			set{ _ltypecode=value;}
			get{return _ltypecode;}
		}
		/// <summary>
		/// ShapeProperty
		/// </summary>
        [DataObjectField(false)]
		public string ShapeProperty
		{
			set{ _shapeproperty=value;}
			get{return _shapeproperty;}
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
