using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserClientDto
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public int Dni { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public List<TicketDto> Tickets { get; set; } = new List<TicketDto>();

        public static UserClientDto Create(UserClient userClient) 
        {
            var listMapped = userClient.Tickets.Select(tck =>
            {
                return TicketDto.Create(tck);

                
            });
            return new UserClientDto
            {
                Id = userClient.Id,
                Name = userClient.Name,
                LastName = userClient.LastName,
                Nationality = userClient.Nationality,
                Dni = userClient.Dni,
                Phone = userClient.Phone,
                Age = userClient.Age,
                Tickets = listMapped.ToList()
            };
        }

    }
}
