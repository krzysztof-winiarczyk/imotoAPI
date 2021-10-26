using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class WatchedUserDto
    {
        public int FollowerId { get; set; }
        public int WatchedId { get; set; }
    }
}
