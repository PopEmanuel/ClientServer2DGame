using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMultiplayerGameVS.Exceptions
{
    public class InvalidShapeException : System.Exception
    {
        public InvalidShapeException() { }

        public InvalidShapeException(string message)
            : base(message) { }
    }
}
