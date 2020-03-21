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
    public class WidthHeightToRectConvert : IMultiValueConverter
    {
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double offset = 0;
            if (parameter != null) offset = Convert.ToDouble(parameter);
            object ret = new Rect(0, 0, 0, 0);
            try
            {
                ret = new Rect(offset, offset, (double)values[0], (double)values[1]);
            }
            catch (Exception ex)
            {
            }
            return ret;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("不支持逆转换");
        }
    }
}
