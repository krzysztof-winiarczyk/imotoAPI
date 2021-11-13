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
    [Route("api/car/drive")]
    [Controller]
    public class CarDriveController : ControllerBase
    {
        private readonly ICarDriveService _service;

        public CarDriveController(ICarDriveService service)
        {
            _service = service;
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CarDrive>> GetAll()
        {
            var carDrives = _service.GetAll();
            return Ok(carDrives);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarDrive> Add([FromBody] CarDriveDto dto)
        {
            var carDrive = _service.Add(dto);
            return Ok(carDrive);
        }

        [HttpPut ("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarDrive> Update ([FromRoute] int id, [FromBody] CarDriveDto dto)
        {
            var carDrive = _service.Update(id, dto);
            return Ok(carDrive);
        }
    }
}
