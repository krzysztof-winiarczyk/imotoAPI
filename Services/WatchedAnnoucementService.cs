using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IWatchedAnnoucementService
    {
        public WatchedAnnoucementReturnDto Add(WatchedAnnoucementDto dto);
        public void Delete(WatchedAnnoucementDto dto);
    }

    public class WatchedAnnoucementService : IWatchedAnnoucementService
    {
        private readonly ImotoDbContext _dbContext;
        private readonly IUserContextService _userContextService;

        public WatchedAnnoucementService(ImotoDbContext dbContext, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
        }

        public WatchedAnnoucementReturnDto Add(WatchedAnnoucementDto dto)
        {
            var watchedAnnoucement = _dbContext
                .WatchedAnnoucements
                .FirstOrDefault(wa => wa.UserId == dto.UserId && wa.AnnoucementId == dto.AnnoucementId);

            if (watchedAnnoucement is not null)
                throw new ResourceExsistsException("Already exists");

            watchedAnnoucement = new WatchedAnnoucement()
            {
                UserId = dto.UserId,
                AnnoucementId = dto.AnnoucementId
            };
            watchedAnnoucement.Date = DateTime.Now;

            _dbContext.Add(watchedAnnoucement);
            _dbContext.SaveChanges();

            var watchedAnnoucementDto = MapToReturnDto(watchedAnnoucement);
            return watchedAnnoucementDto;
        }

        public void Delete(WatchedAnnoucementDto dto)
        {
            var watchedAnnoucement = _dbContext
                .WatchedAnnoucements
                .FirstOrDefault(wa => wa.AnnoucementId == dto.AnnoucementId && wa.UserId == dto.UserId);

            if (watchedAnnoucement is null)
                throw new NotFoundException("Not found");

            if (_userContextService.GetUserRole == "użytkownik" && _userContextService.GetUserId != watchedAnnoucement.UserId)
                throw new ForbidException("");

            _dbContext.WatchedAnnoucements.Remove(watchedAnnoucement);
            _dbContext.SaveChanges();
        }

        private static WatchedAnnoucementReturnDto MapToReturnDto(WatchedAnnoucement watchedAnnoucement)
        {
            var watchedAnnoucementDto = new WatchedAnnoucementReturnDto()
            {
                Id = watchedAnnoucement.Id,
                UserId = watchedAnnoucement.UserId,
                AnnoucementId = watchedAnnoucement.AnnoucementId,
                Date = watchedAnnoucement.Date
            };
            return watchedAnnoucementDto;
        } 
    }
}
