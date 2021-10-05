using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/car/class")]
    [Controller]
    public class CarClassController : ControllerBase
    {
        private readonly ICarClassService _service;

        public CarClassController(ICarClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var carClasses = _service.GetAll();
            return Ok(carClasses);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CarClassDto dto)
        {
            int id = _service.Add(dto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public ActionResult Edit([FromRoute] int id, [FromBody] CarClassDto dto)
        {
            var carClass = _service.Edit(id, dto);
            return Ok(carClass);
        }


    }
}
