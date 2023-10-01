using System.Diagnostics;
using System.Drawing;
using Graphing.Util;

namespace Graphing.Data
{
    /// <summary>
    /// Abstract class for all graph data to inherit from
    /// </summary>
    public abstract class GraphData
    {

        #region Static Members

        static GraphData()
        {
            DrawingColorConverter = new System.Drawing.ColorConverter();
        }

        public static System.Drawing.ColorConverter DrawingColorConverter { get; }

        public static System.Drawing.Color GetColorFromString(string p)
        {
            var color = DrawingColorConverter.ConvertFromString(p);
            return color is null ? throw new GraphingException("Could not convert string to color") : (Color)color;
        }

        #endregion


        public string Title { get; }

        public string[] SeriesNames { get; set; }
        public string[] SeriesColors { get; set; }

        protected GraphData(string title, string[] seriesNames, string[] seriesColors)
        {
            Title = title;
            SeriesNames = seriesNames;
            SeriesColors = seriesColors;
        }

        protected GraphData()
        {
            Title = "Untitled Graph";
        }


        public abstract IEnumerable<LegendItem> GetLegendItems();

        public List<LegendItem> GetLegendItemsList() => GetLegendItems().ToList();
    }
}