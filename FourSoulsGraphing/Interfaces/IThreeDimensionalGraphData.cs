using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing.Interfaces
{
    internal interface IThreeDimensionalGraphData<T> : ITwoDimensionalGraphData<T>
    {
        public double[] ZValues { get; }
    }
}
