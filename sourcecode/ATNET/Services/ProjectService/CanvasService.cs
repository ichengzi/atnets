using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftArt.WPF.Graph;

namespace ATNET.Services.ProjectService
{
    /// <summary>
    /// Canvas的服务类
    /// </summary>
    public static class CanvasService
    {
        private DesignerCanvas canvas;
        /// <summary>
        /// 获取当前使用的Canvas对象
        /// </summary>
        public DesignerCanvas Canvas
        {
            get 
            {
                if (canvas == null)
                {
                    canvas = new DesignerCanvas();
                }
                else
                {
                    canvas = CanvasDocumentService.CurrentCanvas;
                }
                return canvas;
            }
        }
    }
}
