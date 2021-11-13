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
    [Route("api/watchedAnnoucement")]
    [ApiController]
    public class WatchedAnnoucementController : ControllerBase
    {
        private readonly IWatchedAnnoucementService _service;

        public WatchedAnnoucementController(IWatchedAnnoucementService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "użytkownik")]
        [Authorize(Roles = "admin")]
        public ActionResult<WatchedAnnoucementReturnDto> Add([FromBody] WatchedAnnoucementDto dto)
        {
            var watchedAnnoucement = _service.Add(dto);
            return Ok(watchedAnnoucement);
        }

        [HttpDelete]
        [Authorize(Roles = "użytkownik")]
        [Authorize(Roles = "admin")]
        //TODO: chceck id of user
        public ActionResult Delete([FromBody] WatchedAnnoucementDto dto)
        {
            _service.Delete(dto);
            return Ok();
        }
    }
}
