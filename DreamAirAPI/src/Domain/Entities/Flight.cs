using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public DateTime date { get; set; }
        public string timeDeparture { get; set; }
        public string timeArrival { get; set; }
        public string duration { get; set; }  
        public int totalAmountEconomic { get; set; }
        public int totalAmountFirstClass { get; set; }
        public float priceDefault { get; set; }
        public string airline { get; set; }
        public List<Ticket>  tickets { get; set; }
        public UserAirline UserAirline { get; set; }
        public int freeEconomicSeats { get; set; } = 0;
        public int freeFirstClassSeats { get; set; } = 0;
        //public void AddTicket(Ticket ticket)
        //{
        //    tickets.Add(ticket);
        //    CalculateSeat();
        //}

        public string CalculateSeat(string classSeat)
        {
            //// Contar cuántos asientos económicos y de primera clase ya están ocupados
            //int occupiedEconomicSeats = tickets.Count(t => t.classSeat == "Economic");
            //int occupiedFirstClassSeats = tickets.Count(t => t.classSeat == "FirstClass");

            //// Calcular los asientos libres restando los ocupados del total
            //freeEconomicSeats = totalAmountEconomic - occupiedEconomicSeats;
            //freeFirstClassSeats = totalAmountFirstClass - occupiedFirstClassSeats;
            if (classSeat == "Economic")
            {
                if (freeEconomicSeats == totalAmountEconomic)
                {
                    return null;
                } else
                {
                    freeEconomicSeats = freeEconomicSeats + 1;
                }
            } else if (classSeat == "FirstClass")
            {
                if (freeEconomicSeats == totalAmountEconomic)
                {
                    return "No hay mas asientos disponibles";
                }
                else
                {
                    freeFirstClassSeats = freeFirstClassSeats + 1;
                }
            };
            return "Compra de asiento exitosa";
        }
        

        public void CalculateDuration() { 
                TimeSpan dep = TimeSpan.Parse(timeDeparture);
                TimeSpan arr = TimeSpan.Parse(timeArrival);
                TimeSpan durationCalculated;
                if (arr > dep)
                {
                    durationCalculated = arr - dep;
                }
                else
                {
                    durationCalculated = (arr + TimeSpan.FromDays(1) - dep);
                }
                this.duration = $"{(int)durationCalculated.TotalHours:D2}:{durationCalculated.Minutes:D2}Hs";
        }
    }
}
