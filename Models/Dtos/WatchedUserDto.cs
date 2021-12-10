using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class WatchedUserDto
    {
        [Required(ErrorMessage = "FollowerId is required")]
        public int FollowerId { get; set; }

        [Required(ErrorMessage = "WatchedId is required")]
        public int WatchedId { get; set; }
    }
}
