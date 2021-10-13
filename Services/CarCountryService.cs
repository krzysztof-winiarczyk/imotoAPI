using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarCountryService
    {
        public IEnumerable<CarCountry> GetAll();
        public CarCountry Add(CarCountryDto dto);
        public CarCountry Update(int id, CarCountryDto dto);
    }

    public class CarCountryService : ICarCountryService
    {
        private readonly ImotoDbContext _dbContext;

        public CarCountryService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarCountry> GetAll()
        {
            var collection = _dbContext
                .CarCountries
                .ToList();

            return collection;
        }

        public CarCountry Add(CarCountryDto dto)
        {
            CarCountry carCountry = new CarCountry();
            carCountry.Name = dto.Name;
            carCountry.Acronym = dto.Acronym;

            _dbContext.Add(carCountry);
            _dbContext.SaveChanges();

            return carCountry;
        }

        public CarCountry Update(int id, CarCountryDto dto)
        {
            var carCountry = _dbContext.
                CarCountries
                .FirstOrDefault(cc => cc.Id == id);

            if (carCountry is null)
                throw new NotFoundException("Not found");

            carCountry.Name = dto.Name;
            carCountry.Acronym = dto.Name;
            _dbContext.SaveChanges();

            return carCountry;
        }
    }
}
