using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Gold_Market.Convertors
{
    class VisibilityConvertorString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string Data = "";

            if (value.ToString() == "Hidden")
            {
                Data = "Hidden";
            }
            if (value.ToString() == "Visible")
            {
                Data = "Visible";
            }
            return Data;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
