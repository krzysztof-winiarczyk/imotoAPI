using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public int? UserStatusId { get; set; }
        public virtual UserStatus UserStatus { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string WebAddress { get; set; }

    }
}
