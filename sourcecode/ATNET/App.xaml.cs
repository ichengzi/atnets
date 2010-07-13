using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Reflection;
using log4net;

using ATNET.Services.FileService;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ATNET
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private ILog log;
        public ILog Log
        {
            get { return log; }
        }

        public App()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            log.Info("程序启动");
            try
            {
                log.Info("启动初始化启动窗口");
                SplashScreen splashScreen = new SplashScreen("icons/SplashScreen.png");
                splashScreen.Show(true);
            }
            catch (Exception ex)
            {
                log.Fatal("初始化启动窗口出错", ex);
            }
        }
    }
}
