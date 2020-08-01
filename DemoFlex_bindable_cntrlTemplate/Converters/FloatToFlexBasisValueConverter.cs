using System;
using System.Globalization;
using Xamarin.Forms;

namespace DemoFlex_bindable_cntrlTemplate.Converters
{
    public class FloatToFlexBasisValueConverter : IValueConverter
    {
        private readonly FlexBasis.FlexBasisTypeConverter _converter = new FlexBasis.FlexBasisTypeConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float doubleValue)
            {
                return _converter.ConvertFromInvariantString($"{doubleValue}%");
            }
            if (value is string stringValue)
            {
                return _converter.ConvertFromInvariantString(stringValue);
            }
            return new FlexBasis();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
