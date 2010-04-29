/******************************************
* 模块名称：实体 保存设备信息
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
	/// 实体 保存设备信息
	/// </summary>
	[Serializable(),Description("Primary:EquipID")]
	public class tblEuipments
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 保存设备信息
	    /// </summary>
		public tblEuipments(){}
		#endregion

		#region 私有变量
		private string _equipid;
		private string _containerid;
		private string _etypeid;
		private string _equipname;
		private string _equipcode;
		private string _equipproperty;
		private string _shapeproperty;
		private DateTime _createdate;
		private string _creator;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 EquipID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string EquipID
		{
			set{ _equipid=value;}
			get{return _equipid;}
		}
		/// <summary>
		/// ContainerID
		/// </summary>
        [DataObjectField(false)]
		public string ContainerID
		{
			set{ _containerid=value;}
			get{return _containerid;}
		}
		/// <summary>
		/// ETypeID
		/// </summary>
        [DataObjectField(false)]
		public string ETypeID
		{
			set{ _etypeid=value;}
			get{return _etypeid;}
		}
		/// <summary>
		/// EquipName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string EquipName
		{
			set{ _equipname=value;}
			get{return _equipname;}
		}
		/// <summary>
		/// EquipCode
		/// </summary>
        [DataObjectField(false)]
		public string EquipCode
		{
			set{ _equipcode=value;}
			get{return _equipcode;}
		}
		/// <summary>
		/// EquipProperty
		/// </summary>
        [DataObjectField(false)]
		public string EquipProperty
		{
			set{ _equipproperty=value;}
			get{return _equipproperty;}
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
