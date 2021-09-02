using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class Annoucement_CarStatus
    {
        public int Id { get; set; }

        public int AnnoucementId { get; set; }
        public Annoucement Annoucement { get; set; }

        public int CarStatusId { get; set; }
        public CarStatus CarStatus { get; set; }
    }
}
