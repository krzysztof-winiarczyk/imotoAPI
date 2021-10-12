using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarStatusSerivce
    {
        public IEnumerable<CarStatus> GetAll();
        public CarStatus Add(CarStatusDto dto);
        public CarStatus Update(int id, CarStatusDto dto);
    }

    public class CarStatusService : ICarStatusSerivce
    {
        private readonly ImotoDbContext _dbContext;

        public CarStatusService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarStatus> GetAll()
        {
            var result = _dbContext
                .CarStatuses
                .ToList();

            return result;
        }

        public CarStatus Add(CarStatusDto dto)
        {
            var carStatus = new CarStatus();
            carStatus.Name = dto.Name;
            carStatus.Description = dto.Description;

            _dbContext.Add(carStatus);
            _dbContext.SaveChanges();

            return carStatus;
        }

        public CarStatus Update(int id, CarStatusDto dto)
        {
            var carStatus = _dbContext
                .CarStatuses
                .FirstOrDefault(cs => cs.Id == id);

            if (carStatus is null)
                throw new NotFoundException("Not found");

            carStatus.Name = dto.Name;
            carStatus.Description = dto.Description;
            _dbContext.SaveChanges();

            return carStatus;
        }
    }
}
