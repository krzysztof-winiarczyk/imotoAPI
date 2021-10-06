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
    [Route("api/car/color")]
    [Controller]
    public class CarColorController : ControllerBase
    {
        private readonly ICarColorService _service;

        public CarColorController(ICarColorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarColor>> GetAll()
        {
            var collection = _service.GetAll();
            return Ok(collection);
        }

        [HttpPost]
        public ActionResult<CarColor> Add([FromBody] CarColorDto dto)
        {
            var carColor = _service.Add(dto);
            return Ok(carColor);
        }

        [HttpPut ("{id}")]
        public ActionResult<CarColor> Update([FromRoute] int id, [FromBody] CarColorDto dto)
        {
            var carColor = _service.Update(id, dto);
            return Ok(carColor);
        }
    }
}
