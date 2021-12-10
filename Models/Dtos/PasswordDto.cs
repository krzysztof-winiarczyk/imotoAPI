using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class PasswordDto
    {
        [Required(ErrorMessage = "OldPassword is required")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "NewPassword is required")]
        [MaxLength(64, ErrorMessage = "NewPassword too long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*)(?=.*[#@$!%*?^&])(?=.*[01-9])[A-Za-z#@$!%*?^&01-9]{8,64}$",
           ErrorMessage = "NewPassword must contain at least 1 lowercase letter, 1 uppercase letter, 1 special char, 1 digit and must be minimum 8 character long")]
        public string NewPassword { get; set; }
    }
}
