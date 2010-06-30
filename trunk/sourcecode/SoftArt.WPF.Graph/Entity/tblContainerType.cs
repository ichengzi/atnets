/******************************************
* 模块名称：实体 保存容器的类型
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
	/// 实体 保存容器的类型
	/// </summary>
	[Serializable(),Description("Primary:CTypeID")]
	public class tblContainerType
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存容器的类型
	    /// </summary>
		public tblContainerType(){}
		#endregion

		#region 私有变量
		private string _ctypeid;
		private string _ctypename;
		private string _ctypecode;
		private string _ctypeproperty;
		private string _creator;
		private DateTime _createdate;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 CTypeID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string CTypeID
		{
			set{ _ctypeid=value;}
			get{return _ctypeid;}
		}
		/// <summary>
		/// CTypeName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string CTypeName
		{
			set{ _ctypename=value;}
			get{return _ctypename;}
		}
		/// <summary>
		/// CTypeCode (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string CTypeCode
		{
			set{ _ctypecode=value;}
			get{return _ctypecode;}
		}
		/// <summary>
		/// CTypeProperty (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string CTypeProperty
		{
			set{ _ctypeproperty=value;}
			get{return _ctypeproperty;}
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
