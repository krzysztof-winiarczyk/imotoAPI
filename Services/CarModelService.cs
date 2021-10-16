using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarModelService
    {
        public CarModelReturnDto AddCarModel(CarModelGetDto dto);
        public CarModel EditCarModel(int modelId, CarModelGetDto dto);
    }

    public class CarModelService : ICarModelService
    {
        private readonly ImotoDbContext _dbContext;

        public CarModelService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CarModelReturnDto AddCarModel(CarModelGetDto dto)
        {
            var carModel = new CarModel();
            carModel.Name = dto.Name;
            carModel.CarBrandId = dto.CarBrandId;

            _dbContext.Add(carModel);
            _dbContext.SaveChanges();

            var carModelDto = new CarModelReturnDto();
            carModelDto.Id = carModel.Id;
            carModelDto.Name = carModel.Name;

            return carModelDto;
        }

        public CarModel EditCarModel(int modelId, CarModelGetDto dto)
        {
            var carModel = _dbContext
                .CarModels
                .FirstOrDefault(cm => cm.Id == modelId);

            if (carModel is null)
                throw new NotFoundException("Not found");

            carModel.Name = dto.Name;
            carModel.CarBrandId = dto.CarBrandId;

            _dbContext.SaveChanges();

            return carModel;

        }
    }
}
