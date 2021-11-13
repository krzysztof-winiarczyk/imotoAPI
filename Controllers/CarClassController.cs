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
        [AllowAnonymous]
        public ActionResult<IEnumerable<CarClass>> GetAll()
        {
            var carClasses = _service.GetAll();
            return Ok(carClasses);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarClass> Add([FromBody] CarClassDto dto)
        {
            var carClass = _service.Add(dto);
            return Ok(carClass);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarClass> Edit([FromRoute] int id, [FromBody] CarClassDto dto)
        {
            var carClass = _service.Edit(id, dto);
            return Ok(carClass);
        }


    }
}
