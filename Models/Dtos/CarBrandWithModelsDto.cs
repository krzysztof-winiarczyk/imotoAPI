using imotoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class CarBrandWithModelsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CarModelReturnDto> Models { get; set; }

    }
}
