using imotoAPI.Entities;
using imotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface ICarModelService
    {

    }

    public class CarModelService : ICarModelService
    {
        private readonly ImotoDbContext _dbContext;

        public CarModelService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
