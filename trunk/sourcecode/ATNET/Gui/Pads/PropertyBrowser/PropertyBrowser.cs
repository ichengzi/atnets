using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace ATNET.Gui.Pads.PropertyBrowser
{
    public class PropertyBrowser:PropertyGrid
    {
        public PropertyBrowser()
        {
            Attribute[] attribute=new Attribute[1];
            attribute[0] = new MyAttribute();
            this.BrowsableAttributes = new AttributeCollection(attribute);
        }
    }
}
