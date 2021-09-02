using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int TypeId { get; set; }
        public UserType UserType { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }


    }
}
