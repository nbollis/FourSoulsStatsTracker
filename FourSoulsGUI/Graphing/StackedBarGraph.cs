using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphing.Data;
using Graphing.Interfaces;
using Graphing.Util;
using ScottPlot;

namespace FourSoulsGUI
{
    public class StackedBarGraph : IGraph
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void RenderGraph(GraphData graphData, object plot)
        {
            StackedBarGraphData stackedBarGraphData = graphData as StackedBarGraphData ??
                                                      throw new GraphingException("Graph data must be of type StackedBarGraphData");
            WpfPlot wpfPlot = plot as WpfPlot ?? throw new GraphingException("Plot must be of type WpfPlot");

            wpfPlot.Plot.Clear();

            wpfPlot.Plot.AddBar(stackedBarGraphData.XValues, stackedBarGraphData.SeriesColors[0].HexToColor());
            wpfPlot.Plot.AddBar(stackedBarGraphData.YValues, stackedBarGraphData.SeriesColors[1].HexToColor());
            wpfPlot.Plot.SetAxisLimits(yMin: 0);
        }
    }
}
