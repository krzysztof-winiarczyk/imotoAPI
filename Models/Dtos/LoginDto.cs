using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Login is required")]
        [MaxLength(45, ErrorMessage = "Login is too long")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(64, ErrorMessage = "Password is too long")]
        public string Password { get; set; }
    }
}
