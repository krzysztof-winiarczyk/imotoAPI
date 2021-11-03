using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Exceptions
{
    public class NotAllowedException : Exception
    {
        public NotAllowedException(string message) : base(message)
        {

        }
    }
}
