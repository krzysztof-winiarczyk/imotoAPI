using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class EnterpriseUser
    {

        public int UserId { get; set; }
        public User User { get; set; }


        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string WebAddress { get; set; }
    }
}
