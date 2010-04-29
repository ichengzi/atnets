/******************************************
* 模块名称：实体 容器信息    容器是广义的 包括 城市、园区、楼宇、楼层、机房、机柜等    自连接上一级
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
	/// 实体 容器信息
    ///    容器是广义的 包括 城市、园区、楼宇、楼层、机房、机柜等
    ///    自连接上一级
	/// </summary>
	[Serializable(),Description("Primary:ContainerID")]
	public class tblContainers
	{
		#region 构造函数
	    /// <summary>
	    /// 实体 容器信息
    ///    容器是广义的 包括 城市、园区、楼宇、楼层、机房、机柜等
    ///    自连接上一级
	    /// </summary>
		public tblContainers(){}
		#endregion

		#region 私有变量
		private string _containerid;
		private string _companyid;
		private string _ctypeid;
		private string _father;
		private string _containername;
		private string _containercode;
		private string _containerproperty;
		private string _shapeproperty;
		private string _creator;
		private DateTime _createdate;
		#endregion

        #region 公共属性
		/// <summary>
		/// 主键 ContainerID (必填字段)
		/// </summary>
        [DataObjectField(true)]
		public string ContainerID
		{
			set{ _containerid=value;}
			get{return _containerid;}
		}
		/// <summary>
		/// CompanyID
		/// </summary>
        [DataObjectField(false)]
		public string CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// CTypeID
		/// </summary>
        [DataObjectField(false)]
		public string CTypeID
		{
			set{ _ctypeid=value;}
			get{return _ctypeid;}
		}
		/// <summary>
		/// Father
		/// </summary>
        [DataObjectField(false)]
		public string Father
		{
			set{ _father=value;}
			get{return _father;}
		}
		/// <summary>
		/// ContainerName (必填字段)
		/// </summary>
        [DataObjectField(false)]
		public string ContainerName
		{
			set{ _containername=value;}
			get{return _containername;}
		}
		/// <summary>
		/// ContainerCode
		/// </summary>
        [DataObjectField(false)]
		public string ContainerCode
		{
			set{ _containercode=value;}
			get{return _containercode;}
		}
		/// <summary>
		/// ContainerProperty
		/// </summary>
        [DataObjectField(false)]
		public string ContainerProperty
		{
			set{ _containerproperty=value;}
			get{return _containerproperty;}
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
