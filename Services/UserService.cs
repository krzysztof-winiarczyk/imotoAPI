using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IUserService
    {
        public IEnumerable<UserReturnForAdminDto> GetAll();
        public UserReturnDto GetById(int id);
        public void DeleteAccount(int id);
        public UserReturnForAdminDto Add(UserGetDto dto);
        public string GenerateJwt(LoginDto dto);
        public UserReturnForAdminDto UpdateContactInfo(int id, UserUpdateDto dto);
        public void ChangePassword(int id, PasswordDto passwordDto);
        public IEnumerable<AnnoucementReturnDto> GetWatchedAnnoucements(int id);
        public IEnumerable<UserReturnDto> GetWatchedUsers(int id);
    }

    public class UserService : IUserService
    {
        private readonly ImotoDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IAnnoucementService _annoucementService;
        private readonly IUserContextService _userContextService;

        public UserService(
            ImotoDbContext dbContext,
            IPasswordHasher<User> passwordHasher,
            AuthenticationSettings authenticationSettings,
            IAnnoucementService annoucementService,
            IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _annoucementService = annoucementService;
            _userContextService = userContextService;
        }

        //for admin
        public IEnumerable<UserReturnForAdminDto> GetAll()
        {
            var users = _dbContext
                .Users
                .Include(u => u.UserType)
                .Include(u => u.UserStatus)
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
                .Include(u => u.UserStatus)
                .FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("Not found");

            if (user.UserStatus.Name == "dezaktywowane")
                throw new NotFoundException("Konto zostało usunięte");

            var userDto = MapToReturnDto(user);
            return userDto;
        }

        //for user
        public void DeleteAccount(int id)
        {
            //get user
            var user = _dbContext
                .Users
                .Include(u => u.UserStatus)
                .FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("Not found");

            if (_userContextService.GetUserRole == "użytkownik" && _userContextService.GetUserId != user.Id)
                throw new ForbidException("");

            //set status "dezaktywowane"
            var userStatus = _dbContext
                .UserStatuses
                .FirstOrDefault(s => s.Name == "dezaktywowane");
            user.UserStatusId = userStatus.Id;
            user.UserStatus = userStatus;


            //get watched annoucements of user
            var watchedAnnoucementsOfUser = _dbContext
                .WatchedAnnoucements
                .Where(wa => wa.UserId == id)
                .ToList();

            var watchedAnnoucementsOfOtherUsers = new List<WatchedAnnoucement>();

            //set status "usunięte" for annoucements of user
            var annoucements = _dbContext
                .Annoucements
                .Where(a => a.UserId == user.Id)
                .ToList();
            var annoucementStatus = _dbContext
                .AnnoucementStatuses
                .FirstOrDefault(s => s.Name == "usunięte");

            foreach(Annoucement a in annoucements)
            {
                a.AnnoucementStatusId = annoucementStatus.Id;
                a.AnnoucementStatus = annoucementStatus;

                var watchedAnnoucementsOfAnnoucements = _dbContext
                    .WatchedAnnoucements
                    .Where(wa => wa.AnnoucementId == a.Id)
                    .ToList();

                watchedAnnoucementsOfOtherUsers.AddRange(watchedAnnoucementsOfAnnoucements);
            }


            _dbContext.WatchedAnnoucements.RemoveRange(watchedAnnoucementsOfUser);
            _dbContext.WatchedAnnoucements.RemoveRange(watchedAnnoucementsOfOtherUsers);
            _dbContext.SaveChanges();
        }

        public UserReturnForAdminDto Add(UserGetDto dto)
        {
            if (!IsLoginFree(dto.Login))
                throw new LoginNotUniqueException("Login is taken");

            var status = _dbContext
                .UserStatuses
                .FirstOrDefault(s => s.Name == "aktywne");

            var user = new User()
            {
                UserTypeId = dto.TypeId,
                UserStatusId = status.Id,
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

        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext
                .Users
                .Include(u => u.UserStatus)
                .FirstOrDefault(u => u.Login == dto.Login);

            if (user is null)
                throw new IncorrectLoggingException("Incorrect login or passwor");

            if (user.UserStatus == GetStatusDezaktywowane())
                throw new IncorrectLoggingException("Incorrect login or passwor");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new IncorrectLoggingException("Incorrect login or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "użytkownik")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public UserReturnForAdminDto UpdateContactInfo(int id, UserUpdateDto dto)
        {
            var user = _dbContext
                .Users
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("Not found");

            var role = _userContextService.GetUserRole;
            if (role == "użytkownik" && user.Id != _userContextService.GetUserId)
                throw new ForbidException("");

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

            if (_userContextService.GetUserRole == "użytkownik" && _userContextService.GetUserId != user.Id)
                throw new ForbidException("");

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

        public IEnumerable<AnnoucementReturnDto> GetWatchedAnnoucements(int id)
        {
            var watchedAnnoucements = _dbContext
                .WatchedAnnoucements
                .Where(wa => wa.UserId == id)
                .ToList();

            if (_userContextService.GetUserRole == "użytkownik" && _userContextService.GetUserId != id)
                throw new ForbidException("");

            var annoucements = new List<AnnoucementReturnDto>();

            foreach(WatchedAnnoucement wa in watchedAnnoucements)
            {
                var annoucement = _annoucementService.GetById(wa.AnnoucementId);
                annoucements.Add(annoucement);
            }

            return annoucements;
        }

        public IEnumerable<UserReturnDto> GetWatchedUsers(int id)
        {
            var watchedUsers = _dbContext
                .WatchedUsers
                .Where(wa => wa.FollowerId == id)
                .ToList();

            if (_userContextService.GetUserRole == "użytkownik" && _userContextService.GetUserId != id)
                throw new ForbidException("");

            var users = new List<UserReturnDto>();

            foreach(WatchedUser wa in watchedUsers)
            {
                var user = GetById(wa.WatchedId);
                users.Add(user);
            }

            return users;
        }



        private static UserReturnForAdminDto MapToReturnForAdminDto (User user)
        {
            var userDto = new UserReturnForAdminDto()
            {
                Id = user.Id,
                TypeId = user.UserTypeId,
                UserType = user.UserType,
                UserStatus = user.UserStatus,
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

        private UserStatus GetStatusDezaktywowane()
        {
            var status = _dbContext
                .UserStatuses
                .FirstOrDefault(s => s.Name == "dezaktywowane");

            return status;
        }
    }
}
