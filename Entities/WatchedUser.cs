using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class WatchedUser
    {
        public int Id { get; set; }

        public int FollowerId { get; set; }
        public User Follower { get; set; }

        public int WatchedId { get; set; }
        public User Watched { get; set; }

        public DateTime DateOfStart { get; set; }
    }
}
