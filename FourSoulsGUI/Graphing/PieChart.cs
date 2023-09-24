using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Graphing.Data;
using Graphing.Interfaces;
using Graphing.Util;
using Plotly.NET;
using ScottPlot;
using Color = Plotly.NET.Color;
using HorizontalAlignment = System.Windows.HorizontalAlignment;

namespace FourSoulsGUI.Graphing
{
    public class PieChart : IGraph
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void RenderGraph(GraphData graphData, object plot)
        {
            PieChartGraphData pieChartGraphData = graphData as PieChartGraphData ??
                                                   throw new GraphingException("Graph data must be of type PieChartGraphData");
            WpfPlot wpfPlot = plot as WpfPlot ?? throw new GraphingException("Plot must be of type WpfPlot");

            wpfPlot.Plot.Clear();

            wpfPlot.Plot.SetAxisLimitsX(-75, 100);

            var pie = wpfPlot.Plot.AddPie(pieChartGraphData.Values);
            pie.SliceFillColors = pieChartGraphData.SeriesColors.Select(p => p.HexToColor()).ToArray();
            pie.DonutSize = 0.5;

            if (graphData.SeriesNames.Length <= 10)
                pie.ShowValues = true;

            //var legend = wpfPlot.Plot.Legend();
            //legend.Location = Alignment.MiddleRight;
            //legend.FixedLineWidth = false;
            
            wpfPlot.Plot.Style(dataBackground: System.Drawing.Color.Transparent, figureBackground: System.Drawing.Color.Transparent);


            wpfPlot.Render();
        }
    }
}
