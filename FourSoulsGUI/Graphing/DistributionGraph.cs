using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FourSoulsDataConnection;
using Graphing;
using Graphing.Data;
using Graphing.Interfaces;
using Graphing.Util;
using MathNet.Numerics.Distributions;
using MathNet.Numerics;
using ScottPlot;
using ScottPlot.Drawing;
using Color = System.Drawing.Color;


namespace FourSoulsGUI.Graphing
{
    public class DistributionGraph : IGraph
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void RenderGraph(GraphData graphData, object plot)
        {
            PropertyStatisticsGraphData statsGraphData = (graphData as PropertyStatisticsGraphData ??
                                                     throw new GraphingException(
                                                         "Graph data must be of type PropertyStatistics"));
            PropertyStatistics statsData = statsGraphData.PropertyStatistics;
            WpfPlot wpfPlot = plot as WpfPlot ?? throw new GraphingException("Plot must be of type WpfPlot");
            Color graphColor = Color.Black;
            Color markerColor = Color.DarkGray;

            wpfPlot.Plot.Clear();
         
            // parse data
            var normalDistribution = new Normal(statsData.Mean, statsData.StandardDeviation);
            int numPoints = 100;
            double[] xValues = new double[numPoints];
            double[] yValues = new double[numPoints];

            double minX = statsData.Mean - 3 * statsData.StandardDeviation; // Adjust the range as needed
            double maxX = statsData.Mean + 3 * statsData.StandardDeviation;

            double step = (maxX - minX) / (numPoints - 1);
            for (int i = 0; i < numPoints; i++)
            {
                xValues[i] = minX + i * step;
                yValues[i] = normalDistribution.Density(xValues[i]);
            }

            // general plot
            wpfPlot.Plot.Title($"{statsData.PropertyName} Distribution");
            wpfPlot.Plot.XAxis2.Line(false);
            wpfPlot.Plot.YAxis2.Line(false);
            wpfPlot.Plot.YAxis.SetBoundary(0);

            // data specific labels and annotations
            var hSpan = wpfPlot.Plot.AddHorizontalSpan(statsData.Value - statsData.StandardDeviation, statsData.Value + statsData.StandardDeviation, GraphData.GetColorFromString(statsGraphData.SeriesColors.First()));
            hSpan.HatchStyle = HatchStyle.SmallCheckerBoard;
            wpfPlot.Plot.AddVerticalLine(statsData.Value, GraphData.GetColorFromString(statsGraphData.SeriesColors.First()), 4);


            var plt = wpfPlot.Plot.AddScatter(xValues, yValues, graphColor, 3, 0, MarkerShape.none, LineStyle.DashDotDot);

            // add lines for 1, and 2 sigma
            for (int i = 1; i < 3; i++)
            {
                var positiveX = statsData.Mean + i * statsData.StandardDeviation;
                var negativeX = statsData.Mean - i * statsData.StandardDeviation;
                var positiveY = normalDistribution.Density(positiveX);
                var negativeY = normalDistribution.Density(negativeX);

                wpfPlot.Plot.AddLine(positiveX, 0, positiveX, positiveY, markerColor, 1);
                wpfPlot.Plot.AddLine(negativeX, 0, negativeX, negativeY, markerColor, 1);
            }

            wpfPlot.Plot.AddLine(statsData.Mean, 0, statsData.Mean, normalDistribution.Density(statsData.Mean));


            wpfPlot.Render();

        }
    }
}
