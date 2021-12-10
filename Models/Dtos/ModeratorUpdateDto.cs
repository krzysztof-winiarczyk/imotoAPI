using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class ModeratorUpdateDto
    {
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "Email too long")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(45, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [MaxLength(15, ErrorMessage = "PhoneNumber is too long")]
        [RegularExpression(@"^[01-9\+]*$", ErrorMessage = "Phone number not valid")]
        public string PhoneNumber { get; set; }
    }
}
