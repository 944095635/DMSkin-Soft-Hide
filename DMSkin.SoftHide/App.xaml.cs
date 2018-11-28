using DMSkin.Core.Common;
using System;
using System.Windows;

namespace DMSkin.SoftHide
{
    public partial class App : Application
    {
        /// <summary>
        /// 软件启动路径
        /// </summary>
        public static string RunPath = string.Empty;

        protected override void OnStartup(StartupEventArgs e)
        {
            RunPath = AppDomain.CurrentDomain.BaseDirectory;

            //初始化Dispatcher
            Execute.InitializeWithDispatcher();
        }
    }
}
