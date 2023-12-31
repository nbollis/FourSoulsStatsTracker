using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphing.Util
{
    public static class ColorExtensions
    {
        public static Color HexToColor(this string hexCode)
        {
            if (hexCode.StartsWith("#"))
            {
                hexCode = hexCode.Substring(1);
            }

            if (hexCode.StartsWith("0x"))
            {
                hexCode = hexCode.Substring(2);
            }

            //if (hexCode.Length != 6)
            //{
            //    throw new GraphingException("Hex code must be 6 characters long");
            //}
            int r = int.Parse(hexCode.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int g = int.Parse(hexCode.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int b = int.Parse(hexCode.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(r, g, b);
        }
    }
}