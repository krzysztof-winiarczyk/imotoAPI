using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace imotoAPI.Services
{
    public interface IModeratorService
    {
        public IEnumerable<ModeratorReturnDto> GetAll();
        public ModeratorReturnDto GetById(int id);
        public ModeratorReturnDto Add(ModeratorGetDto dto);
        public ModeratorReturnDto UpdateContactInfo(int id, ModeratorUpdateDto dto);
        public void ChangePassword(int id, PasswordDto passwordDto);
        public ModeratorReturnDto ChangeStatus(int id, ModeratorStatusIdDto dto);
    }

    public class ModeratorService : IModeratorService
    {
        private readonly ImotoDbContext _dbContext;
        private readonly IPasswordHasher<Moderator> _passwordHasher;

        public ModeratorService(
            ImotoDbContext dbContext,
            IPasswordHasher<Moderator> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public IEnumerable<ModeratorReturnDto> GetAll()
        {
            var moderators = _dbContext
                .Moderators
                .Include(m => m.ModeratorStatus)
                .ToList();

            var moderatorsDtos = new List<ModeratorReturnDto>();

            foreach(Moderator m in moderators)
            {
                var moderatorDto = this.MapToReturnDto(m);
                moderatorsDtos.Add(moderatorDto);
            }

            return moderatorsDtos;
        }

        public ModeratorReturnDto GetById(int id)
        {
            var moderator = _dbContext
               .Moderators
               .Include(m => m.ModeratorStatus)
               .FirstOrDefault(m => m.Id == id);

            if (moderator is null)
                throw new NotFoundException("Not found");

            var moderatorDto = this.MapToReturnDto(moderator);
            return moderatorDto;
        }

        public ModeratorReturnDto Add(ModeratorGetDto dto)
        {
            if (!IsLoginFree(dto.Login))
                throw new LoginNotUniqueException("Login is taken");

            var moderator = new Moderator()
            {
                ModeratorStatusId = dto.StatusId,
                Login = dto.Login,
                Email = dto.Email,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber
            };
            var hashedPassword = _passwordHasher.HashPassword(moderator, dto.Password);
            moderator.PasswordHash = hashedPassword;

            _dbContext.Add(moderator);
            _dbContext.SaveChanges();

            var returnDto = this.MapToReturnDto(moderator);
            return returnDto;
        }

        public ModeratorReturnDto UpdateContactInfo(int id, ModeratorUpdateDto dto)
        {
            var moderator = _dbContext
                .Moderators
                .Include(m => m.ModeratorStatus)
                .FirstOrDefault(m => m.Id == id);

            if (moderator is null)
                throw new NotFoundException("Not found");

            moderator.Email = dto.Email;
            moderator.Name = dto.Name;
            moderator.PhoneNumber = dto.PhoneNumber;
            _dbContext.SaveChanges();

            var returnDto = this.MapToReturnDto(moderator);
            return returnDto;
        }

        public void ChangePassword(int id, PasswordDto passwordDto)
        {
            var moderator = _dbContext
                .Moderators
                .FirstOrDefault(m => m.Id == id);

            if (moderator is null)
                throw new NotFoundException("Not found");

            var result = _passwordHasher.VerifyHashedPassword(moderator, moderator.PasswordHash, passwordDto.OldPassword);
            if (result == PasswordVerificationResult.Success)
            {
                if (passwordDto.OldPassword == passwordDto.NewPassword)
                    throw new OldNewPasswordException("New password must differ form old password");
                else
                {
                    var newHashedPassword = _passwordHasher.HashPassword(moderator, passwordDto.NewPassword);
                    moderator.PasswordHash = newHashedPassword;
                    _dbContext.SaveChanges();
                }
            }
            else
            {
                throw new IncorrectLoggingException("Incorrect login or password");
            }
        }

        public ModeratorReturnDto ChangeStatus(int id, ModeratorStatusIdDto dto)
        {
            var moderator = _dbContext
                .Moderators
                .FirstOrDefault(m => m.Id == id);

            if (moderator is null)
                throw new NotFoundException("Not found");

            //check if there would be at least one admin after changes
            bool isModeratorAdmin = moderator.ModeratorStatusId == _dbContext.ModeratorStatuses.FirstOrDefault(s => s.Name == "admin").Id;
            if (isModeratorAdmin)
            {
                int howManyAdmins = _dbContext
                    .Moderators
                    .Where(m => m.ModeratorStatus.Name == "admin")
                    .ToList()
                    .Count;

                if (howManyAdmins <= 1)
                    throw new NotAllowedException("Nie można dezaktywować jedynego konta administratora");
            }

            moderator.ModeratorStatusId = dto.StatusId;
            _dbContext.SaveChanges();

            moderator = _dbContext
                .Moderators
                .Include(m => m.ModeratorStatus)
                .FirstOrDefault(m => m.Id == id);
            var moderatorDto = this.MapToReturnDto(moderator);
            return moderatorDto;
        }

        private ModeratorReturnDto MapToReturnDto (Moderator moderator)
        {
            var moderatorDto = new ModeratorReturnDto();
            moderatorDto.Id = moderator.Id;
            moderatorDto.Status = moderator.ModeratorStatus;
            moderatorDto.Email = moderator.Email;
            moderatorDto.Name = moderator.Name;
            moderatorDto.PhoneNumber = moderator.PhoneNumber;
            return moderatorDto;
        }

        private bool IsLoginFree (string login)
        {
            var moderator = _dbContext
                .Moderators
                .FirstOrDefault(m => m.Login == login);

            if (moderator is null)
                return true;
            else
                return false;
        }
    }
}
