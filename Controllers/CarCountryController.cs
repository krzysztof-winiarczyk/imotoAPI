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
    [Route("api/car/country")]
    [Controller]
    public class CarCountryController : ControllerBase
    {
        private readonly ICarCountryService _service;

        public CarCountryController(ICarCountryService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CarCountry>> GetAll()
        {
            var carCountries = _service.GetAll();
            return Ok(carCountries);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarCountry> Add([FromBody] CarCountryDto dto)
        {
            var carCountry = _service.Add(dto);
            return Ok(carCountry);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarCountry> Edit([FromRoute] int id, [FromBody] CarCountryDto dto)
        {
            var carCountry = _service.Update(id, dto);
            return Ok(carCountry);
        }
    }
}
