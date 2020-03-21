using LoveScreen.Windows.Procs;
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
    /// RecordGifWidnow.xaml 的交互逻辑
    /// </summary>
    public partial class RecordGifWidnow : Window
    {
        //HotkeyListener listen = new HotkeyListener();
        public RecordGifWidnow(double left, double top, double width, double height)
        {
            InitializeComponent();
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
            //listen.HotkeyReceived += Listen_HotkeyReceived;
        }

        private void Listen_HotkeyReceived(int obj)
        {
            MessageBox.Show($"热键值：{obj}");
        }
    }
}
