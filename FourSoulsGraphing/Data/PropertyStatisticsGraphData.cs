using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;
using Graphing;
using Graphing.Data;
using ScottPlot;

namespace Graphing
{
    public class PropertyStatisticsGraphData : ScottPlotGraphData
    {
        public PropertyStatistics PropertyStatistics { get; set; }

        public PropertyStatisticsGraphData(PropertyStatistics propertyStatistics, Plot plot)
            : base(propertyStatistics.PropertyName, plot, new string[] { }, new string[] { })
        {
            PropertyStatistics = propertyStatistics;
        }

        public override IEnumerable<LegendItem> GetLegendItems()
        {
            return Enumerable.Empty<LegendItem>();
        }
    }
}
