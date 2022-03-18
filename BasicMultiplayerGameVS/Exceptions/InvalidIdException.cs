using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMultiplayerGameVS.Exceptions
{
    public class InvalidIdException : System.Exception
    {
        public InvalidIdException() { }

        public InvalidIdException(string message)
            : base(message) { }
    }
}
