using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class CarTransmissionDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(45, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Description is too long")]
        public string Description { get; set; }
    }
}
