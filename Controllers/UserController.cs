using imotoAPI.Models;
using imotoAPI.Services;
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
        public ActionResult<IEnumerable<UserReturnForAdminDto>> GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserReturnForAdminDto> GetAll([FromRoute] int id)
        {
            var user = _service.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserReturnForAdminDto> Add([FromBody] UserGetDto dto)
        {
            var user = _service.Add(dto);
            return Ok(user);
        }

        [HttpPut("{id}/contactInfo")]
        public ActionResult<UserReturnForAdminDto> UpdateContactInfo([FromRoute] int id, [FromBody] UserUpdateDto dto)
        {
            var user = _service.UpdateContactInfo(id, dto);
            return Ok(user);
        }

        [HttpPut("{id}/password")]
        public ActionResult ChangePassword([FromRoute] int id, [FromBody] PasswordDto dto)
        {
            _service.ChangePassword(id, dto);
            return Ok();
        }
    }
}
