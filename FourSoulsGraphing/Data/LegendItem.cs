using System.Drawing;
using System.Windows;

namespace Graphing
{
    public class LegendItem
    {
        public string SeriesName { get; set; }
        public Color SeriesColor { get; set; }

        public LegendItem(string seriesName, Color seriesColor)
        {
            SeriesName = seriesName;
            SeriesColor = seriesColor;
        }

        public LegendItem(string seriesName, string colorHexCode)
        {
            SeriesName = seriesName;
            SeriesColor =ColorTranslator.FromHtml(colorHexCode);
        }

        
    }
}
