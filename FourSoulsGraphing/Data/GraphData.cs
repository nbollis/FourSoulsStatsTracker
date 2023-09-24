namespace Graphing.Data
{
    /// <summary>
    /// Abstract class for all graph data to inherit from
    /// </summary>
    public abstract class GraphData
    {
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