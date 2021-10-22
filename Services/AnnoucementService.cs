using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace imotoAPI.Services
{

    public interface IAnnoucementService
    {
        public IEnumerable<AnnoucementReturnDto> Get();
        public AnnoucementReturnDto GetById(int id);
        public Annoucement AddAnnoucement(AnnoucementGetDto dto);
        public Annoucement EditAnnoucement(int id, AnnoucementGetDto dto);
        public Annoucement_CarStatus AddStatusToAnnoucement(int id, CarStatusIdDto dto);
        public Annoucement_CarEquipment AddEquipmentToAnnoucement(int id, CarEquipmentIdDto dto);

    }

    public class AnnoucementService : IAnnoucementService
    {
        private readonly ImotoDbContext _dbContext;

        public AnnoucementService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AnnoucementReturnDto> Get()
        {
            //TODO: add filtering and pagination

            var annoucements = _dbContext
                .Annoucements
                .Include(a => a.CarClass)
                .Include(a => a.CarBrand)
                .Include(a => a.CarModel)
                .Include(a => a.CarColor)
                .Include(a => a.CarBodywork)
                .Include(a => a.CarCountry)
                .Include(a => a.CarYear)
                .Include(a => a.CarFuel)
                .Include(a => a.CarDrive)
                .Include(a => a.CarTransmission)
                .ToList();

            var annoucementsDto = new List<AnnoucementReturnDto>();

            foreach (Annoucement a in annoucements)
            {
                var dto = new AnnoucementReturnDto();
                dto.Id = a.Id;
                dto.UserId = a.Id;
                dto.CarClass = a.CarClass;
                dto.CarBrand = a.CarBrand;
                dto.CarBrandSpare = a.CarBrandSpare;
                if (a.CarModel is not null)
                { 
                    dto.CarModel = new CarModelReturnDto();
                    dto.CarModel.Id = a.CarModel.Id;
                    dto.CarModel.Name = a.CarModel.Name;
                }
                dto.CarModelSpare = a.CarModelSpare;
                dto.CarBodywork = a.CarBodywork;
                dto.CarCountry = a.CarCountry;
                dto.CarYear = a.CarYear;
                dto.CarFuel = a.CarFuel;
                dto.CarDrive = a.CarDrive;
                dto.CarTransmission = a.CarTransmission;
                dto.CarTransmissionSpare = a.CarTransmissionSpare;
                dto.Price = a.Price;
                dto.Mileage = a.Mileage;
                dto.Description = a.Description;

                //TODO: include car equipment
                //TODO: include car statuses

                annoucementsDto.Add(dto);
            }

            return annoucementsDto;
        }

        public AnnoucementReturnDto GetById(int id)
        {
            var annocuement = _dbContext
                .Annoucements
                .Include(a => a.CarClass)
                .Include(a => a.CarBrand)
                .Include(a => a.CarModel)
                .Include(a => a.CarColor)
                .Include(a => a.CarBodywork)
                .Include(a => a.CarCountry)
                .Include(a => a.CarYear)
                .Include(a => a.CarFuel)
                .Include(a => a.CarDrive)
                .Include(a => a.CarTransmission)
                .FirstOrDefault(a => a.Id == id);

            if (annocuement is null)
                throw new NotFoundException("Not found");

            var dto = new AnnoucementReturnDto();
            dto.Id = annocuement.Id;
            dto.UserId = annocuement.Id;
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
            dto.Price = annocuement.Price;
            dto.Mileage = annocuement.Mileage;
            dto.Description = annocuement.Description;

            dto.CarEquipment = this.GetEquipmentOfAnnoucement(annocuement.Id);
            dto.CarStatuses = GetStatusesOfAnnoucement(annocuement.Id);

            return dto;
        }
        
        public Annoucement AddAnnoucement(AnnoucementGetDto dto)
        {
            var annoucement = new Annoucement();
            annoucement.UserId = dto.UserId;
            annoucement.CarClassId = dto.CarClassId;
            annoucement.CarBrandId = dto.CarBrandId;
            annoucement.CarBrandSpare = dto.CarBrandSpare;
            annoucement.CarModelId = dto.CarModelId;
            annoucement.CarModelSpare = dto.CarModelSpare;
            annoucement.CarColorId = dto.CarColorId;
            annoucement.CarColorSpare = dto.CarColorSpare;
            annoucement.CarBodyworkId = dto.CarBodyworkId;
            annoucement.CarCountryId = dto.CarCountryId;
            annoucement.CarYearId = dto.CarYearId;
            annoucement.CarFuelId = dto.CarFuelId;
            annoucement.CarDriveId = dto.CarDriveId;
            annoucement.CarTransmissionId = dto.CarTransmissionId;
            annoucement.CarTransmissionSpare = dto.CarTransmissionSpare;
            annoucement.Price = dto.Price;
            annoucement.Mileage = dto.Mileage;
            annoucement.Description = dto.Description;

            _dbContext.Add(annoucement);
            _dbContext.SaveChanges();

            return annoucement;
        }

        public Annoucement EditAnnoucement(int id, AnnoucementGetDto dto)
        {
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);

            if (annoucement is null)
                throw new NotFoundException("Not found");

            annoucement.UserId = dto.UserId;
            annoucement.CarClassId = dto.CarClassId;
            annoucement.CarBrandId = dto.CarBrandId;
            annoucement.CarBrandSpare = dto.CarBrandSpare;
            annoucement.CarModelId = dto.CarModelId;
            annoucement.CarModelSpare = dto.CarModelSpare;
            annoucement.CarColorId = dto.CarColorId;
            annoucement.CarColorSpare = dto.CarColorSpare;
            annoucement.CarBodyworkId = dto.CarBodyworkId;
            annoucement.CarCountryId = dto.CarCountryId;
            annoucement.CarYearId = dto.CarYearId;
            annoucement.CarFuelId = dto.CarFuelId;
            annoucement.CarDriveId = dto.CarDriveId;
            annoucement.CarTransmissionId = dto.CarTransmissionId;
            annoucement.CarTransmissionSpare = dto.CarTransmissionSpare;
            annoucement.Price = dto.Price;
            annoucement.Mileage = dto.Mileage;
            annoucement.Description = dto.Description;

            _dbContext.Add(annoucement);
            _dbContext.SaveChanges();

            return annoucement;

        }

        public Annoucement_CarStatus AddStatusToAnnoucement (int id, CarStatusIdDto dto)
        {
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);

            if (annoucement is null)
                throw new NotFoundException("Not found");

            var status = _dbContext
                .CarStatuses
                .FirstOrDefault(cs => cs.Id == dto.CarStatusId);

            if (status is null)
                throw new NotFoundException("Not found");

            var annoucementCarStatusObject = new Annoucement_CarStatus();
            annoucementCarStatusObject.AnnoucementId = annoucement.Id;
            annoucementCarStatusObject.CarStatusId = status.Id;
            _dbContext.Add(annoucementCarStatusObject);
            _dbContext.SaveChanges();

            return annoucementCarStatusObject;
        }


        public Annoucement_CarEquipment AddEquipmentToAnnoucement(int id, CarEquipmentIdDto dto)
        {
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);

            if (annoucement is null)
                throw new NotFoundException("Not found");

            var equipment = _dbContext
                .CarEquipment
                .FirstOrDefault(ce => ce.Id == dto.CarEquipmentId);

            if (equipment is null)
                throw new NotFoundException("Not found");

            var annoucementCarEquipmentObject = new Annoucement_CarEquipment();
            annoucementCarEquipmentObject.AnnoucementId = annoucement.Id;
            annoucementCarEquipmentObject.CarEquipmentId = equipment.Id;
            _dbContext.Add(annoucementCarEquipmentObject);
            _dbContext.SaveChanges();

            return annoucementCarEquipmentObject;
        }


        private List<CarStatus> GetStatusesOfAnnoucement(int annoucementId)
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

        private List<CarEquipment> GetEquipmentOfAnnoucement(int annoucementId)
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
    }
}
