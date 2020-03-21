using LoveScreen.Windows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoveScreen.Windows.SystemDll
{
    static class DwmApi
    {
        const string DllName = "dwmapi.dll";

        [DllImport(DllName)]
        public static extern int DwmGetWindowAttribute(IntPtr Window, int Attribute, out bool Value, int Size);

        [DllImport(DllName)]
        public static extern int DwmGetWindowAttribute(IntPtr Window, int Attribute, ref RECT Value, int Size);
    }
}
