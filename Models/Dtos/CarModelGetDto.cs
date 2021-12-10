using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class CarModelGetDto
    {
        [Required(ErrorMessage = "CarBrandId is required")]
        public int CarBrandId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(45, ErrorMessage = "Name is too long")]
        public string Name { get; set; }
    }
}
