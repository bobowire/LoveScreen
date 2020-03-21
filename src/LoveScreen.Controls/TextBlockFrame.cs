using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LoveScreen.Controls
{
    public class TextBlockFrame : Label
    {
        Geometry TextHighLightGeometry;
        Geometry TextGeometry;



        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(TextBlockFrame), new PropertyMetadata(new SolidColorBrush(Colors.Black)));



        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(TextBlockFrame), new PropertyMetadata(1.0));



        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(TextBlockFrame),new PropertyMetadata(new SolidColorBrush(Colors.White)));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBlockFrame), new PropertyMetadata(""));



        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            CreateText();
            // Draw the outline based on the properties that are set.
            drawingContext.DrawGeometry(Fill, new System.Windows.Media.Pen(Stroke, StrokeThickness), TextGeometry);
            // Draw the text highlight based on the properties that are set.
            //if (Highlight == true)
            {
                //drawingContext.DrawGeometry(null, new System.Windows.Media.Pen(Stroke, StrokeThickness), TextHighLightGeometry);
            }
        }
        private void CreateText()
        {
            getformattedText(Text);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Content = Text;
            Size ret = base.MeasureOverride(constraint);
            Content = "";
            return ret;
        }
        private void getformattedText(string str)
        {
            // Create the formatted text based on the properties set.
            FormattedText formattedText = new FormattedText(
                str,
                CultureInfo.GetCultureInfo("en-us"),
                System.Windows.FlowDirection.LeftToRight,
                new Typeface(
                    FontFamily,
                    FontStyle,
                    FontWeight,
                    FontStretch),
                FontSize,
                System.Windows.Media.Brushes.Black // This brush does not matter since we use the geometry of the text. 
                );

            this.Width = formattedText.Width;
            this.Height = formattedText.Height;
            // Build the geometry object that represents the text.
            //pg.AddGeometry(formattedText.BuildGeometry(new System.Windows.Point(5, 5)));
            TextGeometry = formattedText.BuildGeometry(new System.Windows.Point(0, 0));
            // Build the geometry object that represents the text hightlight.
            //if (Highlight == true)
            {
                TextHighLightGeometry = formattedText.BuildHighlightGeometry(new System.Windows.Point(0, 0));
            }
        }
    }
}
