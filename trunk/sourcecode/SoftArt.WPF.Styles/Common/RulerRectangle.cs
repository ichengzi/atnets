using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Threading;

namespace SoftArt.WPF.Styles.Common
{
    public class RulerRectangle:Shape
    {
        public RulerOrientation Orientation
        {
            get { return (RulerOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(RulerOrientation), typeof(RulerRectangle));

        protected override System.Windows.Media.Geometry DefiningGeometry
        {
            get
            {
                Geometry g = new RectangleGeometry(new Rect(new Size(this.ActualWidth, this.ActualHeight)));
                return g;
            }
        }

        public static readonly DependencyProperty RulerLineProperty = DependencyProperty.Register("RulerLine", typeof(Point), typeof(RulerRectangle));
        /// <summary>
        /// 标尺的坐标
        /// </summary>
        public Point RulerLine
        {
            get { return (Point)GetValue(RulerLineProperty); }
            set 
            { 
                SetValue(RulerLineProperty, value);
                OnRulerLineChanged(value);
            }
        }

        private delegate void RulerLineChangedEventHandler(object sender, Point point);

        private event RulerLineChangedEventHandler RulerLineChangedEvent;

        protected void OnRulerLineChanged(Point point)
        {
            if (RulerLineChangedEvent != null)
            {
                RulerLineChangedEvent(this, point);
            }
        }


        public RulerRectangle()
        {
            this.RulerLineChangedEvent += new RulerLineChangedEventHandler(RulerRectangle_RulerLineChangedEvent);
        }

        protected void RulerRectangle_RulerLineChangedEvent(object sendeisr, Point point)
        {
            this.InvalidateVisual();
        }

        private delegate void ArgsEventHandle(DrawingContext drawingContext);

        protected override void OnRender(DrawingContext drawingContext)
        {
            //base.OnRender(drawingContext);
            Pen pen = new Pen();
            SolidColorBrush penColor = new SolidColorBrush(Colors.Black);
            penColor.Freeze();
            pen.Brush = penColor;
            pen.Thickness = 1;
            pen.Freeze();
            if (this.Orientation == RulerOrientation.Vertical)
            {
                DrawVerticalRuler(drawingContext);
                drawingContext.DrawLine(pen, new Point(15, 0), new Point(15, this.ActualHeight));
            }
            else
            {
                DrawHorizontalRuler(drawingContext);
                drawingContext.DrawLine(pen, new Point(0, 15), new Point(this.ActualWidth, 15));
            }

            if (RulerLine.X > 0 && Orientation == RulerOrientation.Horizontal)
            {
                DrawHorizontalMovingRuler(drawingContext);

            }
            if (RulerLine.Y > 0 && Orientation == RulerOrientation.Vertical)
            {
                DrawVerticalMovingRuler(drawingContext);
            }
            
        }

        private void DrawHorizontalMovingRuler(DrawingContext drawingContext)
        {
            Pen pen = new Pen();
            SolidColorBrush penColor = new SolidColorBrush(Colors.Red);
            pen.Brush = penColor;
            pen.Thickness = 1;
            penColor.Freeze();
            pen.Freeze();
            //drawingContext.DrawLine(pen, new Point(RulerLine.X, 0), new Point(RulerLine.X, 15));
            drawingContext.DrawGeometry(Brushes.Red, pen, new LineGeometry(new Point(RulerLine.X, 0), new Point(RulerLine.X, 15)));
        }

        private void DrawVerticalMovingRuler(DrawingContext drawingContext)
        {
            Pen pen = new Pen();
            SolidColorBrush penColor = new SolidColorBrush(Colors.Red);
            pen.Brush = penColor;
            pen.Thickness = 1;
            penColor.Freeze();
            pen.Freeze();
            //drawingContext.DrawLine(pen, new Point(0, RulerLine.Y), new Point(15, RulerLine.Y));
            drawingContext.DrawGeometry(Brushes.Red, pen, new LineGeometry(new Point(0, RulerLine.Y), new Point(15, RulerLine.Y)));
        }

        private void DrawVerticalRuler(DrawingContext drawingContext)
        {
            int yCount = (int)this.ActualHeight;
        
            for (int i = 1; i < yCount; i++)
            {
                Pen p = new Pen(new SolidColorBrush(Colors.Black), 0.5);
                int lineLenth = 5;
                if (i % 40 == 0)
                {
                    lineLenth = 15;
                    p.Thickness = 1;
                    //drawingContext.DrawLine(p, new Point(0, i), new Point(lineLenth, i));
                    drawingContext.DrawGeometry(Brushes.Black, p, new LineGeometry(new Point(0, i), new Point(lineLenth, i)));
                }
                else if (i % 20 == 0)
                {
                    //drawingContext.DrawLine(p, new Point(10, i), new Point(10 + lineLenth, i));
                    drawingContext.DrawGeometry(Brushes.Black, p, new LineGeometry(new Point(10, i), new Point(10 + lineLenth, i)));
                }
                if (i % 40 == 0)
                {
                    int label = i / 40;
                    drawingContext.DrawText(new FormattedText(label.ToString(),
              CultureInfo.GetCultureInfo("en-us"),
              FlowDirection.LeftToRight,
              new Typeface("Verdana"),
              8, Brushes.Black),
    new Point(lineLenth - 10, i + 5));
                }
            }
        }

        private void DrawHorizontalRuler(DrawingContext drawingContext)
        {
            int yCount = (int)this.ActualWidth;
            for (int i = 1; i < yCount; i++)
            {
                Pen p = new Pen(new SolidColorBrush(Colors.Black), 0.5);
                int lineLenth = 5;
                if (i % 40 == 0)
                {
                    p = new Pen(Brushes.Black, 1);
                    lineLenth = 15;
                    //drawingContext.DrawLine(p, new Point(i, 0), new Point(i, lineLenth));
                    drawingContext.DrawGeometry(Brushes.Black, p, new LineGeometry(new Point(i, 0), new Point(i, lineLenth)));
                }
                else if (i % 20 == 0)
                {
                    //drawingContext.DrawLine(p, new Point(i, 10), new Point(i, lineLenth + 10));
                    drawingContext.DrawGeometry(Brushes.Black, p, new LineGeometry(new Point(i, 10), new Point(i, lineLenth + 10)));
                }
                if (i % 40 == 0)
                {
                    int label = i / 40;
                    drawingContext.DrawText(new FormattedText(label.ToString(),
              CultureInfo.GetCultureInfo("en-us"),
              FlowDirection.LeftToRight,
              new Typeface("Verdana"),
              8, Brushes.Black),
    new Point(i + 5, lineLenth - 10));
                }
            }
        }
    }

    public enum RulerOrientation
    {
        Horizontal,
        Vertical
    }
}
