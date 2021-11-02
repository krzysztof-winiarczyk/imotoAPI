using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IVoivodeshipService
    {
        public IEnumerable<Voivodeship> GetAll();
        public Voivodeship GetById(int id);
        public Voivodeship Add(VoivodeshipDto dto);
        public Voivodeship Update(int id, VoivodeshipDto dto);
    }

    public class VoivodeshipService : IVoivodeshipService
    {
        private readonly ImotoDbContext _dbContext;

        public VoivodeshipService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Voivodeship> GetAll()
        {
            var voivodeships = _dbContext
                .Voivodeships
                .ToList();

            return voivodeships;
        }

        public Voivodeship GetById(int id)
        {
            var voivodeship = _dbContext
                .Voivodeships
                .FirstOrDefault(v => v.Id == id);

            if (voivodeship is null)
                throw new NotFoundException("Not found");

            return voivodeship;
        }

        public Voivodeship Add(VoivodeshipDto dto)
        {
            Voivodeship voivodeship = new()
            {
                Name = dto.Name
            };

            _dbContext.Add(voivodeship);
            _dbContext.SaveChanges();

            return voivodeship;
        }

        public Voivodeship Update(int id, VoivodeshipDto dto)
        {
            var voivodeship = _dbContext
                .Voivodeships
                .FirstOrDefault(v => v.Id == id);

            if (voivodeship is null)
                throw new NotFoundException("Not found");

            voivodeship.Name = dto.Name;
            _dbContext.SaveChanges();

            return voivodeship;
        }
    }
}
