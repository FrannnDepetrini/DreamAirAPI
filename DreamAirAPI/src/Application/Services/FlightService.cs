using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository, IUserRepository userRepository)
        {
            _flightRepository = flightRepository;
            _userRepository = userRepository;
        }
        

        public List<FlightDto> Get()
        {
            var listMapped = _flightRepository.Get().Select((f) => FlightDto.Create(f)).ToList();
            return listMapped;
        }

        public FlightDto GetById(int id)
        {
            return FlightDto.Create(_flightRepository.GetById(id));
        }

        public int Delete(int id)
        {

            return _flightRepository.Delete(id);
        }

        public int Create(FlightRequest flight, int userId)
        {
            var clientFound = _userRepository.GetById(userId);
            if (clientFound is UserAirline userAirline)
            {
                Flight flight1 = new Flight
                {
                    travel = flight.travel,
                    departure = flight.departure,
                    arrival = flight.arrival,
                    dateGo = flight.dateGo,
                    timeDepartureGo = flight.timeDepartureGo,
                    timeArrivalGo = flight.timeArrivalGo,
                    dateBack = flight.dateBack ?? null,
                    timeDepartureBack = flight.timeDepartureBack ?? null,
                    timeArrivalBack = flight.timeArrivalBack ?? null,
                    totalAmountEconomic = flight.totalAmountEconomic,
                    totalAmountFirstClass = flight.totalAmountFirstClass,
                    priceDefault = flight.priceDefault,
                    UserAirline = userAirline,
                    airline = userAirline.name,

                };
                flight1.CalculateDuration();
                return _flightRepository.Create(flight1);
            }
            throw new Exception("Not allowed");
        }

        public int Update(FlightUpdateRequest flight)
        {
            Flight flight1 = new Flight 
            { 
                dateGo = flight.dateGo, 
                timeDepartureGo = flight.timeDepartureGo, 
                timeArrivalGo = flight.timeArrivalGo,
                dateBack = flight.dateBack ?? null,
                timeDepartureBack = flight.timeDepartureBack ?? null,
                timeArrivalBack = flight.timeArrivalBack
            };
            return _flightRepository.Update(flight.flightId, flight1);
        }

    }
}
