using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;
using Graphing;
using Graphing.Data;
using Graphing.Interfaces;
using Graphing.Util;
using MathNet.Numerics.Distributions;
using MathNet.Numerics;


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
            PropertyStatistics statsData = (graphData as PropertyStatisticsGraphData ??
                                            throw new GraphingException(
                                                "Graph data must be of type PropertyStatistics")).PropertyStatistics;

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

            var chart = Plotly.NET.Line.init();


            
            Line<double, double, string>(xValues, yValues)
                .WithTitle($"Winrate {statsData.Value.Round(2)}%");


            chart.
            GenericChartExtensions.Show(chart);



        }
    }
}
