using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoveScreen.Windows.Models
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(int Dimension)
        {
            Left = Top = Right = Bottom = Dimension;
        }
    }
}
