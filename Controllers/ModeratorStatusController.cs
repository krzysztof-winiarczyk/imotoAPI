using imotoAPI.Entities;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/moderatorStatus")]
    public class ModeratorStatusController : ControllerBase
    {
        private readonly IModeratorStatusService _service;

        public ModeratorStatusController(IModeratorStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ModeratorStatus>> GetAll()
        {
            var statuses = _service.GetAll();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public ActionResult<ModeratorStatus> GetById([FromRoute] int id)
        {
            var status = _service.GetById(id);
            return Ok(status);
        }

        [HttpPost]
        public ActionResult<ModeratorStatus> Add([FromBody] StatusDto dto)
        {
            var status = _service.Add(dto);
            return Ok(status);
        }

        [HttpPut("{id}")]
        public ActionResult<ModeratorStatus> Update([FromRoute] int id, [FromBody] StatusDto dto)
        {
            var status = _service.Update(id, dto);
            return Ok(status);
        }
    }
}
