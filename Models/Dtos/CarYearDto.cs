using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class CarYearDto
    {
        [Required(ErrorMessage = "YearOfProduction is required")]
        public int YearOfProduction { get; set; }
    }
}
