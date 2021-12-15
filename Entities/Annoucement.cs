using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class Annoucement
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int? CarClassId { get; set; }
        public CarClass CarClass { get; set; }

        public int? CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public string CarBrandSpare { get; set; }

        public int? CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public string CarModelSpare { get; set; }

        public int? CarColorId { get; set; }
        public CarColor CarColor { get; set; }
        public string CarColorSpare { get; set; }

        public int? CarBodyworkId { get; set; }
        public CarBodywork CarBodywork { get; set; }

        public int? CarCountryId { get; set; }
        public CarCountry CarCountry { get; set; }

        public int? CarYearId { get; set; }
        public CarYear CarYear { get; set; }

        public int? CarFuelId { get; set; }
        public CarFuel CarFuel { get; set; }

        public int? CarDriveId { get; set; }
        public CarDrive CarDrive { get; set; }

        public int? CarTransmissionId { get; set; }
        public CarTransmission CarTransmission { get; set; }
        public string CarTransmissionSpare { get; set; }

        public int? VoivodeshipId { get; set; }
        public virtual Voivodeship Voivodeship { get; set; }

        public int? AnnoucementStatusId { get; set; }
        public virtual AnnoucementStatus AnnoucementStatus { get; set; }

        public int? Capacity { get; set; }
        public int Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }

    }
}
