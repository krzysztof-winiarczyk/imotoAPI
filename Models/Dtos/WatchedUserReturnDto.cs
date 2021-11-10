using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class WatchedUserReturnDto
    {
        public int Id { get; set; }

        public int FollowerId { get; set; }

        public int WatchedId { get; set; }

        public DateTime DateOfStart { get; set; }
    }
}
