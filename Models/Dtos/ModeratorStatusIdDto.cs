using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class ModeratorStatusIdDto
    {
        [Required(ErrorMessage = "StatusId is required")]
        public int StatusId { get; set; }
    }
}
