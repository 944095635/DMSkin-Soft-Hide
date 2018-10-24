using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSkin.SoftHide.Model
{
    public class Soft:ViewModelBase
    {
        private string handle;
        /// <summary>
        /// 句柄
        /// </summary>
        public string Handle
        {
            get { return handle; }
            set
            {
                handle = value;
                OnPropertyChanged("Handle");
            }
        }

        private string name;
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private int index;

        /// <summary>
        /// 序号
        /// </summary>
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged("Index");
            }
        }

        private bool isSelected;
        /// <summary>
        /// 选中
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

    }
}
