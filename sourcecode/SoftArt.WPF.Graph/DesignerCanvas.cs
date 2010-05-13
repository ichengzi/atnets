using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Threading;
using System.ComponentModel;

namespace SoftArt.WPF.Graph
{
    public partial class DesignerCanvas : Canvas
    {
        private Point? rubberbandSelectionStartPoint = null;

        private SelectionService selectionService;
        public SelectionService SelectionService
        {
            get
            {
                if (selectionService == null)
                    selectionService = new SelectionService(this);

                return selectionService;
            }
        }

        private ISelectable currentItem;
        public ISelectable CurrentItem
        {

            get
            {
                if (currentItem == null)
                {
                    return GetSeletedItem();
                }
                return currentItem;
            }
            set
            {
                currentItem = value;
                OnSelectedItemChanged(currentItem);
            }
        }

        private bool showGrid = true;
        /// <summary>
        /// 是否显示网格
        /// </summary>
        public bool ShowGrid
        {
            get { return showGrid; }
            set { showGrid = value; }
        }

        public delegate void SelectedItemChangedEventHandle(object sender, ISelectable item);
        public event SelectedItemChangedEventHandle SelectedItemChangedEvent;

        public static readonly DependencyProperty MousePointProperty = DependencyProperty.Register("MousePoint", typeof(Point), typeof(Canvas));
        [Browser("MousePoint","鼠标坐标"),Category("自定义")] 
        /// <summary>
        /// 鼠标在Canvas上移动的坐标
        /// </summary>
        public Point MousePoint
        {
            get { return (Point)GetValue(MousePointProperty); }
            set { SetValue(MousePointProperty, value); }
        }
        [Browser("BackColor", "画布背景色"), Category("自定义")] 
        public Brush BackColor
        {
            get { return this.Background; }
            set { this.Background = value; }
        }
        [Browser("ChildCount", "子项个数"), Category("自定义"),Description("画布中包含的子项的个数")] 
        public int ChildCount
        {
            get { return this.Children.Count; }
        }
        [Browser("Name", "名称"), Category("自定义")]
        public new string Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        [Browser("Width", "宽度"), Category("自定义")]
        public new double Width
        {
            get { return this.Width; }
            set { this.Width = value; }
        }

        private delegate void CoordinateRateChangeEventHandle(object sender, double rate);
        private event CoordinateRateChangeEventHandle CoordinateRateChangeEvent;
        private double coordinateRate = 1.0;
        [Browsable(true)]
        /// <summary>
        /// Canvas坐标变化的系数
        /// </summary>
        public double CoordinateRate
        {
            set
            {
                if (coordinateRate != value)
                {
                    OnCoordinateRateChange(value / coordinateRate);
                    coordinateRate = value;
                }
            }
        }
        private void OnCoordinateRateChange(double rate)
        {
            if (CoordinateRateChangeEvent != null)
            {
                CoordinateRateChangeEvent(this, rate);
            }
        }

        private void OnSelectedItemChanged(ISelectable item)
        {

            if (SelectedItemChangedEvent != null)
            {
                SelectedItemChangedEvent(this, item);
            }
        }

        private delegate void ArgsEventHandler(double rate);

        protected void DesignerCanvas_CoordinateRateChangeEvent(object sender, double rate)
        {
            //this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ArgsEventHandler(RefreshBackground), rate);
            RefreshBackground(rate);
            foreach (UIElement element in this.Children)
            {
                DesignerItem designerItem = element as DesignerItem;
                if (designerItem != null)
                {
                    double newWidth = designerItem.ActualWidth * rate;
                    if (newWidth < designerItem.MinWidth)
                    {
                        designerItem.MinWidth = newWidth;
                    }
                    designerItem.Width = newWidth;
                    double newHeight = designerItem.ActualHeight * rate;
                    if (newHeight < designerItem.MinHeight)
                    {
                        designerItem.MinHeight = newHeight;
                    }
                    designerItem.Height = newHeight;
                    Canvas.SetLeft(designerItem, Canvas.GetLeft(designerItem) * rate);
                    Canvas.SetTop(designerItem, Canvas.GetTop(designerItem) * rate);
                }
            }

        }

        private void RefreshBackground(double rate)
        {
            DrawingBrush drawingBrush = ((DrawingBrush)this.Background).Clone();
            Rect rect = (Rect)drawingBrush.GetValue(DrawingBrush.ViewportProperty);
            drawingBrush.SetValue(DrawingBrush.ViewportProperty, new Rect(0, 0, rect.Width * rate, rect.Height * rate));
            this.Background = drawingBrush;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Source == this)
            {
                // in case that this click is the start of a 
                // drag operation we cache the start point
                this.rubberbandSelectionStartPoint = new Point?(e.GetPosition(this));

                // if you click directly on the canvas all 
                // selected items are 'de-selected'
                SelectionService.ClearSelection();
                Focus();
                e.Handled = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // if mouse button is not pressed we have no drag operation, ...
            if (e.LeftButton != MouseButtonState.Pressed)
                this.rubberbandSelectionStartPoint = null;

            // ... but if mouse button is pressed and start
            // point value is set we do have one
            if (this.rubberbandSelectionStartPoint.HasValue)
            {
                // create rubberband adorner
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                if (adornerLayer != null)
                {
                    RubberbandAdorner adorner = new RubberbandAdorner(this, rubberbandSelectionStartPoint);
                    if (adorner != null)
                    {
                        adornerLayer.Add(adorner);
                    }
                }
            }
            e.Handled = true;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            DragObject dragObject = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (dragObject != null && !String.IsNullOrEmpty(dragObject.Xaml))
            {
                DesignerItem newItem = null;
                Object content = XamlReader.Load(XmlReader.Create(new StringReader(dragObject.Xaml)));

                if (content != null)
                {
                    newItem = new DesignerItem();
                    newItem.Content = content;

                    Point position = e.GetPosition(this);

                    if (dragObject.DesiredSize.HasValue)
                    {
                        Size desiredSize = dragObject.DesiredSize.Value;
                        newItem.Width = desiredSize.Width;
                        newItem.Height = desiredSize.Height;

                        DesignerCanvas.SetLeft(newItem, Math.Max(0, position.X - newItem.Width / 2));
                        DesignerCanvas.SetTop(newItem, Math.Max(0, position.Y - newItem.Height / 2));
                    }
                    else
                    {
                        DesignerCanvas.SetLeft(newItem, Math.Max(0, position.X));
                        DesignerCanvas.SetTop(newItem, Math.Max(0, position.Y));
                    }

                    Canvas.SetZIndex(newItem, this.Children.Count);
                    this.Children.Add(newItem);
                    SetConnectorDecoratorTemplate(newItem);

                    //update selection
                    this.SelectionService.SelectItem(newItem);
                    this.currentItem = GetSeletedItem();
                    newItem.Focus();
                }

                //e.Handled = true;
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size();

            foreach (UIElement element in this.InternalChildren)
            {
                double left = Canvas.GetLeft(element);
                double top = Canvas.GetTop(element);
                left = double.IsNaN(left) ? 0 : left;
                top = double.IsNaN(top) ? 0 : top;

                //measure desired size for each child
                element.Measure(constraint);

                Size desiredSize = element.DesiredSize;
                if (!double.IsNaN(desiredSize.Width) && !double.IsNaN(desiredSize.Height))
                {
                    size.Width = Math.Max(size.Width, left + desiredSize.Width);
                    size.Height = Math.Max(size.Height, top + desiredSize.Height);
                }
            }
            // add margin 
            size.Width += 10;
            size.Height += 10;
            return size;
        }

        private void SetConnectorDecoratorTemplate(DesignerItem item)
        {
            if (item.ApplyTemplate() && item.Content is UIElement)
            {
                ControlTemplate template = DesignerItem.GetConnectorDecoratorTemplate(item.Content as UIElement);
                Control decorator = item.Template.FindName("PART_ConnectorDecorator", item) as Control;
                if (decorator != null && template != null)
                    decorator.Template = template;
            }
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);

            this.MousePoint = e.GetPosition(this);
        }

        public ISelectable GetSeletedItem()
        {
            List<ISelectable> selectedList = this.SelectionService.CurrentSelection;
            foreach (DesignerItem item in selectedList)
            {
                if (item.IsSelected)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
