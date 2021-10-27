using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Exceptions
{
    public class WatchedUserException : Exception
    {
        public WatchedUserException(string message) : base(message)
        {

        }
    }
}
