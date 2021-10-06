using imotoAPI.Entities;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imotoAPI.Exceptions;

namespace imotoAPI.Services
{
    public interface ICarYearService
    {
        public IEnumerable<CarYear> GetAll();
        public CarYear Add(CarYearDto dto);
        public CarYear Update(int id, CarYearDto dto);
    }

    public class CarYearService : ICarYearService
    {
        private readonly ImotoDbContext _dbContext;

        public CarYearService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarYear> GetAll()
        {
            var collection = _dbContext
                .CarYears
                .ToList();

            return collection;
        }

        public CarYear Add(CarYearDto dto)
        {
            var carYear = new CarYear();
            carYear.YearOfProduction = dto.YearOfProduction;
            _dbContext.Add(carYear);
            _dbContext.SaveChanges();
            return carYear;
        }

        public CarYear Update (int id, CarYearDto dto)
        {
            var carYear = _dbContext
                .CarYears
                .FirstOrDefault(cy => cy.Id == id);

            if (carYear is null)
                throw new NotFoundException("not found");

            carYear.YearOfProduction = dto.YearOfProduction;
            _dbContext.SaveChanges();
            return carYear;
        }
    }
}
