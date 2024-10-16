using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Seat { get; set; }
        public string classSeat{ get; set; }
        public string State { get; set; }
        public double Price { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public DateTime date { get; set; }
        public string timeDeparture { get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public Flight flightCurrent { get; set; }
        public Ticket(Flight flight)
        {
            flightCurrent = flight;
        }
        public void CalculatePrice(double price, string classSeat)
        {
            if (classSeat == "Economic") 
            { Price = price * 1.3; } 
            else 
            { Price = price * 1.5; }
            
        }



    }
}
