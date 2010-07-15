using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace ATNET.Gui.Windows.Label
{
    class LabelAdorner:Adorner
    {
        private UIElement uiElement;
        private BarCode selectedBarCode;
        public LabelAdorner(UIElement element)
            : base(element)
        {
            this.uiElement = element;
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            Size rectSize = new Size(RenderSize.Width + 6, RenderSize.Height + 6);
            Rect rect = new Rect(new Point(-3, -3), rectSize);
            dc.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Blue, 1), rect);
            dc.DrawEllipse(Brushes.Red, new Pen(Brushes.Blue, 1), new Point(0, 0), 6, 6);
            dc.DrawEllipse(Brushes.Red, new Pen(Brushes.Blue, 1), new Point(0, this.ActualHeight), 6, 6);
            dc.DrawEllipse(Brushes.Red, new Pen(Brushes.Blue, 1), new Point(this.ActualWidth, this.ActualHeight), 6, 6);
            dc.DrawEllipse(Brushes.Red, new Pen(Brushes.Blue, 1), new Point(this.ActualWidth, 0), 6, 6);
        }

        protected override void OnPreviewMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!this.IsMouseCaptured) this.CaptureMouse();
                HitTesting(e.GetPosition(this));
                this.InvalidateVisual();
            }
            else
            {
                if (this.IsMouseCaptured) this.ReleaseMouseCapture();
            }
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            if (this.IsMouseCaptured) this.ReleaseMouseCapture();

            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.uiElement);
            if (adornerLayer != null)
            {
                adornerLayer.Remove(this);
            }
        }

        private void HitTesting(Point hitPoint)
        {
            bool hitConnectorFlag = false;

            DependencyObject hitObject = this.uiElement.InputHitTest(hitPoint) as DependencyObject;
            while (hitObject != null && hitObject.GetType() != typeof(Canvas))
            {
                if (hitObject is BarCode)
                {
                    selectedBarCode = hitObject as BarCode;
                    return;
                }
                hitObject = VisualTreeHelper.GetParent(hitObject);
            }
            selectedBarCode = null;
        }
    }
}
