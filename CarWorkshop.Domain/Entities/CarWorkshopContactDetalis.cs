using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Entities
{
    public class CarWorkshopContactDetalis
    { 
        public string? PhoneNumber { get; set; } = default!;
        public string? Street { get; set; }
        public string? City { get; set; }
       
        public string? PostalCode { get; set; }

    }
}
