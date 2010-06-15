using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace ATNET.Gui.Windows
{
    public class DraggedAdorner:Adorner
    {
        private AdornerLayer adornerLayer;
        private ContentPresenter contentPresenter;
        private double left;
        private double top;

        public DraggedAdorner(AdornerLayer adornerLayer, UIElement uiElement, DataTemplate dragDropTemplate)
            : base(uiElement)
        {
            this.contentPresenter = new ContentPresenter();
            this.contentPresenter.ContentTemplate = dragDropTemplate;
            this.adornerLayer = adornerLayer;
            this.adornerLayer.Add(this);
        }

        //protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        //{
        //    Rect rect = new Rect(this.AdornedElement.DesiredSize);

        //    SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
        //    renderBrush.Opacity = 0.2;
        //    Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
        //    double renderRadius = 5.0;

        //    drawingContext.DrawEllipse(renderBrush, renderPen, rect.TopLeft, renderRadius, renderRadius);
        //    drawingContext.DrawEllipse(renderBrush, renderPen, rect.TopRight, renderRadius, renderRadius);
        //    drawingContext.DrawEllipse(renderBrush, renderPen, rect.BottomLeft, renderRadius, renderRadius);
        //    drawingContext.DrawEllipse(renderBrush, renderPen, rect.BottomRight, renderRadius, renderRadius);

        //}

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

        protected override Size MeasureOverride(Size constraint)
        {
            this.contentPresenter.Measure(constraint);
            return this.contentPresenter.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.contentPresenter.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.contentPresenter;
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(this.left, this.top));

            return result;
        }


        public void Detach()
        {
            this.adornerLayer.Remove(this);
        }

    }
}
