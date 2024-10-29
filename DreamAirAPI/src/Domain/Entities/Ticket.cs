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
        public int Id { get; set; }
        public string Seat { get; set; } //numero de asiento
        public string ClassSeat { get; set; }
        public string State { get; set; } = "Activo";
        public double Price { get; set; }
        public UserClient User { get; set; }
        public Flight Flight { get; set; }

        public void CalculatePrice()
        {
            if (ClassSeat == "Economic")
            { Price = Flight.PriceDefault * 1.3; }
            else
            { Price = Flight.PriceDefault * 1.5; }


        }
        public void SeatSelected()
        {
            if (ClassSeat == "Economic")
            {
                Seat = "E" + Flight.FreeEconomicSeats;
            }
            else
            {
                Seat = "F" + Flight.FreeFirstClassSeats;
            }
        }


    }
}