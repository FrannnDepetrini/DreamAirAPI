using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserAirline : User
    {
        public string name { get; set; }

        List<Flight> flights { get; set; } = new List<Flight>();
    }

    
}
