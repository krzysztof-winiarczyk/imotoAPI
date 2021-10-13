using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarBrandService
    {
        public IEnumerable<CarBrand> GetAll();
        public CarBrand Add(CarBrandDto dto);
        public CarBrand Edit(int id, CarBrandDto dto);
    }

    public class CarBrandService : ICarBrandService
    {
        private readonly ImotoDbContext _dbContext;

        public CarBrandService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarBrand> GetAll()
        {
            var collection = _dbContext
                .CarBrands
                .ToArray();

            return collection;
        }

        public CarBrand Add(CarBrandDto dto)
        {
            var carBrand = new CarBrand();
            carBrand.Name = dto.Name;

            _dbContext.Add(carBrand);
            _dbContext.SaveChanges();

            return carBrand;
        }

        public CarBrand Edit(int id, CarBrandDto dto)
        {
            var carBrand = _dbContext
                .CarBrands
                .FirstOrDefault(cb => cb.Id == id);

            if (carBrand is null)
                throw new NotFoundException("Not Found");

            carBrand.Name = dto.Name;
            _dbContext.SaveChanges();

            return carBrand;

        }
    }
}
