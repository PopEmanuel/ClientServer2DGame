using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMultiplayerGameVS.Exceptions
{
    public class InvalidMovementException : System.Exception
    {
        public InvalidMovementException() { }

        public InvalidMovementException(string message)
            : base(message) { }
    }
}
