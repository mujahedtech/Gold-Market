using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Gold_Market.Convertors
{
    class VisibilityInverse : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Data = "";

            if (value.ToString() == "Hidden")
            {
                Data = "Visible";
            }
            if (value.ToString() == "Visible")
            {
                Data = "Hidden";
            }
            return Data;

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

