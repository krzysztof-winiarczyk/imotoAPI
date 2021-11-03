using imotoAPI.Entities;
using imotoAPI.Exceptions;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IAnnoucementStatusService
    {
        public IEnumerable<AnnoucementStatus> GetAll();
        public AnnoucementStatus GetById(int id);
        public AnnoucementStatus Add(AnnoucementStatusDto dto);
        public AnnoucementStatus Update(int id, AnnoucementStatusDto dto);
    }

    public class AnnoucementStatusService : IAnnoucementStatusService
    {
        private readonly ImotoDbContext _dbContext;

        public AnnoucementStatusService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AnnoucementStatus> GetAll()
        {
            var statuses = _dbContext
                .AnnoucementStatuses
                .ToList();

            return statuses;
        }

        public AnnoucementStatus GetById(int id)
        {
            var status = _dbContext
                .AnnoucementStatuses
                .FirstOrDefault(s => s.Id == id);

            if (status is null)
                throw new NotFoundException("Not found");

            return status;
        }

        public AnnoucementStatus Add(AnnoucementStatusDto dto)
        {
            var status = new AnnoucementStatus()
            {
                Name = dto.Name,
                Description = dto.Description,
                Editable = true                
            };

            _dbContext.Add(status);
            _dbContext.SaveChanges();

            return status;
        }

        public AnnoucementStatus Update(int id, AnnoucementStatusDto dto)
        {
            var status = _dbContext
                .AnnoucementStatuses
                .FirstOrDefault(s => s.Id == id);

            if (status is null)
                throw new NotFoundException("Not found");

            if (status.Editable == false)
                throw new NotAllowedException("Action is not allowed");

            status.Name = dto.Name;
            status.Description = dto.Description;
            _dbContext.SaveChanges();

            return status;
        }
    }
}
