using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace imotoAPI.Services
{

    public interface IAnnoucementService
    {

        /// <summary>
        /// Returns only active annoucements
        /// </summary>
        /// <returns>collection of active annoucements</returns>
        public PageResult<AnnoucementReturnDto> Get(
            int? carClassId,
            int? carBrandId,
            int? carModelId,
            int? carColorId,
            int? carBodyworkId,
            int? carCountryId,
            int? yearStart,
            int? yearEnd,
            int? carFuelId,
            int? carDriveId,
            int? carTransmissionId,
            int? voivodeshipId,
            int? priceStart,
            int? priceEnd,
            int? mileageStart,
            int? mileageEnd,
            PaginationQuerry paginationQuerry,
            SortQuerry sortQuerry);

        /// <summary>
        /// Returns annoucements with delivered status
        /// </summary>
        /// <param name="annoucementStatusId"></param>
        /// <returns></returns>
        public IEnumerable<AnnoucementReturnDto> GetAnnoucementsWithStatus(int annoucementStatusId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of annoucement</param>
        /// <returns>active annoucement of id</returns>
        public AnnoucementReturnDto GetById(int id);

        /// <summary>
        /// Returns random annoucements which are meeting the criteria in querry
        /// </summary>
        /// <param name="querry"></param>
        /// <returns></returns>
        public PageResult<AnnoucementReturnDto> GetRandom(CriteriaQuerry querry);

        /// <summary>
        /// create annoucement from dto and add to DataBase
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>created annoucement</returns>
        public Annoucement AddAnnoucement(AnnoucementGetDto dto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>eddited annoucement</returns>
        public Annoucement EditAnnoucement(int id, AnnoucementGetDto dto);

        /// <summary>
        /// change status of annouceemnt and delete all watchedAnnoucements connected with it
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAnnoucement(int id);

        /// <summary>
        /// add carStatus to annoucement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Annoucement_CarStatus AddCarStatusToAnnoucement(int id, CarStatusIdDto dto);

        /// <summary>
        /// delete carStatus from annoucement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        public void DeleteCarStatusFromAnnoucement(int id, CarStatusIdDto dto);

        /// <summary>
        /// add carEquipment to annoucement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Annoucement_CarEquipment AddCarEquipmentToAnnoucement(int id, CarEquipmentIdDto dto);

        /// <summary>
        /// delete carEquipment from annoucement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        public void DeleteCarEquipmentFromAnnoucement(int id, CarEquipmentIdDto dto);
    }

    public class AnnoucementService : IAnnoucementService
    {
        private readonly ImotoDbContext _dbContext;
        private readonly IUserContextService _userContextService;
        private readonly IAnnoucementServiceHelper _helper;

        public AnnoucementService(
            ImotoDbContext dbContext,
            IUserContextService userContextService,
            IAnnoucementServiceHelper helper)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
            _helper = helper;
        }

        
        public PageResult<AnnoucementReturnDto> Get(
            int? carClassId,
            int? carBrandId,
            int? carModelId,
            int? carColorId,
            int? carBodyworkId,
            int? carCountryId,
            int? yearStart,
            int? yearEnd,
            int? carFuelId,
            int? carDriveId,
            int? carTransmissionId,
            int? voivodeshipId,
            int? priceStart,
            int? priceEnd,
            int? mileageStart,
            int? mileageEnd,
            PaginationQuerry paginationQuerry,
            SortQuerry sortQuerry)
        {

            var status = _helper.GetAnnouncementActiveStatus();

            int? yearStartId = GetIdOfYear(yearStart);
            int? yearEndId = GetIdOfYear(yearEnd);

            var baseQuerry = _dbContext
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
                .Include(a => a.Voivodeship)
                .Where(a => a.AnnoucementStatusId == status.Id
                    && (
                        (carClassId == null || a.CarClassId == carClassId)
                        && (carBrandId == null || a.CarBrandId == carBrandId)
                        && (carModelId == null || a.CarModelId == carModelId)
                        && (carColorId == null || a.CarColorId == carColorId)
                        && (carBodyworkId == null || a.CarBodyworkId == carBodyworkId)
                        && (carCountryId == null || a.CarCountryId == carCountryId)
                        //year
                        && ((yearStartId == null && yearEndId == null)
                            || (yearEndId == null && a.CarYearId >= yearStartId)
                            || (yearStartId == null && a.CarYearId <= yearEndId)
                            || (a.CarYearId >= yearStartId && a.CarYearId <= yearEndId)
                            )
                        && (carFuelId == null || a.CarFuelId == carFuelId)
                        && (carDriveId == null || a.CarDriveId == carDriveId)
                        && (carTransmissionId == null || a.CarTransmissionId == carTransmissionId)
                        //price
                        && ((priceStart == null && priceEnd == null)
                            || (priceEnd == null && a.Price >= priceStart)
                            || (priceStart == null && a.Price <= priceEnd)
                            || (a.Price >= priceStart && a.Price <= priceEnd)
                            )
                        //mileage
                        && ((mileageStart == null && mileageEnd == null)
                            || (mileageStart == null && a.Mileage <= mileageEnd)
                            || (mileageEnd == null && a.Mileage >= mileageStart)
                            || (a.Mileage >= mileageStart && a.Mileage <= mileageEnd)
                            )
                        && (voivodeshipId == null || a.VoivodeshipId == voivodeshipId)
                    )
                );

            var totalItemsCount = baseQuerry.Count();

            //sorting
            sortQuerry.Validate();
            var columnsSelector = new Dictionary<string, Expression<Func<Annoucement, object>>>()
            {
                {nameof(Annoucement.CarYear), a => a.CarYear },
                {nameof(Annoucement.Price), a => a.Price },
                {nameof(Annoucement.Mileage), a => a.Mileage }
            };
            var selectedColumn = columnsSelector[sortQuerry.SortBy];
            if (sortQuerry.SortDirection == "asc")
            {
                baseQuerry = baseQuerry.OrderBy(selectedColumn);
            }
            else
            {
                baseQuerry = baseQuerry.OrderByDescending(selectedColumn);
            }

            //pagination
            paginationQuerry.Validate();
            var annoucements = baseQuerry
                .Skip(paginationQuerry.PageSize * (paginationQuerry.PageNumber - 1))
                .Take(paginationQuerry.PageSize)
                .ToList();


            var annoucementsDto = new List<AnnoucementReturnDto>();

            foreach (Annoucement a in annoucements)
            {
                var dto = new AnnoucementReturnDto();
                dto.Id = a.Id;
                dto.UserId = a.UserId;
                dto.CarClass = a.CarClass;
                dto.CarBrand = a.CarBrand;
                dto.CarBrandSpare = a.CarBrandSpare;
                dto.CarColor = a.CarColor;
                dto.CarColorSpare = a.CarColorSpare;
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
                dto.Capacity = a.Capacity;
                dto.Price = a.Price;
                dto.Mileage = a.Mileage;
                dto.Description = a.Description;
                dto.Voivodeship = a.Voivodeship;

                dto.CarEquipment = GetCarEquipmentOfAnnoucement(a.Id);
                dto.CarStatuses = GetCarStatusesOfAnnoucement(a.Id);
                dto.Images = GetImagesOfAnnoucement(a.Id);

                annoucementsDto.Add(dto);
            }


            PageResult<AnnoucementReturnDto> result = new (annoucementsDto, totalItemsCount, paginationQuerry.PageSize, paginationQuerry.PageNumber);

            return result;
        }

        public IEnumerable<AnnoucementReturnDto> GetAnnoucementsWithStatus(int annoucementStatusId)
        {
            var annoucementStatus = _dbContext.AnnoucementStatuses.FirstOrDefault(s => s.Id == annoucementStatusId);
            if (annoucementStatus is null)
                throw new NotFoundException("Not found");

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
                .Include(a => a.Voivodeship)
                .Where(a => a.AnnoucementStatusId == annoucementStatusId)
                .ToList();

            var annoucementsDto = new List<AnnoucementReturnDto>();

            foreach (Annoucement a in annoucements)
            {
                var dto = new AnnoucementReturnDto();
                dto.Id = a.Id;
                dto.UserId = a.UserId;
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
                dto.Capacity = a.Capacity;
                dto.Price = a.Price;
                dto.Mileage = a.Mileage;
                dto.Description = a.Description;
                dto.Voivodeship = a.Voivodeship;

                dto.CarEquipment = GetCarEquipmentOfAnnoucement(a.Id);
                dto.CarStatuses = GetCarStatusesOfAnnoucement(a.Id);
                dto.Images = GetImagesOfAnnoucement(a.Id);

                annoucementsDto.Add(dto);
            }

            return annoucementsDto;
        }

        
        public AnnoucementReturnDto GetById(int id)
        {
            var status = _helper.GetAnnouncementActiveStatus();

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
                .Include(a => a.Voivodeship)
                .Where(a => a.AnnoucementStatusId == status.Id)
                .FirstOrDefault(a => a.Id == id);

            if (annocuement is null)
                throw new NotFoundException("Not found");

            var dto = _helper.MapToReturnDto(annocuement);
            return dto;
        }
        
        public PageResult<AnnoucementReturnDto> GetRandom(CriteriaQuerry querry)
        {
            var dtoCollection = new List<AnnoucementReturnDto>();
            var annoucements = new List<Annoucement>();
            var status = _helper.GetAnnouncementActiveStatus();
            int howMany = 12;
            var baseQuerry = _dbContext
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
                        .Include(a => a.Voivodeship);

            switch (querry.Criterion)
            {
                case "country":
                    annoucements = baseQuerry
                        .Where(a => a.AnnoucementStatusId == status.Id
                        && a.CarCountry.Name.ToLower() == querry.Condition)
                        .ToList();
                    break;
                case "fuel":
                    annoucements = baseQuerry
                        .Where(a => a.AnnoucementStatusId == status.Id
                        && a.CarFuel.Name.ToLower() == querry.Condition)
                        .ToList();
                    break;
                case "maxPrice":
                    annoucements = baseQuerry
                        .Where(a => a.AnnoucementStatusId == status.Id
                        && a.Price <= Int32.Parse(querry.Condition))
                        .ToList();
                    break;
            }

            if (annoucements.Count <= howMany)
            {
                //without draw

                //mapping
                foreach(Annoucement a in annoucements)
                {
                    var dto = _helper.MapToReturnDto(a);
                    dtoCollection.Add(dto);
                }
            }
            else
            {
                //with draw
                var lotteryMachine = new LotteryMachine();
                var drawnIndexes = lotteryMachine.Draw(howMany, annoucements.Count);

                //getting annoucements whitch are drown
                var drawnAnnoucements = new List<Annoucement>();
                for (int i=0; i<drawnIndexes.Count; i++)
                {
                    int index = drawnIndexes[i];
                    drawnAnnoucements.Add(annoucements[index]);
                }
                
                //mapping
                foreach(Annoucement a in drawnAnnoucements)
                {
                    var dto = _helper.MapToReturnDto(a);
                    dtoCollection.Add(dto);
                }
            }

            PageResult<AnnoucementReturnDto> result = new(dtoCollection, dtoCollection.Count, howMany, 1);
            return result;
        }

        public Annoucement AddAnnoucement(AnnoucementGetDto dto)
        {
            var status = _helper.GetAnnouncementActiveStatus();

            var annoucement = new Annoucement();
            annoucement.UserId = _userContextService.GetUserId;
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
            annoucement.Capacity = dto.Capacity;
            annoucement.Price = dto.Price;
            annoucement.Mileage = dto.Mileage;
            annoucement.Description = dto.Description;
            annoucement.AnnoucementStatusId = status.Id;
            annoucement.VoivodeshipId = dto.VoivodeshipId;

            _dbContext.Add(annoucement);
            _dbContext.SaveChanges();

            int annoucementId = annoucement.Id;

            var annoucementToReturn = _dbContext
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
                .Include(a => a.Voivodeship)
                .FirstOrDefault(a => a.Id == annoucementId);

            return annoucementToReturn;
        }

        public Annoucement EditAnnoucement(int id, AnnoucementGetDto dto)
        {
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);

            if (annoucement is null)
                throw new NotFoundException("Not found");

            //check if annoucement belongs to user
            if (annoucement.UserId != _userContextService.GetUserId)
                throw new ForbidException("");

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
            annoucement.Capacity = dto.Capacity;
            annoucement.Price = dto.Price;
            annoucement.Mileage = dto.Mileage;
            annoucement.Description = dto.Description;
            annoucement.VoivodeshipId = dto.VoivodeshipId;

            _dbContext.SaveChanges();

            int annoucementId = annoucement.Id;

            var annoucementToReturn = _dbContext
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
                .Include(a => a.Voivodeship)
                .FirstOrDefault(a => a.Id == annoucementId);

            return annoucementToReturn;
        }

        public void DeleteAnnoucement (int id)
        {
            //get annoucement from DB
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);
            if (annoucement is null)
                throw new NotFoundException("Not found");

            //check if annoucement belongs to user invoking action or if user is admin
            string userRole = _userContextService.GetUserRole;
            int userId = _userContextService.GetUserId;
            if (userRole == "użytkownik" && userId != annoucement.UserId)
                throw new ForbidException("Action denied");

            //set status for annoucement
            var statusDeleted = _helper.GetAnnoucementDeletedStatus();
            annoucement.AnnoucementStatusId = statusDeleted.Id;
            annoucement.AnnoucementStatus = statusDeleted;

            //get all watchedAnnoucements entites which annoucementId is id 
            var watchedAnnoucements = _dbContext
                    .WatchedAnnoucements
                    .Where(wa => wa.AnnoucementId == annoucement.Id)
                    .ToList();
            //remove watchedAnnoucements from DB
            _dbContext.WatchedAnnoucements.RemoveRange(watchedAnnoucements);

            //save changes on DB
            _dbContext.SaveChanges();
        }

        public Annoucement_CarStatus AddCarStatusToAnnoucement (int id, CarStatusIdDto dto)
        {
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);

            if (annoucement is null)
                throw new NotFoundException("Not found");

            //check if annoucement belongs to user invoking action or if user is admin
            string userRole = _userContextService.GetUserRole;
            int userId = _userContextService.GetUserId;
            if (userRole == "użytkownik" && userId != annoucement.UserId)
                throw new ForbidException("");

            var carStatus = _dbContext
                .CarStatuses
                .FirstOrDefault(cs => cs.Id == dto.CarStatusId);

            if (carStatus is null)
                throw new NotFoundException("Not found");

            var annoucementCarStatusObject = new Annoucement_CarStatus();
            annoucementCarStatusObject.AnnoucementId = annoucement.Id;
            annoucementCarStatusObject.CarStatusId = carStatus.Id;
            _dbContext.Add(annoucementCarStatusObject);
            _dbContext.SaveChanges();

            return annoucementCarStatusObject;
        }

        public void DeleteCarStatusFromAnnoucement(int id, CarStatusIdDto dto)
        {
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);

            if (annoucement is null)
                throw new NotFoundException("Not found");

            //check if annoucement belongs to user invoking action or if user is admin
            string userRole = _userContextService.GetUserRole;
            int userId = _userContextService.GetUserId;
            if (userRole == "użytkownik" && userId != annoucement.UserId)
                throw new ForbidException("");

            var annoucementCarStatus = _dbContext
                .Annoucement_CarStatuses
                .FirstOrDefault(acs => acs.AnnoucementId == id && acs.CarStatusId == dto.CarStatusId);

            if (annoucementCarStatus is null)
                throw new NotFoundException("Not found");

            _dbContext.Annoucement_CarStatuses.Remove(annoucementCarStatus);
            _dbContext.SaveChanges();
        }


        public Annoucement_CarEquipment AddCarEquipmentToAnnoucement(int id, CarEquipmentIdDto dto)
        {
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);

            if (annoucement is null)
                throw new NotFoundException("Not found");

            //check if annoucement belongs to user invoking action or if user is admin
            string userRole = _userContextService.GetUserRole;
            int userId = _userContextService.GetUserId;
            if (userRole == "użytkownik" && userId != annoucement.UserId)
                throw new ForbidException("");


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

        public void DeleteCarEquipmentFromAnnoucement(int id, CarEquipmentIdDto dto)
        {
            var annoucement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == id);

            if (annoucement is null)
                throw new NotFoundException("Not found");

            //check if annoucement belongs to user invoking action or if user is admin
            string userRole = _userContextService.GetUserRole;
            int userId = _userContextService.GetUserId;
            if (userRole == "użytkownik" && userId != annoucement.UserId)
                throw new ForbidException("");

            var announcementCarEquipment = _dbContext
                .Annoucement_CarEquipments
                .FirstOrDefault(ace => ace.AnnoucementId == id && ace.CarEquipmentId == dto.CarEquipmentId);

            if (announcementCarEquipment is null)
                throw new NotFoundException("Not found");

            _dbContext.Annoucement_CarEquipments.Remove(announcementCarEquipment);
            _dbContext.SaveChanges();
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

        private int? GetIdOfYear(int? year)
        {
            if (year == null)
                return null;

            var carYear = _dbContext
                .CarYears
                .FirstOrDefault(y => y.YearOfProduction == year);

            if (carYear == null)
                return null;
            else
                return carYear.Id;
        }
    }
}
