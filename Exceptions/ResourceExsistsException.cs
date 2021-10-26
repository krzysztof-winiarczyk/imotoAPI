using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Exceptions
{
    public class ResourceExsistsException : Exception
    {
        public ResourceExsistsException(string message) : base(message)
        {

        }
    }
}
