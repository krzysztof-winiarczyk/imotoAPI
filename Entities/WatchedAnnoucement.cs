using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class WatchedAnnoucement
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int AnnoucementId { get; set; }
        public Annoucement Annoucement { get; set; }

        public DateTime Date { get; set; }
    }
}
