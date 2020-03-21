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
using System.Windows.Shapes;

namespace LoveScreen.Windows
{
    /// <summary>
    /// TopImage.xaml 的交互逻辑
    /// </summary>
    public partial class TopImage : Window
    {
        public BitmapSource BackgroundImage
        {
            get { return (BitmapSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(BitmapSource), typeof(TopImage));


        public TopImage(BitmapSource bitmapSource, double left, double top) : base()
        {
            InitializeComponent();
            CommandManager.RegisterClassCommandBinding(typeof(TopImage), new CommandBinding(ApplicationCommands.Close, CloseCommand_Executed));
            CommandManager.RegisterClassInputBinding(typeof(TopImage), new KeyBinding(ApplicationCommands.Close, new KeyGesture(Key.Escape)));
            BackgroundImage = bitmapSource;
            double border = 5;
            this.Left = left - border;
            this.Top = top - border;
            this.Width = bitmapSource.Width + border * 2;
            this.Height = bitmapSource.Height + border * 2;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
