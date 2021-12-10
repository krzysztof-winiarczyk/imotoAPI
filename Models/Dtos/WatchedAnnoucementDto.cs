using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class WatchedAnnoucementDto
    {
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "AnnoucementId is required")]
        public int AnnoucementId { get; set; }
    }
}
