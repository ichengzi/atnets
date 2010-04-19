using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftArt.WPF.Graph
{
    /// <summary>
    /// 表示组件是否被选中的接口
    /// </summary>
    public interface ISelectable
    {
        bool IsSelected { get; set; } 
    }
}
