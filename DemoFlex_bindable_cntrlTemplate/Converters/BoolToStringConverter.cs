using System;
using System.Globalization;
using Xamarin.Forms;

namespace DemoFlex_bindable_cntrlTemplate.Converters
{
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                if (boolValue)
                {
                    return "Menu_Expand.png";
                }
                else
                {
                    return "Menu_Collapse.png";
                }
            }
            return "Menu_Expand.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
