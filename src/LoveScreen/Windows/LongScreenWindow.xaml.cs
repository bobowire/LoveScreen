using LoveScreen.Windows.Models;
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
    /// LongScreenWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LongScreenWindow : Window, IExcuteHotKey
    {
        bool isDown = false;
        Point downPoint;
        double m_thickness = 2;


        public LongScreenWindow(double left, double top, double width, double height)
        {
            InitializeComponent();
            this.Left = left - m_thickness;
            this.Top = top - m_thickness;
            this.Width = width + m_thickness * 2;
            this.Height = height + m_thickness * 2;
            CommandManager.RegisterClassInputBinding(typeof(LongScreenWindow), new KeyBinding(ApplicationCommands.Close, new KeyGesture(Key.Escape)));
            CommandManager.RegisterClassCommandBinding(typeof(LongScreenWindow), new CommandBinding(ApplicationCommands.Close, CloseCommand_Executed));
            //Procs.HotkeyListener.Instance = this;
            HotkeyListener.SetHotKeyHandle(this, Keys.F2, Modifiers.None);
        }

        public LongScreenWindow()
        {
            InitializeComponent();
            this.Left = 150 - m_thickness;
            this.Top = 150 - m_thickness;
            this.Width = 150 + m_thickness * 2;
            this.Height = 150 + m_thickness * 2;
            CommandManager.RegisterClassInputBinding(typeof(LongScreenWindow), new KeyBinding(ApplicationCommands.Close, new KeyGesture(Key.Escape)));
            CommandManager.RegisterClassCommandBinding(typeof(LongScreenWindow), new CommandBinding(ApplicationCommands.Close, CloseCommand_Executed));
            //Procs.HotkeyListener.Instance = this;
        }

        bool isTop = false;

        private void Path_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UIElement el = (UIElement)sender;
            downPoint = e.GetPosition(el);

            if (Math.Abs(downPoint.Y - Height) < 20 && Math.Abs(downPoint.X - Width) > 6 && downPoint.X > 6)
            {
                isTop = false;
                el.CaptureMouse();
                isDown = true;
            }
            else if (downPoint.Y < 10)
            {
                isTop = true;
                el.CaptureMouse();
                isDown = true;
            }
            else
            {
                this.DragMove();
            }
        }

        private void Path_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPoint = e.GetPosition(C_FrameRect);
            if (isDown)
            {
                if (isTop)
                {
                    this.Top = this.PointToScreen(newPoint).Y - m_thickness / 2;
                }
                else
                {
                    if (newPoint.Y > 50)
                    {
                        this.Height = newPoint.Y + m_thickness * 2;
                    }
                }
            }
            else
            {
                if (Math.Abs(newPoint.Y - Height) < 20 && Math.Abs(newPoint.X - Width) > 6 && newPoint.X > 6)
                {
                    C_SizeFrame.Cursor = Cursors.SizeNS;
                }
                else
                {
                    C_SizeFrame.Cursor = Cursors.SizeAll;
                }
            }

        }

        private void Path_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UIElement el = (UIElement)sender;
            isDown = false;
            el.ReleaseMouseCapture();
        }
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        List<BitmapImage> imageList = new List<BitmapImage>();
        private void TextBlockFrame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            BitmapImage bitmapSource = ConvertHelper.ToBitmapImage(ScreenHelper.CaptureInternal(new System.Drawing.Rectangle((int)(this.Left + m_thickness), (int)(this.Top + m_thickness), (int)(this.Width - m_thickness * 2), (int)(this.Height - m_thickness * 2))));
            imageList.Add(bitmapSource);
            ClipImage();

            this.Show();
        }

        private void ClipImage()
        {
            //全像素比较（高准确）
            //MatchByComparePix();
            //最大差异化比价(高性能）
            MatchByMaxDiff();
        }
        private void MatchByComparePix()
        {
            int matchedRow = 0;
            if (imageList.Count >= 2)
            {

                BitmapImage preImage = imageList[imageList.Count - 2];
                BitmapImage curImage = imageList[imageList.Count - 1];
                //获取上一次截图的像素点
                byte[] prePixels = new byte[(int)preImage.PixelWidth * (int)preImage.PixelHeight * preImage.Format.BitsPerPixel / 8];
                preImage.CopyPixels(prePixels, (int)(preImage.PixelWidth * preImage.Format.BitsPerPixel / 8), 0);
                //获取本次截图的像素点
                byte[] curPixels = new byte[(int)curImage.PixelWidth * (int)curImage.PixelHeight * curImage.Format.BitsPerPixel / 8];
                curImage.CopyPixels(curPixels, (int)(curImage.PixelWidth * curImage.Format.BitsPerPixel / 8), 0);
                bool isMatchAllCol = true;
                int startRow = curImage.PixelHeight / 3 * 2;
                for (; startRow >= 0; startRow--)
                {
                    int preRow = preImage.PixelHeight - 1;
                    int curRow = startRow;
                    isMatchAllCol = true;
                    int minNum = 10; int num = 0;
                    for (; num < 30 && preRow >= 0 && curRow >= 0; preRow--, curRow--, num++)
                    {
                        int col = 0;
                        int difCount = 0;
                        for (; col < preImage.PixelWidth; col += 2)
                        {
                            int preIndex = preRow * curImage.PixelWidth * curImage.Format.BitsPerPixel / 8 + col * curImage.Format.BitsPerPixel / 8;
                            int curIndex = curRow * curImage.PixelWidth * curImage.Format.BitsPerPixel / 8 + col * curImage.Format.BitsPerPixel / 8;
                            if (prePixels[preIndex] != curPixels[curIndex] || prePixels[preIndex + 1] != curPixels[curIndex + 1] || prePixels[preIndex + 2] != curPixels[curIndex + 2])
                            {
                                difCount++;
                                if (difCount > 10)
                                {
                                    isMatchAllCol = false;
                                    break;
                                }
                            }

                        }
                        if (!isMatchAllCol) break;
                    }
                    if (isMatchAllCol)
                    {
                        if (num < minNum) isMatchAllCol = false;
                        break;
                    }
                }
                if (isMatchAllCol)
                {
                    matchedRow = startRow;
                    curPixels = curPixels.Skip((matchedRow + 1) * (int)preImage.PixelWidth * preImage.Format.BitsPerPixel / 8).ToArray();
                    WriteableBitmap bitmap = new WriteableBitmap(curImage.PixelWidth, curImage.PixelHeight - startRow - 1, 96, 96, curImage.Format, null);
                    bitmap.WritePixels(new Int32Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight), curPixels, (int)curImage.PixelWidth * curImage.Format.BitsPerPixel / 8, 0);

                    imageList.Remove(curImage);
                    imageList.Add(ConvertHelper.ToBitmapImage(bitmap));
                }
            }
        }

        private void MatchByMaxDiff()
        {
            if (imageList.Count >= 2)
            {

                BitmapImage preImage = imageList[imageList.Count - 2];
                BitmapImage curImage = imageList[imageList.Count - 1];
                //获取上一次截图的像素点
                byte[] prePixels = new byte[(int)preImage.PixelWidth * (int)preImage.PixelHeight * preImage.Format.BitsPerPixel / 8];
                preImage.CopyPixels(prePixels, (int)(preImage.PixelWidth * preImage.Format.BitsPerPixel / 8), 0);
                //获取本次截图的像素点
                byte[] curPixels = new byte[(int)curImage.PixelWidth * (int)curImage.PixelHeight * curImage.Format.BitsPerPixel / 8];
                curImage.CopyPixels(curPixels, (int)(curImage.PixelWidth * curImage.Format.BitsPerPixel / 8), 0);

                int matchRowCount = 100;
                int[] diffVlaues = new int[preImage.PixelWidth];
                int pixbytes = preImage.Format.BitsPerPixel / 8;
                int oneRowBytesCount = preImage.PixelWidth * pixbytes;
                //行
                for (int i = 0; i < matchRowCount && i < preImage.PixelHeight - 1; i++)
                {
                    //列
                    for (int j = 0; j < preImage.PixelWidth; j++)
                    {
                        int startIndex = prePixels.Length - (i + 1) * oneRowBytesCount + j * pixbytes;
                        diffVlaues[j] += Math.Abs(prePixels[startIndex] - prePixels[startIndex - oneRowBytesCount])
                            + Math.Abs(prePixels[startIndex + 1] - prePixels[startIndex + 1 - oneRowBytesCount])
                            + Math.Abs(prePixels[startIndex + 2] - prePixels[startIndex + 2 - oneRowBytesCount]);
                    }
                }

                //寻找差异化最大的一列
                int colIndex = diffVlaues.ToList().IndexOf(diffVlaues.Max());
                List<byte> colValues = new List<byte>();
                int startRowIndex = preImage.PixelHeight > matchRowCount ? preImage.PixelHeight - matchRowCount : 0;
                for (int row = startRowIndex; row < preImage.PixelHeight; row++)
                {
                    int startIndex = row * oneRowBytesCount + colIndex * pixbytes;
                    colValues.Add(prePixels[startIndex]);
                    colValues.Add(prePixels[startIndex + 1]);
                    colValues.Add(prePixels[startIndex + 2]);
                }

                //对比差异化最大的一列
                List<byte> curColValues = new List<byte>();
                int curPixbytes = curImage.Format.BitsPerPixel / 8;
                int curOneRowBytesCount = curImage.PixelWidth * curPixbytes;
                for (int row = 0; row < curImage.PixelHeight; row++)
                {
                    int startIndex = row * curOneRowBytesCount + colIndex * curPixbytes;
                    curColValues.Add(curPixels[startIndex]);
                    curColValues.Add(curPixels[startIndex + 1]);
                    curColValues.Add(curPixels[startIndex + 2]);
                }
                bool isMatch = false;
                int matchRow = 0;
                int errorCount = 0;
                for (int i = errorCount * 3, j = 0; i < curColValues.Count - 2 && j < colValues.Count - 2; i += 3, j += 3)
                {
                    if (curColValues[i] == colValues[j] && curColValues[i + 1] == colValues[j + 1] && curColValues[i + 2] == colValues[j + 2])
                    {
                        if (j == colValues.Count - 3)
                        {
                            isMatch = true;
                            matchRow = i / 3;
                            break;
                        }
                    }
                    else
                    {
                        i = errorCount * 3;
                        errorCount += 1;
                        j = -3;
                    }
                }
                if (isMatch)
                {
                    curPixels = curPixels.Skip((matchRow) * (int)preImage.PixelWidth * preImage.Format.BitsPerPixel / 8).ToArray();
                    WriteableBitmap bitmap = new WriteableBitmap(curImage.PixelWidth, curImage.PixelHeight - matchRow, 96, 96, curImage.Format, null);
                    bitmap.WritePixels(new Int32Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight), curPixels, (int)curImage.PixelWidth * curImage.Format.BitsPerPixel / 8, 0);
                    imageList.Remove(curImage);
                    imageList.Add(ConvertHelper.ToBitmapImage(bitmap));
                }
            }
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (imageList.Count > 0)
            {
                DrawingVisual visual = new DrawingVisual();
                DrawingContext context = visual.RenderOpen();
                double height = 0;
                double width = imageList[0].Width;
                for (int i = 0; i < imageList.Count; i++)
                {
                    BitmapImage img = imageList[i];
                    context.DrawImage(img, new Rect(0, height + 1, img.Width, img.Height));
                    context.DrawImage(img, new Rect(0, height, img.Width, img.Height));
                    height += img.Height;
                }
                context.Close();
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(visual);
                Clipboard.SetImage(renderTargetBitmap);
            }
            this.Close();
        }

        void IExcuteHotKey.ExcuteHotKeyCommand(int id)
        {
            TextBlockFrame_MouseDown(null, null);
        }

        public bool IsEffective()
        {
            return this.IsVisible;
        }
    }
}
