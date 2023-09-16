using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing.Util
{
    public class GraphingException : Exception
    {
        public GraphingException(string message) : base(message)
        {
        }

        public GraphingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GraphingException()
        {
        }
    }
}
