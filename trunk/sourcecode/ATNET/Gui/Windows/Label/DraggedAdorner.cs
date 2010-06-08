using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;

namespace ATNET.Gui.Windows
{
    public class DraggedAdorner:Adorner
    {
        private AdornerLayer adornerLayer;

        public DraggedAdorner(AdornerLayer adornerLayer,UIElement uiElement)
            : base(uiElement)
        {
            this.adornerLayer = adornerLayer;
            this.adornerLayer.Add(this);
        }

        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
        {
            Rect rect = new Rect(0, 0, 100, 50);
            return rect.Size;
        }
    }
}
