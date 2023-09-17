using FourSoulsDataConnection.DataBase;
using Graphing.Data;

namespace Graphing.Interfaces
{
    public interface IGraph
    {
        public void Initialize();
        public void RenderGraph(GraphData graphData, object plot);
    }
}