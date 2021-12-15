using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class AnnoucementGetDto
    {
        //public int UserId { get; set; }

        public int? CarClassId { get; set; }


        public int? CarBrandId { get; set; }

        [MaxLength(45, ErrorMessage = "CarBrandSpare is too long")]
        public string CarBrandSpare { get; set; }


        public int? CarModelId { get; set; }

        [MaxLength(45, ErrorMessage = "CarModelSpare is too long")]
        public string CarModelSpare { get; set; }


        public int? CarColorId { get; set; }


        [MaxLength(45, ErrorMessage = "CarColorSpare is too long")]
        public string CarColorSpare { get; set; }


        public int? CarBodyworkId { get; set; }


        public int? CarCountryId { get; set; }


        public int? CarYearId { get; set; }


        public int? CarFuelId { get; set; }


        public int? CarDriveId { get; set; }


        public int? CarTransmissionId { get; set; }


        [MaxLength(45, ErrorMessage = "CarTransmissionSpare is too long")]
        public string CarTransmissionSpare { get; set; }
        
        
        public int? VoivodeshipId { get; set; }

        [Range(1, 12000, ErrorMessage = "Capacity must be in range 1-12000")]
        public int? Capacity { get; set; }

        [Required(ErrorMessage = "Price must not be empty")]
        public int Price { get; set; }


        [Required(ErrorMessage = "Mileage must not be empty")]
        public int Mileage { get; set; }


        [MaxLength(511, ErrorMessage = "Description is too long")]
        public string Description { get; set; }
    }
}
