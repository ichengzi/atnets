﻿/******************************************
* 模块名称：实体 线缆类型
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
	/// 实体 线缆类型
	/// </summary>
	[Serializable(),Description("Primary:CaTypeID")]
	public class tblCableType
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 线缆类型
	    /// </summary>
		public tblCableType(){}
		#endregion

		#region 私有变量
		private string _catypeid;
		private string _catypename;
		private string _catypecode;
		private string _catypeproperty;
		private DateTime _createdate;
		private string _creator;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 CaTypeID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string CaTypeID
		{
			set{ _catypeid=value;}
			get{return _catypeid;}
		}
		/// <summary>
		/// CaTypeName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string CaTypeName
		{
			set{ _catypename=value;}
			get{return _catypename;}
		}
		/// <summary>
		/// CaTypeCode
		/// </summary>
        [DataObjectField(false)]
		public string CaTypeCode
		{
			set{ _catypecode=value;}
			get{return _catypecode;}
		}
		/// <summary>
		/// CaTypeProperty
		/// </summary>
        [DataObjectField(false)]
		public string CaTypeProperty
		{
			set{ _catypeproperty=value;}
			get{return _catypeproperty;}
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
