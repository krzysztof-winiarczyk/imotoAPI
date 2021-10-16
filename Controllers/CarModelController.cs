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
    [Route("api/car/model")]
    [Controller]
    public class CarModelController : ControllerBase
    {
        private readonly ICarModelService _carModelService;

        public CarModelController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        [HttpPost]
        public ActionResult<CarModel> AddCarModel([FromBody] CarModelGetDto dto)
        {
            var carModel = _carModelService.AddCarModel(dto);
            return carModel;
        }
    }
}
