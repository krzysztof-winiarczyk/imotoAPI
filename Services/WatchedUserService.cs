using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{

    public interface IWatchedUserService
    {
        public IEnumerable<UserReturnDto> GetWatchedUsers(int followerId);
        public WatchedUserReturnDto Add(WatchedUserDto dto);
        public void Delete(WatchedUserDto dto);
    }

    public class WatchedUserService : IWatchedUserService
    {
        private readonly ImotoDbContext _dbContext;

        public WatchedUserService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserReturnDto> GetWatchedUsers(int followerId)
        {
            var watchedUsers = _dbContext
                .WatchedUsers
                .Include(wu => wu.Watched)
                .Include(wu => wu.Watched.UserType)
                .Where(wu => wu.FollowerId == followerId)
                .ToList();

            var users = new List<UserReturnDto>();

            foreach (WatchedUser wu in watchedUsers)
            {
                var user = new UserReturnDto()
                {
                    Id = wu.Watched.Id,
                    UserType = wu.Watched.UserType,
                    Email = wu.Watched.Email,
                    Name = wu.Watched.Name,
                    Surname = wu.Watched.Surname,
                    City = wu.Watched.City,
                    Street = wu.Watched.Street,
                    HouseNumber = wu.Watched.HouseNumber,
                    ApartmentNumber = wu.Watched.ApartmentNumber,
                    PostalCode = wu.Watched.PostalCode,
                    PhoneNumber = wu.Watched.PhoneNumber,
                    WebAddress = wu.Watched.WebAddress
                };
                users.Add(user);
            }

            return users;
        }

        public WatchedUserReturnDto Add(WatchedUserDto dto)
        {
            var watchedUser = _dbContext.
               WatchedUsers
               .FirstOrDefault(wu => wu.FollowerId == dto.FollowerId && wu.WatchedId == dto.WatchedId);

            if (watchedUser is not null)
                throw new ResourceExsistsException("Already exisist");
            
            watchedUser = new WatchedUser()
            {
                FollowerId = dto.FollowerId,
                WatchedId = dto.WatchedId
            };
            watchedUser.DateOfStart = DateTime.Now;

            _dbContext.Add(watchedUser);
            _dbContext.SaveChanges();

            var watchedUserDto = MapToReturnDto(watchedUser);
            return watchedUserDto;
        }

        public void Delete(WatchedUserDto dto)
        {
            var watchedUser = _dbContext.
               WatchedUsers
               .FirstOrDefault(wu => wu.FollowerId == dto.FollowerId && wu.WatchedId == dto.WatchedId);

            if (watchedUser is null)
                throw new NotFoundException("Not found");

            _dbContext.WatchedUsers.Remove(watchedUser);
            _dbContext.SaveChanges();
        }

        private WatchedUserReturnDto MapToReturnDto(WatchedUser watchedUser)
        {
            var watchedUserDto = new WatchedUserReturnDto()
            {
                Id = watchedUser.Id,
                FollowerId = watchedUser.FollowerId,
                WatchedId = watchedUser.WatchedId,
                DateOfStart = watchedUser.DateOfStart
            };
            return watchedUserDto;
        }
    }
}
