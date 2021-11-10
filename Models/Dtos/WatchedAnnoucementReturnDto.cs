using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class WatchedAnnoucementReturnDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnnoucementId { get; set; }
        public DateTime Date { get; set; }
    }
}
