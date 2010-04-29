/******************************************
* 模块名称：实体 保存标识信息
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
	/// 实体 保存标识信息
	/// </summary>
	[Serializable(),Description("Primary:LabelID")]
	public class tblLabels
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存标识信息
	    /// </summary>
		public tblLabels(){}
		#endregion

		#region 私有变量
		private string _labelid;
		private string _cableid;
		private string _ltypeid;
		private string _labelcode;
		private string _labelcontent;
		private string _isprint;
		private string _printer;
		private DateTime _printdate;
		private Int32 _printcount;
		private DateTime _createdate;
		private string _creator;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 LabelID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string LabelID
		{
			set{ _labelid=value;}
			get{return _labelid;}
		}
		/// <summary>
		/// CableID
		/// </summary>
        [DataObjectField(false)]
		public string CableID
		{
			set{ _cableid=value;}
			get{return _cableid;}
		}
		/// <summary>
		/// LTypeID
		/// </summary>
        [DataObjectField(false)]
		public string LTypeID
		{
			set{ _ltypeid=value;}
			get{return _ltypeid;}
		}
		/// <summary>
		/// LabelCode (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string LabelCode
		{
			set{ _labelcode=value;}
			get{return _labelcode;}
		}
		/// <summary>
		/// LabelContent (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string LabelContent
		{
			set{ _labelcontent=value;}
			get{return _labelcontent;}
		}
		/// <summary>
		/// IsPrint
		/// </summary>
        [DataObjectField(false)]
		public string IsPrint
		{
			set{ _isprint=value;}
			get{return _isprint;}
		}
		/// <summary>
		/// Printer
		/// </summary>
        [DataObjectField(false)]
		public string Printer
		{
			set{ _printer=value;}
			get{return _printer;}
		}
		/// <summary>
		/// PrintDate
		/// </summary>
        [DataObjectField(false)]
		public DateTime PrintDate
		{
			set{ _printdate=value;}
			get{return _printdate;}
		}
		/// <summary>
		/// PrintCount (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public Int32 PrintCount
		{
			set{ _printcount=value;}
			get{return _printcount;}
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
