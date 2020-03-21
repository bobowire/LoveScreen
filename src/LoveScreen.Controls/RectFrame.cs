using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoveScreen.Controls
{
    public class RectFrame : Control
    {
        static RectFrame()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RectFrame), new FrameworkPropertyMetadata(typeof(RectFrame)));
        }

        public RectFrame()
        {
        }



        public Brush RectFirstBrush
        {
            get { return (Brush)GetValue(RectFirstBrushProperty); }
            set { SetValue(RectFirstBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RectFirstBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RectFirstBrushProperty =
            DependencyProperty.Register("RectFirstBrush", typeof(Brush), typeof(RectFrame));



        public Brush RectSecondBrush
        {
            get { return (Brush)GetValue(RectSecondBrushProperty); }
            set { SetValue(RectSecondBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RectSecondBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RectSecondBrushProperty =
            DependencyProperty.Register("RectSecondBrush", typeof(Brush), typeof(RectFrame));




    }
}
