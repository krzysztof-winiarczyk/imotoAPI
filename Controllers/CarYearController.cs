using imotoAPI.Entities;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//authorization done

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

        [Authorize(Roles = "admin, moderator danych")]
        [HttpPost]
        public ActionResult<CarYear> Add([FromBody] CarYearDto dto)
        {
            var carYear = _service.Add(dto);
            return Ok(carYear);
        }

        [Authorize(Roles = "admin, moderator danych")]
        [HttpPut("{id}")]
        public ActionResult<CarYear> Update([FromRoute] int id, [FromBody] CarYearDto dto)
        {
            var carYear = _service.Update(id, dto);
            return Ok(carYear);
        }
    }
}
