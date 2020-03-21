using LoveScreen.Windows.SystemDll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L_Windows = System.Windows;

namespace LoveScreen.Windows
{
    public class ScreenHelper
    {
        public static Bitmap CaptureInternal(Rectangle Region, bool IncludeCursor = false)
        {
            var bmp = new Bitmap(Region.Width, Region.Height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(Region.Location, Point.Empty, Region.Size, CopyPixelOperation.SourceCopy);

                if (IncludeCursor)
                    MouseCursor.Draw(g, P => new Point(P.X - Region.X, P.Y - Region.Y));

                g.Flush();
            }

            return bmp;
        }

        public static Bitmap CaptureFullScreen(bool IncludeCursor = false)
        {
            var bmp = new Bitmap((int)L_Windows.SystemParameters.PrimaryScreenWidth, (int)L_Windows.SystemParameters.PrimaryScreenHeight);
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bmp.Size, CopyPixelOperation.SourceCopy);

                if (IncludeCursor)
                    MouseCursor.Draw(g, P => new Point(P.X, P.Y));

                g.Flush();
            }
            return bmp;
        }

        public static void SetMousePos(int x, int y)
        {
            User32.SetCursorPos(x, y);
        }

        public static void GetVisualWindows()
        {

        }
    }
}
