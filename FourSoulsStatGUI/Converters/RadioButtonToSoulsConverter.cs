using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatGUI
{
    public class RadioButtonToSoulsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            // Will intitiate all radio buttons as off. 
            // TODO: To implement a game editor, this converter will need to check the value within the GameDataPerPlayer to determine to set it as true or false
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter.ToString();
        }
    }
}
