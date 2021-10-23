using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace imotoAPI.Exceptions
{
    public class LoginNotUniqueException : Exception
    {
        public LoginNotUniqueException(string message) : base(message)
        {

        }
    }
}
