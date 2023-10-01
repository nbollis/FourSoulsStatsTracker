using System;
using System.Collections.Generic;
using System.Drawing;
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
            wpfPlot.Plot.Width = 400;
            wpfPlot.Plot.Height = 300;
            var totalBar = wpfPlot.Plot.AddBar(stackedBarGraphData.XValues, stackedBarGraphData.SeriesColors[0].HexToColor());
            totalBar.Label = "Somebody Else Won";
            var theirWinBar = wpfPlot.Plot.AddBar(stackedBarGraphData.ZValues, stackedBarGraphData.SeriesColors[2].HexToColor());
            theirWinBar.Label = "They Won";
            var winBar = wpfPlot.Plot.AddBar(stackedBarGraphData.YValues, stackedBarGraphData.SeriesColors[1].HexToColor());
            winBar.Label = $"{graphData.Title} Won";
            wpfPlot.Plot.XTicks(stackedBarGraphData.SeriesNames);
            wpfPlot.Plot.XAxis.TickLabelStyle(rotation: 45);
            wpfPlot.Plot.YLabel("Games");
            wpfPlot.Plot.Title("Total Games and Wins by Player");
            wpfPlot.Plot.Legend(location: Alignment.UpperRight );

            
            wpfPlot.Plot.Style(dataBackground: System.Drawing.Color.Transparent, figureBackground: System.Drawing.Color.Transparent, grid: Color.Transparent);
            wpfPlot.Render();
        }
    }
}
