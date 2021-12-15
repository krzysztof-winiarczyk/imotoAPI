using imotoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class AnnoucementReturnDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public CarClass CarClass { get; set; }

        public CarBrand CarBrand { get; set; }
        public string CarBrandSpare { get; set; }

        public CarModelReturnDto CarModel { get; set; }
        public string CarModelSpare { get; set; }

        public CarColor CarColor { get; set; }
        public string CarColorSpare { get; set; }

        public CarBodywork CarBodywork { get; set; }

        public CarCountry CarCountry { get; set; }

        public CarYear CarYear { get; set; }

        public CarFuel CarFuel { get; set; }

        public CarDrive CarDrive { get; set; }

        public CarTransmission CarTransmission { get; set; }
        public string CarTransmissionSpare { get; set; }

        public Voivodeship Voivodeship {get; set;}

        public int? Capacity { get; set; }
        public int Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }

        public IEnumerable<CarEquipment> CarEquipment { get; set; }

        public IEnumerable<CarStatus> CarStatuses { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}
