using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LoveScreen.Controls.Converts
{
    public class ToolsMarginConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                Rect hightLightRect = (Rect)values[0];
                double toolWidth = (double)values[1];
                double toolHeight = (double)values[2] + 5;
                double screenWidth = (double)values[3];
                double screenHeight = (double)values[4];

                double marginX = 0;
                double marginY = 0;

                if (hightLightRect.Right - toolWidth < 0)
                {
                    marginX = 0;
                }
                else
                {
                    marginX = hightLightRect.Right - toolWidth;
                }

                if (hightLightRect.Bottom + toolHeight < screenHeight)
                {
                    marginY = hightLightRect.Bottom;
                }
                else if (hightLightRect.Top > toolHeight)
                {
                    marginY = hightLightRect.Top - toolHeight;
                }
                else if (hightLightRect.Top < toolHeight)
                {
                    marginY = hightLightRect.Top + 5;
                }
                return new Thickness(marginX, marginY, 0, 0);
            }
            catch
            {
                return new Thickness(0, 0, 0, 0);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
