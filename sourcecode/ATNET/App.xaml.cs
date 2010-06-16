using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ATNET
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SplashScreen splashScreen = new SplashScreen("icons/SplashScreen.png");
            
            splashScreen.Show(true);
        }
    }
}
