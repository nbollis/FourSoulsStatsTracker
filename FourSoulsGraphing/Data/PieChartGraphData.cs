using Graphing.Interfaces;
using Graphing.Util;

namespace Graphing.Data
{
    public class PieChartGraphData : GraphData, IOneDimensionalGraphData<double>
    {
        public double[] Values { get; }

        public PieChartGraphData(string title, ScottPlot.Plot plot, double[] values,
            string[] seriesColors, string[] seriesNames) : base(title, seriesNames, seriesColors)
        {
            if (values.Length != seriesNames.Length || values.Length != seriesColors.Length)
                throw new GraphingException("Values, series names, and series colors must be the same length");

            Values = values;
        }


        public override IEnumerable<LegendItem> GetLegendItems()
        {
            return SeriesColors.Select((t, i) => new LegendItem(SeriesNames[i], t));
        }
    }
}