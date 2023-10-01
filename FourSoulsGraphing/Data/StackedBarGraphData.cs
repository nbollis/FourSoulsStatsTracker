using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphing.Interfaces;
using Graphing.Util;

namespace Graphing.Data
{
    public class StackedBarGraphData : GraphData, IThreeDimensionalGraphData<double>
    {
        public StackedBarGraphData(string title, double[] xValues, double[] yValues, double[]zValues, string[] seriesNames, string[] seriesColors)
            : base(title, seriesNames, seriesColors)
        {
            XValues = xValues;
            YValues = yValues;
            ZValues = zValues;
        }

        public override IEnumerable<LegendItem> GetLegendItems()
        {
            return Enumerable.Empty<LegendItem>();
        }

        public double[] XValues { get; }
        public double[] YValues { get; }
        public double[] ZValues { get; }
    }
}
