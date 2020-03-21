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
    /// <summary>
    /// SizePicker.xaml 的交互逻辑
    /// </summary>
    public partial class SizePicker : UserControl
    {
        public static readonly RoutedEvent SelectedSizeChagnedEvent = EventManager.RegisterRoutedEvent("SelectedSizeChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(SizePicker));

        public event RoutedEventHandler SelectedSizeChanged
        {
            add
            {
                base.AddHandler(SizePicker.SelectedSizeChagnedEvent, value);
            }

            remove
            {
                base.RemoveHandler(SizePicker.SelectedSizeChagnedEvent, value);
            }
        }



        public int SelectedSize
        {
            get { return (int)GetValue(SelectedSizeProperty); }
            set { SetValue(SelectedSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedSizeProperty =
            DependencyProperty.Register("SelectedSize", typeof(int), typeof(SizePicker), new PropertyMetadata(1, SelctedIndexChangedCallback));



        public SizePicker()
        {
            InitializeComponent();
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle ellipse = (Rectangle)sender;
            SelectedSize = Convert.ToInt32(ellipse.Tag);
        }
        private static void SelctedIndexChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SizePicker picker = (SizePicker)d;
            int newValue = (int)e.NewValue;
            RoutedEventArgs args = new RoutedEventArgs(SizePicker.SelectedSizeChagnedEvent, newValue);
            picker.RaiseEvent(args);
        }
    }
}
