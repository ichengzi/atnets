/******************************************
* 模块名称：实体 保存用户信息
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
	/// 实体 保存用户信息
	/// </summary>
	[Serializable(),Description("Primary:UserID")]
	public class tblUsers
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存用户信息
	    /// </summary>
		public tblUsers(){}
		#endregion

		#region 私有变量
		private string _userid;
		private string _usercom;
		private string _userrole;
		private string _username;
		private string _useraccount;
		private byte[] _userpsw;
		private string _telephone;
		private string _isvalid;
		private string _creator;
		private DateTime _createdate;
		private string _remark;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 UserID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// UserCom (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string UserCom
		{
			set{ _usercom=value;}
			get{return _usercom;}
		}
		/// <summary>
		/// UserRole
		/// </summary>
        [DataObjectField(false)]
		public string UserRole
		{
			set{ _userrole=value;}
			get{return _userrole;}
		}
		/// <summary>
		/// UserName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// UserAccount (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string UserAccount
		{
			set{ _useraccount=value;}
			get{return _useraccount;}
		}
		/// <summary>
		/// UserPSW (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public byte[] UserPSW
		{
			set{ _userpsw=value;}
			get{return _userpsw;}
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
