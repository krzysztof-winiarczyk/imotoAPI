using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IModertorTypeService
    {
        public IEnumerable<ModeratorType> GetAll();
        public ModeratorType GetById(int id);
        public ModeratorType Add(ModeratorTypeDto dto);
        public ModeratorType Update(int id, ModeratorTypeDto dto);
    }

    public class ModeratorTypeService : IModertorTypeService
    {
        private readonly ImotoDbContext _dbContext;

        public ModeratorTypeService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ModeratorType> GetAll()
        {
            var moderatorTypes = _dbContext
                .ModeratorTypes
                .ToList();

            return moderatorTypes;
        }

        public ModeratorType GetById(int id)
        {
            var moderatorType = _dbContext
                .ModeratorTypes
                .FirstOrDefault(mt => mt.Id == id);

            if (moderatorType is null)
                throw new NotFoundException("Not found");

            return moderatorType;
        }

        public ModeratorType Add(ModeratorTypeDto dto)
        {
            ModeratorType moderatorType = new();
            moderatorType.Name = dto.Name;
            moderatorType.Description = dto.Description;

            _dbContext.Add(moderatorType);
            _dbContext.SaveChanges();

            return moderatorType;
        }

        public ModeratorType Update(int id, ModeratorTypeDto dto)
        {
            var moderatorType = _dbContext
                .ModeratorTypes
                .FirstOrDefault(mt => mt.Id == id);

            if (moderatorType is null)
                throw new NotFoundException("Not found");

            moderatorType.Name = dto.Name;
            moderatorType.Description = dto.Description;

            _dbContext.SaveChanges();

            return moderatorType;
        }

    }
}
