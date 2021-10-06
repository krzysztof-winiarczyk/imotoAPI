using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarDriveService
    {
        public IEnumerable<CarDrive> GetAll();
        public CarDrive Add(CarDriveDto dto);
        public CarDrive Update(int id, CarDriveDto dto);
    }

    public class CarDriveService : ICarDriveService
    {
        private readonly ImotoDbContext _dbContext;

        public CarDriveService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarDrive> GetAll()
        {
            var collection = _dbContext
                .CarDrives
                .ToList();

            return collection;
        }

        public CarDrive Add(CarDriveDto dto)
        {
            var carDrive = new CarDrive();
            carDrive.Name = dto.Name;
            carDrive.Acronym = dto.Acronym;
            _dbContext.Add(carDrive);
            _dbContext.SaveChanges();
            return carDrive;
        }

        public CarDrive Update(int id, CarDriveDto dto)
        {
            var carDrvie = _dbContext
                .CarDrives
                .FirstOrDefault(cd => cd.Id == id);

            if (carDrvie is null)
                throw new NotFoundException("notFound");

            carDrvie.Name = dto.Name;
            carDrvie.Acronym = dto.Acronym;
            _dbContext.SaveChanges();
            return carDrvie;
        }
    }
}
