using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarTransmissionService
    {
        public IEnumerable<CarTransmission> GetAll();
        public CarTransmission Add(CarTransmissionDto dto);
        public CarTransmission Update(int id, CarTransmissionDto dto);
    }

    public class CarTransmissionService : ICarTransmissionService
    {
        private readonly ImotoDbContext _dbContext;

        public CarTransmissionService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarTransmission> GetAll()
        {
            var collection = _dbContext
                .CarTransmissions
                .ToList();

            return collection;
        }

        public CarTransmission Add(CarTransmissionDto dto)
        {
            var carTransmission = new CarTransmission();
            carTransmission.Name = dto.Name;
            carTransmission.Description = dto.Description;
            _dbContext.Add(carTransmission);
            _dbContext.SaveChanges();
            return carTransmission;
        }

        public CarTransmission Update(int id, CarTransmissionDto dto)
        {
            var carTransmission = _dbContext.
                CarTransmissions
                .FirstOrDefault(ct => ct.Id == id);

            if (carTransmission is null)
                throw new NotFoundException("not found");

            carTransmission.Name = dto.Name;
            carTransmission.Description = dto.Description;

            _dbContext.SaveChanges();
            return carTransmission;
        }

    }
}
