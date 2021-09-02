using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public EnterpriseUser User { get; set; }

    }
}
