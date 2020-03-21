using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoveScreen.Windows.SystemDll
{
    static class Kernel32
    {
        const string DllName = "kernel32";

        [DllImport(DllName)]
        public static extern ushort GlobalAddAtom(string Text);

        [DllImport(DllName)]
        public static extern ushort GlobalDeleteAtom(ushort Atom);
    }
}
