using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace SoftArt.WPF.Styles.Common
{
    public class ScrollViewerRuler : ScrollViewer
    {
        public static readonly DependencyProperty MousePointProperty = DependencyProperty.Register("MousePoint", typeof(Point), typeof(ScrollViewerRuler));
        public Point MousePoint
        {
            get { return (Point)GetValue(MousePointProperty); }
            set { SetValue(MousePointProperty, value); }
        }

        protected override void OnPreviewMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
            MousePoint = e.GetPosition(this);
        }
    }
}
