using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftArt.WPF.Graph;
using System.Windows;
using AvalonDock;

namespace ATNET.Services.ProjectService
{
    /// <summary>
    /// CanvasDocument服务类
    /// </summary>
    public static class CanvasDocumentService
    {
        private static List<CanvasDocument> canvasDocuments;
        /// <summary>
        /// 服务中所有的CanvasDocument对象
        /// </summary>
        public static List<CanvasDocument> CanvasDocuments
        {
            get { return canvasDocuments;}
        }
        /// <summary>
        /// 添加新的Document
        /// </summary>
        /// <param name="document"></param>
        public static void AddCanvasDocument(CanvasDocument document)
        {
            bool isAdd = true;
            if (canvasDocuments != null)
            {
                foreach (CanvasDocument doc in canvasDocuments)
                {
                    if (doc.Equals(document))
                    {
                        isAdd = false;
                        break;
                    }
                }
            }
            else
            {
                canvasDocuments = new List<CanvasDocument>();
            }
            if (isAdd)
            {
                canvasDocuments.Add(document);
                Window1 mainWindow = GetMainWindow();
                mainWindow.DockingManager.Items.Add(document);
                SetDocumentSelected(document);
            }
        }
        /// <summary>
        /// 删除Document
        /// </summary>
        /// <param name="document"></param>
        public static void RemoveDocument(CanvasDocument document)
        {
            canvasDocuments.Remove(document);
            Window1 mainWindow = GetMainWindow();
            mainWindow.DockingManager.Items.Remove(document);
        }
        /// <summary>
        /// 获取主窗体
        /// </summary>
        /// <returns></returns>
        private static Window1 GetMainWindow()
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window is Window1)
                {
                    return (Window1)window;
                }
            }
            return null;
        }
        /// <summary>
        /// 设置此Document处于选中状态
        /// </summary>
        /// <param name="document"></param>
        public static void SetDocumentSelected(CanvasDocument document)
        {
            Window1 mainWindow = GetMainWindow();
            foreach (CanvasDocument doc in mainWindow.DockingManager.Items)
            {
                if (doc.Equals(document))
                {
                    mainWindow.DockingManager.SelectedItem = doc;
                    break;
                }
            }
        }

        //private static CanvasDocument GetSelectedDocument()
        //{
 
        //}

        //private static DesignerCanvas GetSelectedCanvas()
        //{ 

        //}

    }
}

