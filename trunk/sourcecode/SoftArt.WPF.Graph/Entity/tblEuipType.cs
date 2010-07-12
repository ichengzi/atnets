/******************************************
* 模块名称：实体 tblEuipType
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
	/// 实体 tblEuipType
	/// </summary>
	[Serializable(),Description("Primary:ETypeID")]
	public class tblEuipType
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 tblEuipType
	    /// </summary>
        public tblEuipType()
        {
            //初始化类型
            this._etypeid = "1";
            this._etypename = "类型1";
            this._creator = "张三";
            this._createdate = DateTime.Now;
        }
		#endregion

		#region 私有变量
		private string _etypeid;
		private string _etypename;
		private string _etypecode;
		private string _etypeproperty;
		private string _creator;
		private DateTime _createdate;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 ETypeID (必填字段)
		/// </summary>
        [DataObjectField(true)]
        [Browser("TypeID","类型ID")]
		public string ETypeID
		{
			set{ _etypeid=value;}
			get{return _etypeid;}
		}
		/// <summary>
		/// ETypeName (必填字段)
		/// </summary>
        [DataObjectField(false)]
        [Browser("TypeName", "类型名称")]
		public string ETypeName
		{
			set{ _etypename=value;}
			get{return _etypename;}
		}
		/// <summary>
		/// ETypeCode (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string ETypeCode
		{
			set{ _etypecode=value;}
			get{return _etypecode;}
		}
		/// <summary>
		/// ETypeProperty (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string ETypeProperty
		{
			set{ _etypeproperty=value;}
			get{return _etypeproperty;}
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
