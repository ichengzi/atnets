using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ATNET.Services.MenuService
{
    public static class MenuService 
    {
        private static ResourceDictionary contextMenuResource;
        public static ResourceDictionary ContextMenuResource
        {
            get { return contextMenuResource; }
        }
        static MenuService()
        {
 
        }


        public static void MenuServiceInit()
        {
            Uri uri = new Uri("\\Services\\MenuService\\ContextMenu.xaml", UriKind.RelativeOrAbsolute);
            contextMenuResource = Application.LoadComponent(uri) as ResourceDictionary;
        }
    }
}
