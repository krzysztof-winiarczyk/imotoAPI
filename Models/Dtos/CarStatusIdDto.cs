using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class CarStatusIdDto
    {
        [Required(ErrorMessage = "CarStatusId is required")]
        public int CarStatusId { get; set; }
    }
}
