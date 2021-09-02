using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class Annoucement_CarEquipment
    {
        public int Id { get; set; }
        
        public int AnnoucementId { get; set; }
        public Annoucement Annoucement { get; set; }

        public int CarEquipmentId { get; set; }
        public CarEquipment CarEquipment { get; set; }

    }
}
