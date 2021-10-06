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
    [Route("api/car/transmission")]
    [Controller]
    public class CarTransmissionController : ControllerBase
    {
        private readonly ICarTransmissionService _service;

        public CarTransmissionController(ICarTransmissionService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarTransmission>> GetAll()
        {
            var collection = _service.GetAll();
            return Ok(collection);
        }

        [HttpPost]
        public ActionResult<CarTransmission> Add([FromBody] CarTransmissionDto dto)
        {
            var carTransmission = _service.Add(dto);
            return Ok(carTransmission);
        }

        [HttpPut("{id}")]
        public ActionResult<CarTransmission> Update([FromRoute] int id, [FromBody] CarTransmissionDto dto)
        {
            var carTransmission = _service.Update(id, dto);
            return Ok(carTransmission);
        }
    }
}
