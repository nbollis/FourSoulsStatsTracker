using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FourSoulsGUI
{
    public class ColorToSolidColorBrushConverter : BaseValueConverter<ColorToSolidColorBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case Color color:
                    return new System.Windows.Media.SolidColorBrush(color);
                case System.Drawing.Color color:
                {
                    var col = Color.FromArgb(color.A, color.R, color.G, color.B);
                    return new System.Windows.Media.SolidColorBrush(col);
                }
                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value is System.Windows.Media.SolidColorBrush)
            {
                return ((System.Windows.Media.SolidColorBrush)value).Color;
            }
            return null;
        }
    }
}
