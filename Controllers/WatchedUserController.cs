using imotoAPI.Entities;
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
    [Route("api/watchedUser")]
    [ApiController]
    public class WatchedUserController : ControllerBase
    {
        private readonly IWatchedUserService _service;

        public WatchedUserController(IWatchedUserService service)
        {
            _service = service;
        }


        [HttpPost]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult<WatchedUserReturnDto> Add([FromBody] WatchedUserDto dto)
        {
            var watchedUser = _service.Add(dto);
            return Ok(watchedUser);
        }

        [HttpDelete]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult Delete([FromBody] WatchedUserDto dto)
        {
            _service.Delete(dto);
            return Ok();
        }
    }
}
