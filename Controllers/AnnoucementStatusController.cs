using imotoAPI.Entities;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/annoucementStatus")]
    [ApiController]
    public class AnnoucementStatusController : ControllerBase
    {
        private readonly IAnnoucementStatusService _service;

        public AnnoucementStatusController(IAnnoucementStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<AnnoucementStatus>> GetAll()
        {
            var statuses = _service.GetAll();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<AnnoucementStatus> GetById([FromRoute] int id)
        {
            var status = _service.GetById(id);
            return Ok(status);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<AnnoucementStatus> Add([FromBody] AnnoucementStatusDto dto)
        {
            var status = _service.Add(dto);
            return Ok(status);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<AnnoucementStatus> Update([FromRoute] int id, [FromBody] AnnoucementStatusDto dto)
        {
            var status = _service.Update(id, dto);
            return Ok(status);
        }
    }
}
