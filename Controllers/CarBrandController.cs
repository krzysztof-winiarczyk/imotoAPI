using imotoAPI.Entities;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/car/brand")]
    [Controller]
    public class CarBrandController : ControllerBase
    {
        private readonly ICarBrandService _carBrandService;

        public CarBrandController(ICarBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CarBrand>> GetAllCarBrands()
        {
            var allBrands = _carBrandService.GetAll();
            return Ok(allBrands);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<CarBrandWithModelsDto> GetCarBrand([FromRoute] int id)
        {
            var carBrandWithModels = _carBrandService.GetCarBrand(id);
            return carBrandWithModels;
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarBrand> AddCarBrand(CarBrandDto dto)
        {
            var carBrand = _carBrandService.Add(dto);
            return Ok(carBrand);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, moderator treści")]
        public ActionResult<CarBrand> EditCarBrand(int id, CarBrandDto dto)
        {
            var carBrand = _carBrandService.Edit(id, dto);
            return Ok(carBrand);
        }
    }
}
