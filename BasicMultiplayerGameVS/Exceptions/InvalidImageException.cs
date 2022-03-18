using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMultiplayerGameVS.Exceptions
{
    public class InvalidImageException : System.Exception
    {
        public InvalidImageException() { }

        public InvalidImageException(string message)
            : base(message) { }
    }
}
