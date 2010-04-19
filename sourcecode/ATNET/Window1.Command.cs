using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using AvalonDock;

namespace ATNET
{
    public partial class Window1:Window
    {
        public static RoutedCommand ShowToolBox = new RoutedCommand();
        public static RoutedCommand ShowProjectWindow = new RoutedCommand();
        public static RoutedCommand ShowPropertyWindow = new RoutedCommand();
        /// <summary>
        /// 注册Window1的命令
        /// </summary>
        /// <returns></returns>
        private bool RegeditCommands()
        {
            this.CommandBindings.Add(new CommandBinding(Window1.ShowToolBox, ShowToolBox_Executed));
            this.CommandBindings.Add(new CommandBinding(Window1.ShowProjectWindow, ShowProjectWindow_Executed));
            this.CommandBindings.Add(new CommandBinding(Window1.ShowPropertyWindow, ShowPropertyWindow_Executed));
            return true;
        }

        private void ShowToolBox_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (toolWindow.State != DockableContentState.AutoHide)
            {
                dockingManager.Show(toolWindow, DockableContentState.AutoHide);
            }
            else
            {
                dockingManager.Show(toolWindow, DockableContentState.Docked);
            }
        }

        private void ShowProjectWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (projectWindow.State != DockableContentState.AutoHide)
            {
                dockingManager.Show(projectWindow, DockableContentState.AutoHide);
            }
            else
            {
                dockingManager.Show(projectWindow, DockableContentState.Docked);
            }
        }

        private void ShowPropertyWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (propertyWindow.State != DockableContentState.AutoHide)
            {
                dockingManager.Show(propertyWindow, DockableContentState.AutoHide);
            }
            else
            {
                dockingManager.Show(propertyWindow, DockableContentState.Docked);
            }
        }
    }
}
