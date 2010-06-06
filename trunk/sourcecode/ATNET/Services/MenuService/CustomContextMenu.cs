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
        public static RoutedCommand ViewProperty = new RoutedCommand();

        public CustomContextMenu()
        {
            this.CommandBindings.Add(new CommandBinding(AddLabel, AddLable_Excute));
            this.CommandBindings.Add(new CommandBinding(ViewProperty, ViewProperty_Excute));
        }
        /// <summary>增加标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLable_Excute(object sender, ExecutedRoutedEventArgs e)
        {
            ATNET.Gui.Windows.ChoseLabelWindow window = new ATNET.Gui.Windows.ChoseLabelWindow();
            window.Show();
        }
        /// <summary>查看属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewProperty_Excute(object sender, ExecutedRoutedEventArgs e)
        {
            ATNET.Gui.Windows.ViewProperty window = new ATNET.Gui.Windows.ViewProperty();
            window.Show();
        }

    }
}
