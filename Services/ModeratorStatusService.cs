using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IModeratorStatusService
    {
        public IEnumerable<ModeratorStatus> GetAll();
        public ModeratorStatus GetById(int id);
        public ModeratorStatus Add(StatusDto dto);
        public ModeratorStatus Update(int id, StatusDto dto);
    }

    public class ModeratorStatusService : IModeratorStatusService
    {
        private readonly ImotoDbContext _dbContext;

        public ModeratorStatusService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ModeratorStatus> GetAll()
        {
            var statuses = _dbContext
                .ModeratorStatuses
                .ToList();

            return statuses;
        }

        public ModeratorStatus GetById(int id)
        {
            var status = _dbContext
                .ModeratorStatuses
                .FirstOrDefault(s => s.Id == id);

            if (status is null)
                throw new NotFoundException("Not found");

            return status;
        }

        public ModeratorStatus Add(StatusDto dto)
        {
            var status = new ModeratorStatus()
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _dbContext.Add(status);
            _dbContext.SaveChanges();

            return status;
        }

        public ModeratorStatus Update(int id, StatusDto dto)
        {
            var status = _dbContext
                .ModeratorStatuses
                .FirstOrDefault(s => s.Id == id);

            if (status is null)
                throw new NotFoundException("Not found");

            status.Name = dto.Name;
            status.Description = dto.Description;
            _dbContext.SaveChanges();

            return status;
        }
    }
}
