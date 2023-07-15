using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsGUI
{
    public class RadioButtonToSoulsConverter : BaseValueConverter<RadioButtonToSoulsConverter>
    {
        // value is what is found in object, parameter is what is in xaml
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Will intitiate all radio buttons as off. 
            // TODO: To implement a game editor, this converter will need to check the value within the GameDataPerPlayer to determine to set it as true or false

            if ((int)value == Int32.Parse(parameter.ToString()))
                return true;


            return false;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string paramString = parameter.ToString() ?? throw new ArgumentNullException();
            int souls = Int32.Parse(paramString);
            return souls;
        }
    }
}
