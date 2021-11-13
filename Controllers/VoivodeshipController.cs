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
    [Route("api/voivodeship")]
    [ApiController]
    public class VoivodeshipController : ControllerBase
    {
        private readonly IVoivodeshipService _service;

        public VoivodeshipController(IVoivodeshipService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Voivodeship>> GetAll()
        {
            var voivodeships = _service.GetAll();
            return Ok(voivodeships);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Voivodeship> GetById([FromRoute] int id)
        {
            var voivodeship = _service.GetById(id);
            return Ok(voivodeship);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<Voivodeship> Add([FromBody] VoivodeshipDto dto)
        {
            var voivodeship = _service.Add(dto);
            return Ok(voivodeship);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<Voivodeship> Update([FromRoute] int id, [FromBody] VoivodeshipDto dto)
        {
            var voivodeship = _service.Update(id, dto);
            return Ok(voivodeship);
        }

    }
}
