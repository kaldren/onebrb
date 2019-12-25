using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Exceptions
{
    public class EmailAddressNotFoundException : Exception
    {
        public EmailAddressNotFoundException() { }

        public EmailAddressNotFoundException(string message) : base (message) { }

        public EmailAddressNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
