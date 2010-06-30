/******************************************
* 模块名称：实体 保存公司信息
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
	/// 实体 保存公司信息
	/// </summary>
	[Serializable(),Description("Primary:CompanyID")]
	public class tblCompany
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存公司信息
	    /// </summary>
		public tblCompany(){}
		#endregion

		#region 私有变量
		private string _companyid;
		private string _superior;
		private string _companycode;
		private string _companyname;
		private string _adress;
		private string _telephone;
		private string _isvalid;
		private string _creator;
		private DateTime _createdate;
		private string _remark;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 CompanyID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
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
		/// CompanyCode
		/// </summary>
        [DataObjectField(false)]
		public string CompanyCode
		{
			set{ _companycode=value;}
			get{return _companycode;}
		}
		/// <summary>
		/// CompanyName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// Adress
		/// </summary>
        [DataObjectField(false)]
		public string Adress
		{
			set{ _adress=value;}
			get{return _adress;}
		}
		/// <summary>
		/// Telephone
		/// </summary>
        [DataObjectField(false)]
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// IsValid (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string IsValid
		{
			set{ _isvalid=value;}
			get{return _isvalid;}
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
