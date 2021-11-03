using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IUserStatusService
    {
        public IEnumerable<UserStatus> GetAll();
        public UserStatus GetById(int id);
        public UserStatus Add(StatusDto dto);
        public UserStatus Update(int id, StatusDto dto);
    }

    public class UserStatusService : IUserStatusService
    {

        private readonly ImotoDbContext _dbContext;

        public UserStatusService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserStatus> GetAll()
        {
            var statuses = _dbContext
                .UserStatuses
                .ToList();

            return statuses;
        }

        public UserStatus GetById(int id)
        {
            var status = _dbContext
                .UserStatuses
                .FirstOrDefault(s => s.Id == id);

            if (status is null)
                throw new NotFoundException("Not found");

            return status;
        }

        public UserStatus Add(StatusDto dto)
        {
            var status = new UserStatus()
            {
                Name = dto.Name,
                Description = dto.Description,
                Editable = true
            };

            _dbContext.Add(status);
            _dbContext.SaveChanges();

            return status;
        }

        public UserStatus Update(int id, StatusDto dto)
        {
            var status = _dbContext
                .UserStatuses
                .FirstOrDefault(s => s.Id == id);

            if (status is null)
                throw new NotFoundException("Not found");

            if (status.Editable == false)
                throw new NotAllowedException("Action not allowed");

            status.Name = dto.Name;
            status.Description = dto.Description;
            _dbContext.SaveChanges();

            return status;
        }
    }
}
