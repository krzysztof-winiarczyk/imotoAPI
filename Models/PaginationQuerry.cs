using imotoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class PaginationQuerry
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public void Validate()
        {
            ValidatePageSize();
            ValidatePageNumber();
        }

        private void ValidatePageSize()
        {
            if (PageSize < 1)
            {
                PageSize = 5;
            }
        }

        private void ValidatePageNumber()
        {
            if (PageNumber < 1)
            {
                PageNumber = 1;
            }
        }
    }
}
