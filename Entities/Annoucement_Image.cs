using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class Annoucement_Image
    {
        public int Id { get; set; }

        public int AnnoucementId { get; set; }
        public virtual Annoucement Annoucement { get; set; }


        public int ImageId { get; set; }
        public virtual Image Image {get; set;}

    }
}
