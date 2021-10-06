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
    [Route("api/car/year")]
    [Controller]
    public class CarYearController : ControllerBase
    {
        private readonly ICarYearService _service;

        public CarYearController(ICarYearService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarYear>> GetAll()
        {
            var collection = _service.GetAll();
            return Ok(collection);
        }

        [HttpPost]
        public ActionResult<CarYear> Add([FromBody] CarYearDto dto)
        {
            var carYear = _service.Add(dto);
            return Ok(carYear);
        }

        [HttpPut("{id}")]
        public ActionResult<CarYear> Update([FromRoute] int id, [FromBody] CarYearDto dto)
        {
            var carYear = _service.Update(id, dto);
            return Ok(carYear);
        }
    }
}
