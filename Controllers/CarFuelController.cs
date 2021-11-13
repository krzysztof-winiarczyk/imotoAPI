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
        [AllowAnonymous]
        public ActionResult<IEnumerable<CarFuel>> GetAll()
        {
            var collection = _service.GetAll();
            return Ok(collection);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarFuel> AddCarFuel([FromBody] CarFuelDto dto)
        {
            var carFuel = _service.Add(dto);
            return Ok(carFuel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarFuel> EditCarFuel ([FromRoute] int id, [FromBody] CarFuelDto dto)
        {
            CarFuel edditedCarFuel = _service.Edit(dto, id);
            return Ok(edditedCarFuel);
        }
    }
}
