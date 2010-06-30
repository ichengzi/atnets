/******************************************
* 模块名称：实体 tblDataDictionary
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
	/// 实体 tblDataDictionary
	/// </summary>
	[Serializable(),Description("Primary:DDID")]
	public class tblDataDictionary
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 tblDataDictionary
	    /// </summary>
		public tblDataDictionary(){}
		#endregion

		#region 私有变量
		private string _ddid;
		private string _ddtype;
		private string _ddcode;
		private string _ddname;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 DDID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string DDID
		{
			set{ _ddid=value;}
			get{return _ddid;}
		}
		/// <summary>
		/// DDType (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string DDType
		{
			set{ _ddtype=value;}
			get{return _ddtype;}
		}
		/// <summary>
		/// DDCode (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string DDCode
		{
			set{ _ddcode=value;}
			get{return _ddcode;}
		}
		/// <summary>
		/// DDName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string DDName
		{
			set{ _ddname=value;}
			get{return _ddname;}
		}
		#endregion
	}
}
