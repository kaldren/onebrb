using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Exceptions
{
    public class CouldNotGetProfileException : Exception
    {
        public CouldNotGetProfileException() { }

        public CouldNotGetProfileException(string message) : base (message) { }

        public CouldNotGetProfileException(string message, Exception inner) : base(message, inner) { }
    }
}
