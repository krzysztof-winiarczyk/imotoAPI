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
    [Route("api/moderatorType")]
    [Controller]
    public class ModeratorTypeController : ControllerBase
    {
        private readonly IModertorTypeService _service;

        public ModeratorTypeController(IModertorTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ModeratorType>> GetAll()
        {
            var moderatorTypes = _service.GetAll();
            return Ok(moderatorTypes);
        }

        [HttpGet("{id}")]
        public ActionResult<ModeratorType> Get([FromRoute] int id)
        {
            var moderatorType = _service.GetById(id);
            return Ok(moderatorType);
        }

        [HttpPost]
        public ActionResult<ModeratorType> Post([FromBody] ModeratorTypeDto dto)
        {
            var moderatorType = _service.Add(dto);
            return Ok(moderatorType);
        }

        [HttpPut("{id}")]
        public ActionResult<ModeratorType> Update([FromRoute] int id, [FromBody] ModeratorTypeDto dto)
        {
            var moderatorType = _service.Update(id, dto);
            return Ok(moderatorType);
        }
    }
}
