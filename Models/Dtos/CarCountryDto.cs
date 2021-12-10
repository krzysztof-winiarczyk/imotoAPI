using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class CarCountryDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Acronym is required")]
        [MaxLength(10, ErrorMessage = "Acronym is too long")]
        public string Acronym { get; set; }
    }
}
