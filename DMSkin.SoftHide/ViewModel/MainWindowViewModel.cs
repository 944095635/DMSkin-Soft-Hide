using DMSkin.SoftHide.Model;
using DMSkin.WPF;
using DMSkin.WPF.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
                            Handle = p.MainWindowHandle.ToString(),
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


        #region 程序列表
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


        /// <summary>
        /// 保存操作
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    //需要保存 勾选的程序 和 热键配置


                });
            }
        }



        /// <summary>
        /// 全选
        /// </summary>
        public ICommand AllSelectedCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    foreach (var item in SoftList)
                    {
                        item.IsSelected = true;
                    }
                });
            }
        }

    }
}
