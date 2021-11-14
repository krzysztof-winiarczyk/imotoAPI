using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    /// <summary>
    /// Allows to access user credentials from request (id, role)
    /// </summary>
    public interface IUserContextService
    {
        int GetUserId { get; }
        string GetUserRole { get; }
        ClaimsPrincipal User { get; }
    }

    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int GetUserId => User is null ? -1 : int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public string GetUserRole => User is null ? "" : User.FindFirst(c => c.Type == ClaimTypes.Role).Value;
    }
}
