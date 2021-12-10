using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class CarColorDto
    {
        [Required(ErrorMessage = "CarColor is required")]
        [MaxLength(45, ErrorMessage = "CarColor is too long")]
        public string Name { get; set; }
    }
}
