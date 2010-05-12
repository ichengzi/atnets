using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftArt.WPF.Graph
{
    /// <summary>
    /// 在PropertyGrid中显示的特性
    /// </summary>
    public class BrowserAttribute : Attribute
    {
        private string name;
        private string caption;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        public BrowserAttribute()
        {
 
        }

        public BrowserAttribute(string name, string caption)
            : this()
        {
            this.name = name;
            this.caption = caption;
        }
    }
}
