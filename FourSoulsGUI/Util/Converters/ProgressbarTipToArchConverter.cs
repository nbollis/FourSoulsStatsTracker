using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FourSoulsDataConnection;
using Newtonsoft.Json.Linq;

namespace FourSoulsGUI
{
    public class ProgressbarTipToArchConverter : IMultiValueConverter
    {
        // first is initial value, second is total value
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var original = (int)values[0];
            var total = (int)values[1];

            if (original == 0)
                return 0;

            var incrementBy = total / 16.0;
            var finalValue = original + incrementBy;
            return finalValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
