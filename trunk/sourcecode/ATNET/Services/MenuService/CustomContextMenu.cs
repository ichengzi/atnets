using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace ATNET.Services.MenuService
{
    public class CustomContextMenu:ContextMenu
    {
        public static RoutedCommand AddLabel = new RoutedCommand();

        public CustomContextMenu()
        {
            this.CommandBindings.Add(new CommandBinding(AddLabel, AddLable_Excute));
        }

        private void AddLable_Excute(object sender, ExecutedRoutedEventArgs e)
        {
 
        }
    }
}
