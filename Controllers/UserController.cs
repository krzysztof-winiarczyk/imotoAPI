using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<UserReturnForAdminDto>> GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<UserReturnDto> GetById([FromRoute] int id)
        {
            var user = _service.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserReturnForAdminDto> Add([FromBody] UserGetDto dto)
        {
            var user = _service.Add(dto);
            return Ok(user);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<JwtDto> Login([FromBody] LoginDto dto)
        {
            var token = _service.GenerateJwt(dto);
            return Ok(token);
        }

        [HttpPut("{id}/contactInfo")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult<UserReturnForAdminDto> UpdateContactInfo([FromRoute] int id, [FromBody] UserUpdateDto dto)
        {
            var user = _service.UpdateContactInfo(id, dto);
            return Ok(user);
        }

        [HttpPut("{id}/password")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult ChangePassword([FromRoute] int id, [FromBody] PasswordDto dto)
        {
            _service.ChangePassword(id, dto);
            return Ok();
        }

        [HttpGet("{id}/watchedAnnoucements")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult<IEnumerable<AnnoucementReturnDto>> GetWatchedAnnoucements([FromRoute] int id)
        {
            var annoucements = _service.GetWatchedAnnoucements(id);
            return Ok(annoucements);
        }

        [HttpGet("{id}/watchedUsers")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult<IEnumerable<UserReturnDto>> GetWatchedUsers([FromRoute] int id)
        {
            var users = _service.GetWatchedUsers(id);
            return Ok(users);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult DeleteAccount([FromRoute] int id)
        {
            _service.DeleteAccount(id);
            return Ok();
        }

        //TODO: account retreive
    }
}
