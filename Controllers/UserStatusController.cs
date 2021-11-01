using imotoAPI.Entities;
using imotoAPI.Migrations;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/userStatus")]
    public class UserStatusController : ControllerBase
    {
        private readonly IUserStatusService _service;

        public UserStatusController(IUserStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserStatus>> GetAll()
        {
            var statuses = _service.GetAll();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public ActionResult<UserStatus> GetById([FromRoute] int id)
        {
            var status = _service.GetById(id);
            return Ok(status);
        }

        [HttpPost]
        public ActionResult<UserStatus> Add([FromBody] StatusDto dto)
        {
            var status = _service.Add(dto);
            return Ok(status);
        }

        [HttpPut("{id}")]
        public ActionResult<UserStatus> Update([FromRoute] int id, [FromBody] StatusDto dto)
        {
            var status = _service.Update(id, dto);
            return Ok(status);
        }
    }
}
