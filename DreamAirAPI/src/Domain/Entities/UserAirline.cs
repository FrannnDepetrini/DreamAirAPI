using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserAirline : User
    {
        public string Name { get; set; }

        public List<Flight> Flights { get; set; } = new List<Flight>();
    }

    
}
