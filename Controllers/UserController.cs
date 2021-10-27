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

        //for admin
        [HttpGet]
        public ActionResult<IEnumerable<UserReturnForAdminDto>> GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }

        //for all
        [HttpGet("{id}")]
        public ActionResult<UserReturnDto> GetAll([FromRoute] int id)
        {
            var user = _service.GetById(id);
            return Ok(user);
        }

        //for user
        [HttpPost]
        public ActionResult<UserReturnForAdminDto> Add([FromBody] UserGetDto dto)
        {
            var user = _service.Add(dto);
            return Ok(user);
        }

        //for user
        [HttpPut("{id}/contactInfo")]
        public ActionResult<UserReturnForAdminDto> UpdateContactInfo([FromRoute] int id, [FromBody] UserUpdateDto dto)
        {
            var user = _service.UpdateContactInfo(id, dto);
            return Ok(user);
        }

        //for user
        [HttpPut("{id}/password")]
        public ActionResult ChangePassword([FromRoute] int id, [FromBody] PasswordDto dto)
        {
            _service.ChangePassword(id, dto);
            return Ok();
        }

        //for user
        [HttpGet("{id}/watchedAnnoucements")]
        public ActionResult<IEnumerable<AnnoucementReturnDto>> GetWatchedAnnoucements([FromRoute] int id)
        {
            var annoucements = _service.GetWatchedAnnoucements(id);
            return Ok(annoucements);
        }

        //for user
        [HttpGet("{id}/watchedUsers")]
        public ActionResult<IEnumerable<UserReturnDto>> GetWatchedUsers([FromRoute] int id)
        {
            var users = _service.GetWatchedUsers(id);
            return Ok(users);
        }


    }
}
