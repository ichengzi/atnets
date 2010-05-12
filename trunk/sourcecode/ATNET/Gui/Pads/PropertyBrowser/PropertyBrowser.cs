using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using SoftArt.WPF.Graph;
using System.Reflection;
using System.Collections;

namespace ATNET.Gui.Pads.PropertyBrowser
{
    public class PropertyBrowser:PropertyGrid
    {
        public PropertyBrowser()
        {
        }
    }

    public class CustomProperty : ICustomTypeDescriptor
    {
        //当前选择对象
        private object currentSelectObject;
        private Dictionary<string, string> objectAttribs = new Dictionary<string, string>();
        public CustomProperty(object selectObject)
        {
            currentSelectObject = selectObject;
            Type t = currentSelectObject.GetType();
            PropertyInfo[] propertys = t.GetProperties();
            for (int i = 0; i < propertys.Length; i++)
            {
                PropertyInfo p = propertys[i];
                object[] attribute = p.GetCustomAttributes(false);
                for (int j = 0; j < attribute.Length; j++)
                {
                    if (attribute[j] is BrowserAttribute)
                    {
                        objectAttribs.Add(((BrowserAttribute)attribute[j]).Name, ((BrowserAttribute)attribute[j]).Caption);
                        break;
                    }
                }
            }
        }
        #region ICustomTypeDescriptor Members
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(currentSelectObject);
        }
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(currentSelectObject);
        }
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(currentSelectObject);
        }
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(currentSelectObject);
        }
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(currentSelectObject);
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(currentSelectObject);
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(currentSelectObject, editorBaseType);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(currentSelectObject, attributes);
        }
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(currentSelectObject);
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            List<CustomPropertyDescriptor> tmpPDCLst = new List<CustomPropertyDescriptor>();
            PropertyDescriptorCollection tmpPDC = TypeDescriptor.GetProperties(currentSelectObject, attributes);
            IEnumerator tmpIe = tmpPDC.GetEnumerator();
            CustomPropertyDescriptor tmpCPD;
            PropertyDescriptor tmpPD;
            while (tmpIe.MoveNext())
            {
                tmpPD = tmpIe.Current as PropertyDescriptor;
                if (objectAttribs.ContainsKey(tmpPD.Name))
                {
                    tmpCPD = new CustomPropertyDescriptor(currentSelectObject, tmpPD);
                    tmpCPD.SetDisplayName(objectAttribs[tmpPD.Name]);
                    tmpCPD.SetCategory(tmpPD.Category);
                    tmpPDCLst.Add(tmpCPD);
                }
            }
            return new PropertyDescriptorCollection(tmpPDCLst.ToArray());
        }
        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(currentSelectObject);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return currentSelectObject;
        }
        #endregion

        class CustomPropertyDescriptor : PropertyDescriptor
        {
            private PropertyDescriptor prop;
            private object component;

            public CustomPropertyDescriptor(object component, PropertyDescriptor pPD)
                : base(pPD)
            {
                category = base.Category;
                displayName = base.DisplayName;
                prop = pPD;
                this.component = component;
            }
            private string category;
            public override string Category
            {
                get { return category; }
            }
            private string displayName;
            public override string DisplayName
            {
                get { return displayName; }
            }
            public void SetDisplayName(string dispalyName)
            {
                this.displayName = dispalyName;
            }
            public void SetCategory(string category)
            {
                this.category = category;
            }
            public override bool CanResetValue(object component)
            {
                return prop.CanResetValue(component);
            }

            public override Type ComponentType
            {
                get { return prop.ComponentType; }
            }

            public override object GetValue(object component)
            {
                return prop.GetValue(component);
            }

            public override bool IsReadOnly
            {
                get { return prop.IsReadOnly; }
            }

            public override Type PropertyType
            {
                get { return prop.PropertyType; }
            }
            public override void ResetValue(object component) { prop.ResetValue(component); }
            public override void SetValue(object component, object value) { prop.SetValue(component, value); }
            public override bool ShouldSerializeValue(object component)
            {
                return prop.ShouldSerializeValue(component);
            }
        }
    }
}
