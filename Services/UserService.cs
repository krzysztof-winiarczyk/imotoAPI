﻿using imotoAPI.Entities;
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
        public IEnumerable<UserReturnForAdminDto> GetAll();
        public UserReturnDto GetById(int id);
        public UserReturnForAdminDto Add(UserGetDto dto);
        public UserReturnForAdminDto UpdateContactInfo(int id, UserUpdateDto dto);
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

        //for admin
        public IEnumerable<UserReturnForAdminDto> GetAll()
        {
            var users = _dbContext
                .Users
                .Include(u => u.UserType)
                .ToList();

            List<UserReturnForAdminDto> usersDtos = new();
            foreach(User u in users)
            {
                var userDto = MapToReturnForAdminDto(u);
                usersDtos.Add(userDto);
            }
            return usersDtos;
        }

        //for all (public profile)
        public UserReturnDto GetById(int id)
        {
            var user = _dbContext
                .Users
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("Not found");

            var userDto = MapToReturnDto(user);
            return userDto;
        }

        public UserReturnForAdminDto Add(UserGetDto dto)
        {
            if (!IsLoginFree(dto.Login))
                throw new LoginNotUniqueException("Login is taken");

            var user = new User()
            {
                UserTypeId = dto.TypeId,
                Login = dto.Login,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                City = dto.City,
                Street = dto.Street,
                HouseNumber = dto.HouseNumber,
                ApartmentNumber = dto.ApartmentNumber,
                PostalCode = dto.PostalCode,
                PhoneNumber = dto.PhoneNumber,
                WebAddress = dto.WebAddress
            };
            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.PasswordHash = hashedPassword;

            _dbContext.Add(user);
            _dbContext.SaveChanges();

            var returnDto = MapToReturnForAdminDto(user);
            return returnDto;
        }

        public UserReturnForAdminDto UpdateContactInfo(int id, UserUpdateDto dto)
        {
            var user = _dbContext
                .Users
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("Not found");

            user.Email = dto.Email;
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.City = dto.City;
            user.Street = dto.Street;
            user.HouseNumber = dto.HouseNumber;
            user.ApartmentNumber = dto.ApartmentNumber;
            user.PostalCode = dto.PostalCode;
            user.PhoneNumber = dto.PhoneNumber;
            user.WebAddress = dto.WebAddress;
            _dbContext.SaveChanges();

            var returnDto = MapToReturnForAdminDto(user);
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



        private static UserReturnForAdminDto MapToReturnForAdminDto (User user)
        {
            var userDto = new UserReturnForAdminDto()
            {
                Id = user.Id,
                TypeId = user.UserTypeId,
                UserType = user.UserType,
                Login = user.Login,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                Street = user.Street,
                HouseNumber = user.HouseNumber,
                ApartmentNumber = user.ApartmentNumber,
                PostalCode = user.PostalCode,
                PhoneNumber = user.PhoneNumber,
                WebAddress = user.WebAddress
            };
            return userDto;
        }

        private static UserReturnDto MapToReturnDto ( User user)
        {
            var userDto = new UserReturnDto()
            {
                Id = user.Id,
                UserType = user.UserType,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                Street = user.Street,
                HouseNumber = user.HouseNumber,
                ApartmentNumber = user.ApartmentNumber,
                PostalCode = user.PostalCode,
                PhoneNumber = user.PhoneNumber,
                WebAddress = user.WebAddress
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
