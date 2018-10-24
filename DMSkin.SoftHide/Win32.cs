using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DMSkin.SoftHide
{
    public class Win32
    {
        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hwnd, int command);
        public const int Sw_Hide = 0;
        public const int Sw_Show = 1;
        protected static IntPtr Handles;
    }
}
