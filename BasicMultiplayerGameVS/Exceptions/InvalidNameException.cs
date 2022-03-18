using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMultiplayerGameVS.Exceptions
{
    public class InvalidNameException : System.Exception
    {
        public InvalidNameException() { }

        public InvalidNameException(string message)
            : base(message) { }
    }
}
