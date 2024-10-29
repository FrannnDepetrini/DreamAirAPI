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
        public int Id { get; set; }

        public string Travel {  get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime DateGo { get; set; }
        public string TimeDepartureGo { get; set; }
        public string TimeArrivalGo { get; set; }

        public DateTime? DateBack { get; set; } 
        public string? TimeDepartureBack { get; set; }
        public string? TimeArrivalBack { get; set; }

        public string Duration { get; set; }  
        public int TotalAmountEconomic { get; set; }
        public int TotalAmountFirstClass { get; set; }
        public float PriceDefault { get; set; }
        public string Airline { get; set; }
        public List<Ticket>  Tickets { get; set; }
        public UserAirline UserAirline { get; set; }
        public int FreeEconomicSeats { get; set; } = 0;
        public int FreeFirstClassSeats { get; set; } = 0;
        


        public void CalculateSeat(string classSeat)
        {
            if (classSeat == "Economic")
            {
                    FreeEconomicSeats = FreeEconomicSeats + 1;  
            } else 
            {
                    FreeFirstClassSeats = FreeFirstClassSeats + 1;
            };
        }
        

        public void CalculateDuration() { 
                TimeSpan dep = TimeSpan.Parse(TimeDepartureGo);
                TimeSpan arr = TimeSpan.Parse(TimeArrivalGo);
                TimeSpan durationCalculated;
                if (arr > dep)
                {
                    durationCalculated = arr - dep;
                }
                else
                {
                    durationCalculated = (arr + TimeSpan.FromDays(1) - dep);
                }
                this.Duration = $"{(int)durationCalculated.TotalHours:D2}:{durationCalculated.Minutes:D2}Hs";
        }
    }
}
