using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarFuelService
    {
        public IEnumerable<CarFuel> GetAll();
        public int Add(CarFuelDto dto);
        public CarFuel Edit(CarFuelDto dto, int id);
    }

    public class CarFuelService : ICarFuelService
    {
        private readonly ImotoDbContext _dbContext;

        public CarFuelService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(CarFuelDto dto)
        {
            CarFuel carFuel = new CarFuel();
            carFuel.Name = dto.Name;
            _dbContext.Add(carFuel);
            _dbContext.SaveChanges();
            return carFuel.Id;
        }

        public IEnumerable<CarFuel> GetAll()
        {
            var collection = _dbContext.CarFuels.ToList();
            return collection;
        }

        public CarFuel Edit(CarFuelDto dto, int id)
        {
            var carFuel = _dbContext
                .CarFuels
                .FirstOrDefault(cf => cf.Id == id);

            if (carFuel is null)
                throw new NotFoundException("Not found");

            carFuel.Name = dto.Name;
            _dbContext.SaveChanges();
            return carFuel;
        }
    }
}
