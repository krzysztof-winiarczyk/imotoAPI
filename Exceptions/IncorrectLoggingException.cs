using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Exceptions
{
    public class IncorrectLoggingException : Exception
    {
        public IncorrectLoggingException(string message) : base(message)
        {

        }
    }
}
