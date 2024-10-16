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

        public int freeEconomicSeats { get; set; }
        public int freeFirstClassSeats { get; set; }
        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);

        }

        public void CalculateSeat()
        {
            tickets.ForEach(tks =>
            {
                if (tks.classSeat == "Economic")
                {
                    freeEconomicSeats = totalAmountEconomic - 1;
                }
                else
                {
                    freeFirstClassSeats = totalAmountFirstClass - 1;
                }
            });

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
