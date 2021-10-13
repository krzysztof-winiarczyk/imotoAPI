using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarBodyworkService
    {
        public IEnumerable<CarBodywork> GetAll();
        public CarBodywork Add(CarBodyworkDto dto);
        public CarBodywork Update(int id, CarBodyworkDto dto);
    }

    public class CarBodyworkService : ICarBodyworkService
    {
        private readonly ImotoDbContext _dbContext;

        public CarBodyworkService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarBodywork> GetAll()
        {
            var collection = _dbContext
                .CarBodyworks
                .ToList();

            return collection;
        }

        public CarBodywork Add(CarBodyworkDto dto)
        {
            CarBodywork carBodywork = new CarBodywork();
            carBodywork.Name = dto.Name;
            carBodywork.Link = dto.Link;

            _dbContext.Add(carBodywork);
            _dbContext.SaveChanges();

            return carBodywork;
        }

        public CarBodywork Update (int id, CarBodyworkDto dto)
        {
            var carBodywork = _dbContext
                .CarBodyworks
                .FirstOrDefault(cb => cb.Id == id);

            if (carBodywork is null)
                throw new NotFoundException("Not found");

            carBodywork.Name = dto.Name;
            carBodywork.Link = dto.Link;
            _dbContext.SaveChanges();

            return carBodywork;
        }
    } 
}
