using Graphing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsGUI
{
    public class GraphViewModel : BaseViewModel
    {
        private GraphData graphData;

        public GraphData GraphData
        {
            get => graphData;
            set => SetProperty(ref graphData, value);
        }
    }
}
