using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsGUI
{
    public class DoubleToPercentStringConverter : BaseValueConverter<DoubleToPercentStringConverter>
    {
        public override object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double doubleValue = (double)value;
            return $"{doubleValue}%";
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            string stringValue = (string)value;
            stringValue = stringValue.Replace("%", "");
            return double.Parse(stringValue);
        }
    }
}
