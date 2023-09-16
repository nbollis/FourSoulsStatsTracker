using Graphing.Interfaces;
using Graphing.Util;

namespace Graphing.Data
{
    public class PieChartGraphData : ScottPlotGraphData, IOneDimensionalGraphData<double>
    {
        public double[] Values { get; }
        public string[] SeriesNames { get; }
        public string[] SeriesColors { get; }
        public PieChartGraphData(string title, ScottPlot.Plot plot, double[] values,
            string[] seriesColors, string[] seriesNames) : base(title, plot)
        {
            if (values.Length != seriesNames.Length || values.Length != seriesColors.Length)
                throw new GraphingException("Values, series names, and series colors must be the same length");

            Values = values;
            SeriesNames = seriesNames;
            SeriesColors = seriesColors;
        }
    }
}