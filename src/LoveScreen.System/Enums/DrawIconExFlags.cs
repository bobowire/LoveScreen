using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveScreen.Windows.Enums
{
    enum DrawIconExFlags
    {
        Compat = 0x04,
        DefaultSize = 0x08,
        Image = 0x02,
        Mask = 0x01,
        NoMirror = 0x10,
        Normal = Image | Mask
    }
}
