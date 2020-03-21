using LoveScreen.Windows.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveScreen.Windows.SystemDll
{
    static class NativeExtensions
    {
        public static Rectangle ToRectangle(this RECT R) => Rectangle.FromLTRB(R.Left, R.Top, R.Right, R.Bottom);
    }
}
