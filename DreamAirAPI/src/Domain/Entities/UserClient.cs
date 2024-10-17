using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserClient : User
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string nationality { get; set; }
        public int dni {  get; set; }
        public int phone { get; set; }
        public int age { get; set; }
        public List<Ticket> tickets { get; set; }

        public void buyTicket(string classSeat, Flight flight)
        {

            Ticket ticket1 = new Ticket
            {
                classSeat = classSeat,
                State = "false",
                UserName = name,
                UserLastName = lastName,
                flight = flight
            };
            tickets.Add(ticket1);
            flight.AddTicket(ticket1);
        }
    }
}
