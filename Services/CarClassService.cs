using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarClassService
    {
        public IEnumerable<CarClass> GetAll();
        public int Add(CarClassDto dto);
        public CarClass Edit(int id, CarClassDto dto);
    }

    public class CarClassService : ICarClassService
    {
        private readonly ImotoDbContext _dbContext;

        public CarClassService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarClass> GetAll()
        {
            var collection = _dbContext
                .CarClasses
                .ToArray();

            return collection;
        }

        public int Add(CarClassDto dto)
        {
            CarClass carClass = new CarClass();
            carClass.Name = dto.Name;
            carClass.Description = dto.Description;

            _dbContext.Add(carClass);
            _dbContext.SaveChanges();

            return carClass.Id;
        }

        public CarClass Edit(int id, CarClassDto dto)
        {
            var carClass = _dbContext
                .CarClasses
                .FirstOrDefault(cc => cc.Id == id);

            if (carClass is null)
                throw new NotFoundException("Not found");

            carClass.Name = dto.Name;
            carClass.Description = dto.Description;
            _dbContext.SaveChanges();

            return carClass;
        }
    }
}
