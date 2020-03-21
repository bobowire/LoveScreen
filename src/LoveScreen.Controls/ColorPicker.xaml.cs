using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker : UserControl
    {

        public static readonly RoutedEvent SelectedColorChagnedEvent = EventManager.RegisterRoutedEvent(
            "SelectedColorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorPicker));

        public event RoutedEventHandler SelectedColorChanged
        {
            add
            {
                base.AddHandler(ColorPicker.SelectedColorChagnedEvent, value);
            }

            remove
            {
                base.RemoveHandler(ColorPicker.SelectedColorChagnedEvent, value);
            }
        }

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorPicker), new PropertyMetadata(Colors.Red, SelctedColorChangedCallback));



        public ObservableCollection<Color> AllowColors
        {
            get { return (ObservableCollection<Color>)GetValue(AllowColorsProperty); }
            set { SetValue(AllowColorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllowColors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowColorsProperty =
            DependencyProperty.Register("AllowColors", typeof(ObservableCollection<Color>), typeof(ColorPicker), new PropertyMetadata(new ObservableCollection<Color>()));



        public ColorPicker()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = (Rectangle)sender;
            SelectedColor = ((SolidColorBrush)rectangle.Fill).Color;
        }
        private static void SelctedColorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker picker = (ColorPicker)d;
            RoutedEventArgs args = new RoutedEventArgs(ColorPicker.SelectedColorChagnedEvent, e.NewValue);
            picker.RaiseEvent(args);
        }
    }
}
