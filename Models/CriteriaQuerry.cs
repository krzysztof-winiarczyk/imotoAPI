using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class CriteriaQuerry
    {
        public string Criterion { get; set; }
        public string Condition { get; set; }

        public bool IsValid()
        {
            if (Criterion == "country")
            {
                if (Condition == "polska")
                    return true;
                else
                    return false;
            }
            else if (Criterion == "fuel")
            {
                if (Condition == "benzyna")
                    return true;
                else
                    return false;
            }
            else if (Criterion == "maxPrice")
            {
                try
                {
                    int price = Int32.Parse(Condition);
                }
                catch (FormatException e)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
