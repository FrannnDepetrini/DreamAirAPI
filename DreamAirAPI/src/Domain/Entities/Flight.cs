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
        public int totalAmount { get; set; }
        public float priceDefault { get; set; }
        public string airline { get; set; }

        public static string CalculateDuration (string timeArrival, string timeDeparture)
        {
            DateTime dep = DateTime.Parse(timeDeparture);
            DateTime arr = DateTime.Parse(timeArrival);
            TimeSpan duration = arr - dep;
            return $"{(int)duration.TotalHours:D2}:{duration.Minutes:D2}Hs"; 
        }
    }
}
