using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IUserTypeService
    {
        public IEnumerable<UserType> GetAll();
        public UserType GetById(int id);
        public UserType Add(UserTypeDto dto);
        public UserType Edit(int id, UserTypeDto dto);
    }

    public class UserTypeService : IUserTypeService
    {

        private readonly ImotoDbContext _dbContext;

        public UserTypeService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserType> GetAll()
        {
            var collection = _dbContext
                .UserTypes
                .ToList();

            return collection;
        }

        public UserType GetById(int id)
        {
            var userType = _dbContext
                .UserTypes
                .FirstOrDefault(ut => ut.Id == id);

            if (userType is null)
                throw new NotFoundException("Not found");

            return userType;
        }

        public UserType Add(UserTypeDto dto)
        {
            var userType = new UserType()
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _dbContext.Add(userType);
            _dbContext.SaveChanges();

            return userType;
        }

        public UserType Edit(int id, UserTypeDto dto)
        {
            var userType = _dbContext
                .UserTypes
                .FirstOrDefault(ut => ut.Id == id);

            if (userType is null)
                throw new NotFoundException("Not found");

            userType.Name = dto.Name;
            userType.Description = dto.Description;
            _dbContext.SaveChanges();

            return userType;
        }
    }
}
