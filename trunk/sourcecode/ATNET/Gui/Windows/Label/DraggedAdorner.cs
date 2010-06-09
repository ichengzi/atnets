using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace ATNET.Gui.Windows
{
    public class DraggedAdorner:Adorner
    {
        private AdornerLayer adornerLayer;
        private double left;
        private double top;

        public DraggedAdorner(AdornerLayer adornerLayer,UIElement uiElement)
            : base(uiElement)
        {
            this.adornerLayer = adornerLayer;
            this.adornerLayer.Add(this);
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            Rect rect = new Rect(this.AdornedElement.DesiredSize);

            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            double renderRadius = 5.0;

            drawingContext.DrawEllipse(renderBrush, renderPen, rect.TopLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, rect.TopRight, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, rect.BottomLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, rect.BottomRight, renderRadius, renderRadius);

        }

        public void SetPosition(double left, double top)
        {
            // -1 and +13 align the dragged adorner with the dashed rectangle that shows up
            // near the mouse cursor when dragging.
            this.left = left - 1;
            this.top = top + 13;
            if (this.adornerLayer != null)
            {
                this.adornerLayer.Update(this.AdornedElement);
            }
        }

        public void Detach()
        {
            this.adornerLayer.Remove(this);
        }

    }
}
