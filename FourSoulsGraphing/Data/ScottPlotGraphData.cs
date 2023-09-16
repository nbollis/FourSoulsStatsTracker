using ScottPlot;

namespace Graphing.Data
{
    /// <summary>
    /// Abstract class for all graph data which uses a ScottPlot plot to inherit from
    /// </summary>
    public abstract class ScottPlotGraphData : GraphData
    {
        public Plot Plot { get; set; }
        protected ScottPlotGraphData(string title, Plot plot) : base(title)
        {
            Plot = plot;
        }
    }
}