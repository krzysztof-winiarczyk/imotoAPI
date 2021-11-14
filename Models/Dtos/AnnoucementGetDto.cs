using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class AnnoucementGetDto
    {
        //public int UserId { get; set; }

        public int? CarClassId { get; set; }

        public int? CarBrandId { get; set; }
        public string CarBrandSpare { get; set; }

        public int? CarModelId { get; set; }
        public string CarModelSpare { get; set; }

        public int? CarColorId { get; set; }
        public string CarColorSpare { get; set; }

        public int? CarBodyworkId { get; set; }

        public int? CarCountryId { get; set; }

        public int? CarYearId { get; set; }

        public int? CarFuelId { get; set; }

        public int? CarDriveId { get; set; }

        public int? CarTransmissionId { get; set; }
        public string CarTransmissionSpare { get; set; }

        public int Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
    }
}
