/******************************************
* 模块名称：实体 保存线缆信息
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
	/// 实体 保存线缆信息
	/// </summary>
	[Serializable(),Description("Primary:CableID")]
	public class tblCables
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存线缆信息
	    /// </summary>
		public tblCables(){}
		#endregion

		#region 私有变量
		private string _cableid;
		private string _catypeid;
		private string _cablename;
		private string _cablecode;
		private string _cableproperty;
		private string _shapeproperty;
		private string _equipoutput;
		private string _equipinput;
		private string _cablerouting;
		private DateTime _createdate;
		private string _creator;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 CableID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string CableID
		{
			set{ _cableid=value;}
			get{return _cableid;}
		}
		/// <summary>
		/// CaTypeID
		/// </summary>
        [DataObjectField(false)]
		public string CaTypeID
		{
			set{ _catypeid=value;}
			get{return _catypeid;}
		}
		/// <summary>
		/// CableName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string CableName
		{
			set{ _cablename=value;}
			get{return _cablename;}
		}
		/// <summary>
		/// CableCode
		/// </summary>
        [DataObjectField(false)]
		public string CableCode
		{
			set{ _cablecode=value;}
			get{return _cablecode;}
		}
		/// <summary>
		/// CableProperty
		/// </summary>
        [DataObjectField(false)]
		public string CableProperty
		{
			set{ _cableproperty=value;}
			get{return _cableproperty;}
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
		/// EquipOutput
		/// </summary>
        [DataObjectField(false)]
		public string EquipOutput
		{
			set{ _equipoutput=value;}
			get{return _equipoutput;}
		}
		/// <summary>
		/// EquipInput (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string EquipInput
		{
			set{ _equipinput=value;}
			get{return _equipinput;}
		}
		/// <summary>
		/// CableRouting
		/// </summary>
        [DataObjectField(false)]
		public string CableRouting
		{
			set{ _cablerouting=value;}
			get{return _cablerouting;}
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
