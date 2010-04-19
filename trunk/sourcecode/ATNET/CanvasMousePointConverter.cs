using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace ATNET
{
    public class CanvasMousePointConverter:IValueConverter
    {
        public object Convert(object value, Type targertType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                if ((double)value > 0)
                {
                    return (int)((double)value);
                }
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
