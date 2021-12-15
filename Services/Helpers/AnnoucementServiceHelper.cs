using imotoAPI.Entities;
using imotoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IAnnoucementServiceHelper
    {
        public AnnoucementStatus GetAnnouncementActiveStatus();
        public AnnoucementStatus GetAnnoucementDeletedStatus();
        public AnnoucementReturnDto MapToReturnDto(Annoucement annocuement);
    }

    public class AnnoucementServiceHelper : IAnnoucementServiceHelper
    {
        private readonly ImotoDbContext _dbContext;

        public AnnoucementServiceHelper(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AnnoucementStatus GetAnnouncementActiveStatus()
        {
            var status = _dbContext
                .AnnoucementStatuses
                .FirstOrDefault(s => s.Name == "aktualne");

            return status;
        }

        public AnnoucementStatus GetAnnoucementDeletedStatus()
        {
            var status = _dbContext
                .AnnoucementStatuses
                .FirstOrDefault(s => s.Name == "usunięte");

            return status;
        }

        public AnnoucementReturnDto MapToReturnDto(Annoucement annocuement)
        {
            var dto = new AnnoucementReturnDto();
            dto.Id = annocuement.Id;
            dto.UserId = annocuement.UserId;
            dto.CarClass = annocuement.CarClass;
            dto.CarBrand = annocuement.CarBrand;
            dto.CarBrandSpare = annocuement.CarBrandSpare;
            if (annocuement.CarModel is not null)
            {
                dto.CarModel = new CarModelReturnDto();
                dto.CarModel.Id = annocuement.CarModel.Id;
                dto.CarModel.Name = annocuement.CarModel.Name;
            }
            dto.CarModelSpare = annocuement.CarModelSpare;
            dto.CarBodywork = annocuement.CarBodywork;
            dto.CarCountry = annocuement.CarCountry;
            dto.CarYear = annocuement.CarYear;
            dto.CarFuel = annocuement.CarFuel;
            dto.CarDrive = annocuement.CarDrive;
            dto.CarTransmission = annocuement.CarTransmission;
            dto.CarTransmissionSpare = annocuement.CarTransmissionSpare;
            dto.Capacity = annocuement.Capacity;
            dto.Price = annocuement.Price;
            dto.Mileage = annocuement.Mileage;
            dto.Description = annocuement.Description;
            dto.Voivodeship = annocuement.Voivodeship;

            dto.CarEquipment = GetCarEquipmentOfAnnoucement(annocuement.Id);
            dto.CarStatuses = GetCarStatusesOfAnnoucement(annocuement.Id);
            dto.Images = GetImagesOfAnnoucement(annocuement.Id);

            return dto;
        }

        private List<CarStatus> GetCarStatusesOfAnnoucement(int annoucementId)
        {
            var annoucementStatuses = _dbContext
                .Annoucement_CarStatuses
                .Where(cs => cs.AnnoucementId == annoucementId)
                .ToList();

            List<CarStatus> carStatuses = new();
            foreach (Annoucement_CarStatus aCS in annoucementStatuses)
            {
                var status = _dbContext
                    .CarStatuses
                    .FirstOrDefault(cs => cs.Id == aCS.CarStatusId);
                carStatuses.Add(status);
            }

            return carStatuses;
        }

        private List<CarEquipment> GetCarEquipmentOfAnnoucement(int annoucementId)
        {
            var annoucementEquipment = _dbContext
                .Annoucement_CarEquipments
                .Where(ce => ce.AnnoucementId == annoucementId)
                .ToList();

            List<CarEquipment> carEquipment = new();
            foreach (Annoucement_CarEquipment aCE in annoucementEquipment)
            {
                var equipment = _dbContext
                    .CarEquipment
                    .FirstOrDefault(ce => ce.Id == aCE.CarEquipmentId);
                carEquipment.Add(equipment);
            }

            return carEquipment;
        }

        private List<Image> GetImagesOfAnnoucement(int annoucementId)
        {
            var annoucementImages = _dbContext
                .Annoucement_Images
                .Where(ai => ai.AnnoucementId == annoucementId)
                .Include(ai => ai.Image)
                .ToList();

            List<Image> images = new();
            foreach (Annoucement_Image ai in annoucementImages)
            {
                images.Add(ai.Image);
            }

            return images;
        }
    }
}
