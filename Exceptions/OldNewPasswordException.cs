using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Exceptions
{
    public class OldNewPasswordException : Exception
    {
        public OldNewPasswordException(string message) : base(message)
        {

        }
    }
}
