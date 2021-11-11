using imotoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class SortQuerry
    {
        public string SortBy { get; set; }
        public string SortDirection { get; set; }

        public void Validate()
        {
            ValidateSortBy();
            ValidateSortDirection();
        }

        private void ValidateSortBy()
        {
            //"mapping" value from querry to entity name
            SortBy = SortBy switch
            {
                "carYear" => nameof(Annoucement.CarYear),
                "price" => nameof(Annoucement.Price),
                "mileage" => nameof(Annoucement.Mileage),
                _ => nameof(Annoucement.Price),
            };
        }

        private void ValidateSortDirection()
        {
            switch (SortDirection)
            {
                case "asc":
                    SortDirection = "asc";
                    break;
                case "desc":
                    SortDirection = "desc";
                    break;
                default:
                    SortDirection = "asc";
                    break;
            }
        }
    }
}
