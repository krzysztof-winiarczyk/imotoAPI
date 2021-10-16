using imotoAPI.Entities;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarModelService
    {
        public CarModel AddCarModel(CarModelGetDto dto);
    }

    public class CarModelService : ICarModelService
    {
        private readonly ImotoDbContext _dbContext;

        public CarModelService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CarModel AddCarModel(CarModelGetDto dto)
        {
            var carModel = new CarModel();
            carModel.Name = dto.Name;
            carModel.CarBrandId = dto.CarBrandId;

            _dbContext.Add(carModel);
            _dbContext.SaveChanges();

            return carModel;
        }
    }
}
