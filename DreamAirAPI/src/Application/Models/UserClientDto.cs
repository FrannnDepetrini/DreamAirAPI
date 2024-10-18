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
        public string name { get; set; }
        public string lastName { get; set; }
        public string nationality { get; set; }
        public int dni { get; set; }
        public string phone { get; set; }
        public int age { get; set; }
        public List<TicketDto> tickets { get; set; } = new List<TicketDto>();

        public static UserClientDto Create(UserClient userClient) 
        {
            var listMapped = userClient.tickets.Select(tck =>
            {
                return TicketDto.Create(tck);

                
            });
            return new UserClientDto
            {
                name = userClient.name,
                lastName = userClient.lastName,
                nationality = userClient.nationality,
                dni = userClient.dni,
                phone = userClient.phone,
                age = userClient.age,
                tickets = listMapped.ToList()
            };
        }

    }
}
