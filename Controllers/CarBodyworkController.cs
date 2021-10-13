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
    [Route("api/car/bodywork")]
    [Controller]
    public class CarBodyworkController : ControllerBase
    {
        private readonly ICarBodyworkService _service;

        public CarBodyworkController(ICarBodyworkService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarBodywork>> GetAll()
        {
            var carBodyworks = _service.GetAll();
            return Ok(carBodyworks);
        }

        [HttpPost]
        public ActionResult<CarBodywork> Add([FromBody] CarBodyworkDto dto)
        {
            var carBodywork = _service.Add(dto);
            return Ok(carBodywork);
        }

        [HttpPut("{id}")]
        public ActionResult<CarBodywork> Edit([FromRoute] int id, [FromBody] CarBodyworkDto dto)
        {
            var carBodywork = _service.Update(id, dto);
            return Ok(carBodywork);
        }
    }
}
