using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveScreen.Windows.Enums
{
    enum WindowStyles : long
    {
        Child = 0x40000000,
        ToolWindow = 0x00000080,
        AppWindow = 0x00040000,
        SizeBox = 0x00040000L
    }
}
