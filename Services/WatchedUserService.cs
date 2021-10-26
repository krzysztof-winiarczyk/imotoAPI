using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{

    public interface IWatchedUserService
    {
        public WatchedUser Get(WatchedUserDto dto);
        public WatchedUser Add(WatchedUserDto dto);
        public void Delete(WatchedUserDto dto);
    }

    public class WatchedUserService : IWatchedUserService
    {
        private readonly ImotoDbContext _dbContext;

        public WatchedUserService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WatchedUser Get(WatchedUserDto dto)
        {
            var watchedUser = _dbContext.
                WatchedUsers
                .FirstOrDefault(wu => wu.FollowerId == dto.FollowerId && wu.WatchedId == dto.WatchedId);

            if (watchedUser is null)
                throw new NotFoundException("Not found");

            return watchedUser;
        }

        public WatchedUser Add(WatchedUserDto dto)
        {
            var watchedUser = _dbContext.
               WatchedUsers
               .FirstOrDefault(wu => wu.FollowerId == dto.FollowerId && wu.WatchedId == dto.WatchedId);

            if (watchedUser is not null)
                throw new ResourceExsistsException("Already exisist");
            
            watchedUser = new WatchedUser()
            {
                FollowerId = dto.FollowerId,
                WatchedId = dto.FollowerId
            };
            watchedUser.DateOfStart = DateTime.Now;

            _dbContext.Add(watchedUser);
            _dbContext.SaveChanges();

            return watchedUser;
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
    }
}
