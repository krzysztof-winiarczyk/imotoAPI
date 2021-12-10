using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class UserGetDto
    {
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Login is required")]
        [MinLength(5, ErrorMessage = "Login too short")]
        [MaxLength(45, ErrorMessage = "Login too long")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "Email too long")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(64, ErrorMessage = "Password too long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*)(?=.*[#@$!%*?^&])(?=.*[01-9])[A-Za-z#@$!%*?^&01-9]{8,64}$",
            ErrorMessage = "Passowrd must contain at least 1 lowercase letter, 1 uppercase letter, 1 special char, 1 digit and must be minimum 8 character long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [MaxLength(45, ErrorMessage = "Surname is too long")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(100, ErrorMessage = "City is too long")]
        public string City { get; set; }

        [MaxLength(100, ErrorMessage = "Street is too long")]
        public string Street { get; set; }

        [MaxLength(4, ErrorMessage = "HouseNumber is too long")]
        public string HouseNumber { get; set; }

        [MaxLength(4, ErrorMessage = "ApartmentNumber is too long")]
        public string ApartmentNumber { get; set; }

        [MaxLength(5, ErrorMessage = "PostalCode is too long")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [MaxLength(11, ErrorMessage = "PhoneNumber is too long")]
        [RegularExpression(@"^[01-9\+]*$", ErrorMessage = "Phone number not valid")]
        public string PhoneNumber { get; set; }

        [MaxLength(100, ErrorMessage = "WebAddress is too long")]
        public string WebAddress { get; set; }
    }
}
