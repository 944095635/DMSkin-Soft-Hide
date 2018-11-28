using DMSkin.Core.Common;
using DMSkin.Core.MVVM;
using DMSkin.SoftHide.Model;
using DMSkin.SoftHide.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMSkin.SoftHide.ViewModel
{
    public class MainWindowViewModel:ViewModelBase 
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWindowViewModel()
        {
            LoadSoftList();
        }

        /// <summary>
        /// 读取程序列表
        /// </summary>
        public void LoadSoftList()
        {
            Task.Factory.StartNew(()=> 
            {
                List<Soft> temp = new List<Soft>();
                int index = 1;
                foreach (Process p in Process.GetProcesses(Environment.MachineName))
                {
                    //此进程主窗口句柄不为NULL
                    if (p.MainWindowHandle != IntPtr.Zero)
                    {
                        Soft soft = new Soft
                        {
                            Handle = p.MainWindowHandle,
                            Title = p.MainWindowTitle,
                            Name = p.ProcessName,
                            Index = index
                        };
                        temp.Add(soft);
                        index++;
                    }
                }

                //委托UI线程
                Execute.OnUIThread(() =>
                {
                    //将缓存中的进程列表加入显示列表集合中
                    temp.ForEach(p=>SoftList.Add(p));
                });
            });
        }


        #region 程序列表集合
        ObservableCollection<Soft> softList;
        public ObservableCollection<Soft> SoftList
        {
            get
            {
                if (softList == null)
                {
                    softList = new ObservableCollection<Soft>();
                }
                return softList;
            }
            set
            {
                softList = value;
                OnPropertyChanged("SoftList");
            }
        }
        #endregion


        private bool startButtonEnabled = true;

        /// <summary>
        /// 启用 启动按钮
        /// </summary>
        public bool StartButtonEnabled
        {
            get { return startButtonEnabled; }
            set
            {
                startButtonEnabled = value;
                OnPropertyChanged("StartButtonEnabled");
            }
        }



        /// <summary>
        /// 保存操作
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    //关闭按钮
                    StartButtonEnabled = false;

                    //注册新的热键
                    //1.先注册 软件自身的隐藏 显示 快捷键
                    //2.注册 隐藏 显示软件的快捷键 （隐藏 和 快捷建 相同）

                    int selfkey = Settings.Default.SelfKey;
                    //读取 配置文件里面的 
                    int U = KeyInterop.VirtualKeyFromKey((Key)(selfkey));
                    HotKey hot = new HotKey(App.Current.MainWindow, HotKey.KeyFlags.MOD_CONTROL, U);
                    hot.OnHotKey += Self_OnHotKey;

                    int softkey = Settings.Default.SoftKey;
                    int O = KeyInterop.VirtualKeyFromKey((Key)(softkey));
                    HotKey hot2 = new HotKey(App.Current.MainWindow, HotKey.KeyFlags.MOD_CONTROL, O);
                    hot2.OnHotKey += Soft_OnHotKey;
                });
            }
        }

        bool SoftHide = false;
        /// <summary>
        /// 选中的软件隐藏或者显示
        /// </summary>
        private void Soft_OnHotKey()
        {
            if (SoftHide)//软件被隐藏
            {
                //把所有软件显示出来
                foreach (var item in SoftList)
                {
                    if (item.IsSelected)
                    {
                        Win32.ShowWindow(item.Handle, Win32.Sw_Show);
                    }
                }
                SoftHide = false;
            }
            else
            {
                //把所有软件隐藏
                foreach (var item in SoftList)
                {
                    if (item.IsSelected)
                    {
                        Win32.ShowWindow(item.Handle, Win32.Sw_Hide);
                    }
                }
                SoftHide = true;
            }
        }

        /// <summary>
        /// 隐藏或者显示自身
        /// </summary>
        private void Self_OnHotKey()
        {
            if (App.Current.MainWindow.IsVisible)
            {
                App.Current.MainWindow.Hide();
            }
            else
            {
                App.Current.MainWindow.Show();
            }
        }


        /// <summary>
        /// 清空选中
        /// </summary>
        public ICommand ClearCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    foreach (var item in SoftList)
                    {
                        item.IsSelected = false;
                    }
                });
            }
        }

    }
}
