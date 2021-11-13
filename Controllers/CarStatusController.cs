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
    [Route("api/car/status")]
    [Controller]
    public class CarStatusController : ControllerBase
    {
        private readonly ICarStatusSerivce _service;

        public CarStatusController(ICarStatusSerivce service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CarStatus>> GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarStatus> Post([FromBody] CarStatusDto dto)
        {
            var result = _service.Add(dto);
            return Ok(result); 
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarStatus> Put([FromRoute] int id, [FromBody] CarStatusDto dto)
        {
            var result = _service.Update(id, dto);
            return Ok(result);
        }


    }
}
