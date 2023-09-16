using Graphing.Data;
using Graphing.Interfaces;
using Graphing.Util;

namespace Graphing.Graphs
{
    public class PieChart : IGraph
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void RenderGraph(GraphData graphData)
        {
            PieChartGraphData scottPlotGraphData = graphData as PieChartGraphData ??
                                                   throw new GraphingException(
                                                       "Graph data must be of type ScottPlotGraphData");

            var pie = scottPlotGraphData.Plot.AddPie(scottPlotGraphData.Values);
            pie.SliceFillColors = scottPlotGraphData.SeriesColors.Select(p => p.HexToColor()).ToArray();
            pie.DonutSize = 0.7;
        }
    }
}