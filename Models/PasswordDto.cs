using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class PasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
