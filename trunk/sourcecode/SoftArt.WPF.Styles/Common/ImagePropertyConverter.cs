using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SoftArt.WPF.Styles
{
    public class ImagePropertyConverter:IValueConverter
    {
        private static double rate = 1;
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                if (parameter.ToString() == "H")
                {
                    return 45 / rate;
                }
                else
                {
                    rate = (double)value / 60;
                    return 60;
                }
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
