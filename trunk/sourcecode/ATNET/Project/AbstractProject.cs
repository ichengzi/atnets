/*
 * Created by SharpDevelop.
 * User: eric
 * Date: 2010/5/4
 * Time: 21:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ATNET.Project
{
	/// <summary>
	/// Description of AbstractProject.
	/// </summary>
	public abstract class AbstractProject:IProject
	{
		public AbstractProject()
		{
			
		}
		
		public ReadOnlyCollection<ProjectItem> Items
		{
			get
			{
				return new ReadOnlyCollection<ProjectItem>(new ProjectItem[0]);
			}
		}
		
		bool isDisposed;
		[Browsable(false)]
		public bool IsDisposed
		{
			get{return isDisposed;}
		}
		public EventHandler Disposed;
		public virtual void Dispose()
		{
			isDisposed=true;
			if(Disposed!=null)
			{
				Disposed(this,EventArgs.Empty);
			}
		}
		
		private string fileName;
		[ReadOnly(true)]
		public string FileName
		{
			get{return fileName ?? "";}
			set
			{
				fileName=value;
				directory=null;
				name=null;
			}
		}
		
		private string directory;
		[Browsable(true)]
		public string Directory
		{
			get
			{
				if(directory==null)
				{
					try
					{
						directory=Path.GetDirectoryName(fileName);
					}
					catch
					{
						directory="";
					}
					
				}
				return directory;
			}
		}
		
		private string name;
		[Browsable(false)]
		public string Name
		{
			get
			{
				if(name==null)
				{
					try
					{
						int index=this.fileName.LastIndexOf("//");
						name=fileName.Substring(index,fileName.Length-index);
					}
					catch
					{
						name="";
					}
				}
				return name;
			}
			set{
				name=value;
			}
		}
		
		public void Save()
		{
			Save(this.fileName);
		}
		
		public virtual void Save(string fileName)
		{
			
		}
		
		public IEnumerable<ProjectItem> GetItemOfType(ItemType type)
		{
			foreach(ProjectItem item in this.Items)
			{
				if(item.ItemType==type)
				{
					yield return item;
				}
			}
		}
		
		public ItemType GetDefaultItemType(string fileName)
		{
			return new ItemType();
		}
	}
}


