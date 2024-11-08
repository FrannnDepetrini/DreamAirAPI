using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserClient : User
    {
        
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public int Dni {  get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
