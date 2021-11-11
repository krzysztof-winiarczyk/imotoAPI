﻿using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/moderator")]
    [ApiController]
    public class ModeratorController : ControllerBase
    {
        private readonly IModeratorService _service;

        public ModeratorController(IModeratorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ModeratorReturnDto>> GetAll()
        {
            var moderators = _service.GetAll();
            return Ok(moderators);
        }

        [HttpGet("{id}")]
        public ActionResult<ModeratorReturnDto> GetById([FromRoute] int id)
        {
            var moderatorDto = _service.GetById(id);
            return Ok(moderatorDto);
        }

        [HttpPost]
        public ActionResult<ModeratorReturnDto> Add([FromBody] ModeratorGetDto dto)
        {
            var moderatorDto = _service.Add(dto);
            return moderatorDto;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _service.GenerateJwt(dto);
            return Ok(token);
        }

        [HttpPut("{id}/contactInfo")]
        public ActionResult<ModeratorReturnDto> UpdateContactInfo([FromRoute] int id, [FromBody] ModeratorUpdateDto dto)
        {
            var moderatorDto = _service.UpdateContactInfo(id, dto);
            return Ok(moderatorDto);
        }

        [HttpPut("{id}/status")]
        public ActionResult<ModeratorReturnDto> UpdateStatus([FromRoute] int id, [FromBody] ModeratorStatusIdDto dto)
        {
            var moderatorDto = _service.ChangeStatus(id, dto);
            return Ok(moderatorDto);
        }

        [HttpPut("{id}/password")]
        public ActionResult ChangePassword([FromRoute] int id, [FromBody] PasswordDto dto)
        {
            _service.ChangePassword(id, dto);
            return Ok();
        }
    }
}
