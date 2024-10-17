using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Seat { get; set; } //numero de asiento
        public string classSeat { get; set; }
        public string State { get; set; }
        public double Price { get; set; }
        public UserClient user { get; set; }
        public Flight flight { get; set; }
        
        public void CalculatePrice()
        {
            if (classSeat == "Economic") 
            { Price = flight.priceDefault * 1.3; } 
            else 
            { Price = flight.priceDefault * 1.5; }
            
            
        }
        public void SeatSelected()
        {
            if (classSeat == "Economic")
            {
                Seat = "E" + flight.freeEconomicSeats;
            }
            else
            {
                Seat = "F" + flight.freeFirstClassSeats;
            }
        }


    }
}
