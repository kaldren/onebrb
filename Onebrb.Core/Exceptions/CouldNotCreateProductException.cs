using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Exceptions
{
    public class CouldNotCreateProductException : Exception
    {
        public CouldNotCreateProductException()
        {
        }
        public CouldNotCreateProductException(string message) : base(message) { }

        public CouldNotCreateProductException(string message, Exception inner) : base(message, inner) { }
    }
}
