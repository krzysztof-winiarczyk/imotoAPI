using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarEquipmentService
    {
        public IEnumerable<CarEquipment> GetAll();
        public CarEquipment Add(CarEquipmentDto dto);
        public CarEquipment Edit(int id, CarEquipmentDto dto);
    }

    public class CarEquipmentService : ICarEquipmentService
    {
        private readonly ImotoDbContext _dbContext;

        public CarEquipmentService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarEquipment> GetAll()
        {
            var collection = _dbContext
                .CarEquipment
                .ToList();

            return collection;
        }

        public CarEquipment Add(CarEquipmentDto dto)
        {
            CarEquipment carEquipmnet = new CarEquipment();
            carEquipmnet.Name = dto.Name;
            carEquipmnet.Description = dto.Description;

            _dbContext.Add(carEquipmnet);
            _dbContext.SaveChanges();

            return carEquipmnet;
        }

        public CarEquipment Edit(int id, CarEquipmentDto dto)
        {
            var carEquipment = _dbContext
                .CarEquipment
                .FirstOrDefault(ce => ce.Id == id);

            if (carEquipment is null)
                throw new NotFoundException("not found");

            carEquipment.Name = dto.Name;
            carEquipment.Description = dto.Description;
            _dbContext.SaveChanges();

            return carEquipment;
        }
    }
}
