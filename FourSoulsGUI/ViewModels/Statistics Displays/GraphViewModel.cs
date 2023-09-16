using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using Graphing.Interfaces;
using Graphing.Data;

namespace FourSoulsGUI
{
    public class GraphViewModel : BaseViewModel
    {
        private GraphData graphData = null!;

        private IGraph plot = null!;

        public IGraph Plot
        {
            get => plot;
            set => SetProperty(ref plot, value);
        }

        public GraphData GraphData
        {
            get => graphData;
            set
            {
                if (graphData != value)
                {
                    SetProperty(ref graphData, value);
                    Plot.RenderGraph(graphData);
                }
            }
        }

        public GraphViewModel(IGraph plot, GraphData data)
        {
            Plot = plot;
            GraphData = data;
        }

        public GraphViewModel()
        {
        }
    }
}
