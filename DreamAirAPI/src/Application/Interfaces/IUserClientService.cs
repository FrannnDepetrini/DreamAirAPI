﻿using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserClientService
    {
        int Create(UserClientRequest client);

        List<UserClientDto> Get();

        UserClientDto GetById(int id);

        int Delete(int id);

        List<TicketDto> GetTickets(int id);
    }
}
