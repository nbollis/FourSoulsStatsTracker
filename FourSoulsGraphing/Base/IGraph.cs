using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing.Base
{
    internal interface IGraph
    {
        void Initialize();
        void RenderGraph(GraphData graphData);
    }
}
