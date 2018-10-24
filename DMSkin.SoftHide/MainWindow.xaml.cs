using DMSkin.SoftHide.Properties;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMSkin.SoftHide
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //从配置文件中读取存储的数据
            SoftKey.Text = Settings.Default.SoftKeyStr;
            SelfKey.Text = Settings.Default.SelfKeyStr;
        }

        /// <summary>
        /// 热键接受
        /// </summary>
        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string savetag = string.Empty;
                //数据展示
                textBox.Text = string.Empty;
                if (Keyboard.Modifiers == ModifierKeys.Control)
                {
                    textBox.Text = "Ctrl + ";
                    savetag = textBox.Text;
                }
                if (e.Key != Key.LeftCtrl && e.Key != Key.RightCtrl)
                {
                    textBox.Text += e.Key;
                    savetag = textBox.Text;
                }

                switch (textBox.Name)
                {
                    case "SoftKey"://其他软件
                        Settings.Default.SoftKey = (int)e.Key;
                        Settings.Default.SoftKeyStr = savetag;
                        break;
                    case "SelfKey"://自身
                        Settings.Default.SelfKey = (int)e.Key;
                        Settings.Default.SelfKeyStr = savetag;
                        break;
                }
                Settings.Default.Save();
            }
        }
    }
}
