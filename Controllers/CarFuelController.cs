using imotoAPI.Entities;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/car/fuel")]
    [ApiController]
    public class CarFuelController : ControllerBase
    {
        private readonly ICarFuelService _service;

        public CarFuelController(ICarFuelService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var collection = _service.GetAll();
            return Ok(collection);
        }

        [HttpPost]
        public ActionResult AddCarFuel([FromBody] CarFuelDto dto)
        {
            int id = _service.Add(dto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public ActionResult EditCarFuel ([FromRoute] int id, [FromBody] CarFuelDto dto)
        {
            CarFuel edditedCarFuel = _service.Edit(dto, id);
            return Ok(edditedCarFuel);
        }
    }
}
