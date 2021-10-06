using imotoAPI.Entities;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imotoAPI.Exceptions;

namespace imotoAPI.Services
{
    public interface ICarColorService
    {
        public IEnumerable<CarColor> GetAll();
        public CarColor Add(CarColorDto dto);
        public CarColor Update(int id, CarColorDto dto);
    }

    public class CarColorService : ICarColorService
    {
        private readonly ImotoDbContext _dbContext;

        public CarColorService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarColor> GetAll()
        {
            var collection = _dbContext
                .CarColors
                .ToList();

            return collection;
        }

        public CarColor Add (CarColorDto dto)
        {
            var carColor = new CarColor();
            carColor.Name = dto.Name;
            _dbContext.Add(carColor);
            _dbContext.SaveChanges();
            return carColor;
        }

        public CarColor Update (int id, CarColorDto dto)
        {
            var carColor = _dbContext
                .CarColors
                .FirstOrDefault(cc => cc.Id == id);

            if (carColor is null)
                throw new NotFoundException("not found");

            carColor.Name = dto.Name;
            _dbContext.SaveChanges();
            return carColor;
        }
    }
}
