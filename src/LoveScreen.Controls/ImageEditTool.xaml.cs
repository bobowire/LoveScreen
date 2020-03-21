using LoveScreen.Controls.Models;
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
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoveScreen.Controls
{
    /// <summary>
    /// ImageEditTool.xaml 的交互逻辑
    /// </summary>
    public partial class ImageEditTool : UserControl
    {
        public static readonly RoutedEvent SelectedColorChagnedEvent = ColorPicker.SelectedColorChagnedEvent.AddOwner(typeof(ImageEditTool));

        public static readonly RoutedEvent SelectedSizeChagnedEvent = SizePicker.SelectedSizeChagnedEvent.AddOwner(typeof(ImageEditTool));

        public static readonly DependencyProperty SelectedColorProperty = ColorPicker.SelectedColorProperty.AddOwner(typeof(ImageEditTool));

        public static readonly DependencyProperty SelectedSizeProperty = SizePicker.SelectedSizeProperty.AddOwner(typeof(ImageEditTool));

        public static readonly RoutedEvent DrawModeStyleChangedEvent = EventManager.RegisterRoutedEvent("DrawModeStyleChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ImageEditTool));

        public static readonly RoutedEvent OkBtnClickEvent = EventManager.RegisterRoutedEvent("OkBtnClick",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ImageEditTool));

        public static readonly RoutedEvent CancelBtnClickEvent = EventManager.RegisterRoutedEvent("CancelBtnClick",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ImageEditTool));

        public static readonly RoutedEvent TopBtnClickEvent = EventManager.RegisterRoutedEvent("TopBtnClick",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ImageEditTool));

        public static readonly RoutedEvent LongScreenBtnClickEvent = EventManager.RegisterRoutedEvent("LongScreenBtnClick",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ImageEditTool));

        public static readonly RoutedEvent RecordBtnClickEvent = EventManager.RegisterRoutedEvent("RecordBtnClick",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ImageEditTool));

        public event RoutedEventHandler DrawModeStyleChanged
        {
            add
            {
                base.AddHandler(ImageEditTool.DrawModeStyleChangedEvent, value);
            }

            remove
            {
                base.RemoveHandler(ImageEditTool.DrawModeStyleChangedEvent, value);
            }
        }
        public event RoutedEventHandler OkBtnClick
        {
            add
            {
                base.AddHandler(ImageEditTool.OkBtnClickEvent, value);
            }

            remove
            {
                base.RemoveHandler(ImageEditTool.OkBtnClickEvent, value);
            }
        }
        public event RoutedEventHandler CancelBtnClick
        {
            add
            {
                base.AddHandler(ImageEditTool.CancelBtnClickEvent, value);
            }

            remove
            {
                base.RemoveHandler(ImageEditTool.CancelBtnClickEvent, value);
            }
        }
        public event RoutedEventHandler TopBtnClick
        {
            add
            {
                base.AddHandler(ImageEditTool.TopBtnClickEvent, value);
            }

            remove
            {
                base.RemoveHandler(ImageEditTool.TopBtnClickEvent, value);
            }
        }
        public event RoutedEventHandler LongScreenBtnClick
        {
            add
            {
                base.AddHandler(ImageEditTool.LongScreenBtnClickEvent, value);
            }

            remove
            {
                base.RemoveHandler(ImageEditTool.LongScreenBtnClickEvent, value);
            }
        }
        public event RoutedEventHandler RecordBtnClick
        {
            add
            {
                base.AddHandler(ImageEditTool.RecordBtnClickEvent, value);
            }

            remove
            {
                base.RemoveHandler(ImageEditTool.RecordBtnClickEvent, value);
            }
        }

        public static IEnumerable<DynamicRenderer> DrawTools { get; } = new DynamicRenderer[] {
            //  矩形
            new RectangleDynamicRenderer(),
            new EllipseDynamicRenderer(),
            new DynamicRenderer()
        };


        public DrawMode DrawModeStyle
        {
            get { return (DrawMode)GetValue(DrawModeStyleProperty); }
            set { SetValue(DrawModeStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DrawModeStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawModeStyleProperty =
            DependencyProperty.Register("DrawModeStyle", typeof(DrawMode), typeof(ImageEditTool), new PropertyMetadata(DrawMode.Pen, DrawModeStyleChangedCallback));

        public static void DrawModeStyleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageEditTool tool = (ImageEditTool)d;
            RoutedEventArgs args = new RoutedEventArgs(ImageEditTool.DrawModeStyleChangedEvent, e.NewValue);
            tool.RaiseEvent(args);
        }

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public int SelectedSize
        {
            get { return (int)GetValue(SelectedSizeProperty); }
            set { SetValue(SelectedSizeProperty, value); }
        }

        public ImageEditTool()
        {
            InitializeComponent();

        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = (Rectangle)sender;
            DrawModeStyle = (DrawMode)Convert.ToInt32(rectangle.Tag);
        }

        private void TopButton_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ImageEditTool.TopBtnClickEvent, e.OriginalSource);
            RaiseEvent(args);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ImageEditTool.CancelBtnClickEvent, e.OriginalSource);
            RaiseEvent(args);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ImageEditTool.OkBtnClickEvent, e.OriginalSource);
            RaiseEvent(args);
        }
        private void LongScreenButton_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ImageEditTool.LongScreenBtnClickEvent, e.OriginalSource);
            RaiseEvent(args);
        }
        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ImageEditTool.RecordBtnClickEvent, e.OriginalSource);
            RaiseEvent(args);
        }
    }

    public enum DrawMode
    {
        Rect = 0,
        Line = 1,
        Pen = 2
    }
}
