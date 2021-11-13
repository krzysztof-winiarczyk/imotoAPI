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
    [Route("api/car/equipment")]
    [Controller]
    public class CarEquipmentController : ControllerBase
    {
        private readonly ICarEquipmentService _service;

        public CarEquipmentController(ICarEquipmentService service)
        {
            _service = service;
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CarEquipment>> GetAll()
        {
            var list = _service.GetAll();
            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarEquipment> Add([FromBody] CarEquipmentDto dto)
        {
            var carEquipment = _service.Add(dto);
            return Ok(carEquipment);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarEquipment> Add([FromRoute] int id, [FromBody] CarEquipmentDto dto)
        {
            var edditedCarEquipment = _service.Edit(id, dto);
            return Ok(edditedCarEquipment);
        }
    }
}
