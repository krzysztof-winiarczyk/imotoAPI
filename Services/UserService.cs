using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IUserService
    {
        public IEnumerable<UserReturnDto> GetAll();
        public UserReturnDto GetById(int id);
        public UserReturnDto Add(UserGetDto dto);
        public UserReturnDto UpdateContactInfo(int id, UserUpdateDto dto);
        public void ChangePassword(int id, PasswordDto passwordDto);
    }

    public class UserService : IUserService
    {
        private readonly ImotoDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(
            ImotoDbContext dbContext,
            IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public IEnumerable<UserReturnDto> GetAll()
        {
            var users = _dbContext
                .Users
                .Include(u => u.UserType)
                .ToList();

            List<UserReturnDto> usersDtos = new();
            foreach(User u in users)
            {
                var userDto = this.MapToReturnDto(u);
                usersDtos.Add(userDto);
            }
            return usersDtos;
        }

        public UserReturnDto GetById(int id)
        {
            var user = _dbContext
                .Users
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("Not found");

            var userDto = this.MapToReturnDto(user);
            return userDto;
        }

        public UserReturnDto Add(UserGetDto dto)
        {
            if (!IsLoginFree(dto.Login))
                throw new LoginNotUniqueException("Login is taken");

            var user = new User()
            {
                TypeId = dto.TypeId,
                Login = dto.Login,
                Email = dto.Email
            };
            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.PasswordHash = hashedPassword;

            _dbContext.Add(user);
            _dbContext.SaveChanges();

            var returnDto = MapToReturnDto(user);
            return returnDto;
        }

        public UserReturnDto UpdateContactInfo(int id, UserUpdateDto dto)
        {
            var user = _dbContext
                .Users
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("Not found");

            user.Email = dto.Email;
            _dbContext.SaveChanges();

            var returnDto = MapToReturnDto(user);
            return returnDto;
        }

        public void ChangePassword(int id, PasswordDto passwordDto)
        {
            var user = _dbContext
               .Users
               .Include(u => u.UserType)
               .FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("Not found");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, passwordDto.OldPassword);
            if (result == PasswordVerificationResult.Success)
            {
                if (passwordDto.OldPassword == passwordDto.NewPassword)
                    throw new OldNewPasswordException("New password must differ form old password");
                else
                {
                    var newHashedPassword = _passwordHasher.HashPassword(user, passwordDto.NewPassword);
                    user.PasswordHash = newHashedPassword;
                    _dbContext.SaveChanges();
                }
            }
            else if (result == PasswordVerificationResult.Failed)
            {
                throw new IncorrectLoggingException("Incorrect password");
            }
        }



        private UserReturnDto MapToReturnDto (User user)
        {
            var userDto = new UserReturnDto()
            {
                Id = user.Id,
                TypeId = user.TypeId,
                UserType = user.UserType,
                Login = user.Login,
                Email = user.Email
            };
            return userDto;
        }

        private bool IsLoginFree (string login)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Login == login);

            if (user is null)
                return true;
            else
                return false;
        }
    }
}
