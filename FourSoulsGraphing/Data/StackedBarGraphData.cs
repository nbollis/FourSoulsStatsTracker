using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphing.Interfaces;
using Graphing.Util;

namespace Graphing.Data
{
    public class StackedBarGraphData : GraphData, ITwoDimensionalGraphData<double>
    {
        public StackedBarGraphData(string title, double[] upperSeries, double[]lowerSeries, string[] seriesNames, string[] seriesColors)
            : base(title, seriesNames, seriesColors)
        {
            if (upperSeries.Length != lowerSeries.Length)
                throw new GraphingException("Upper and lower series must be the same length");

            XValues = upperSeries;
            YValues = lowerSeries;
        }

        public override IEnumerable<LegendItem> GetLegendItems()
        {
            throw new NotImplementedException();
        }

        public double[] XValues { get; }
        public double[] YValues { get; }
    }
}
