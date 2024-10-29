﻿using Application.Interfaces;
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
        private readonly IUserAirlineRepository _userAirlineRepository;
        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository, IUserRepository userRepository, IUserAirlineRepository userAirlineRepository)
        {
            _flightRepository = flightRepository;
            _userRepository = userRepository;
            _userAirlineRepository = userAirlineRepository;

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

        public int Delete(int flightId, int userId)
        {
            var flightFound = _flightRepository.GetById(flightId);
            if (flightFound == null) throw new Exception("Flight not found");
            var airlineFound = _userAirlineRepository.GetById(userId);
            if (airlineFound == null) throw new Exception("Airline not found");

            if (flightFound.UserAirlineId == airlineFound.Id)
            {
                return _flightRepository.Delete(flightFound);

            }
            throw new Exception("The specified flight does not belong to the airline.");
        }

        public int Create(FlightRequest flight, int userId)
        {
            var clientFound = _userRepository.GetById(userId);
            if (clientFound is UserAirline userAirline)
            {
                Flight flight1 = new Flight
                {
                    Travel = flight.Travel,
                    Departure = flight.Departure,
                    Arrival = flight.Arrival,
                    DateGo = flight.DateGo,
                    TimeDepartureGo = flight.TimeDepartureGo,
                    TimeArrivalGo = flight.TimeArrivalGo,
                    DateBack = flight.DateBack ?? null,
                    TimeDepartureBack = flight.TimeDepartureBack ?? null,
                    TimeArrivalBack = flight.TimeArrivalBack ?? null,
                    TotalAmountEconomic = flight.TotalAmountEconomic,
                    TotalAmountFirstClass = flight.TotalAmountFirstClass,
                    PriceDefault = flight.PriceDefault,
                    UserAirline = userAirline,
                    Airline = userAirline.Name,

                };
                flight1.CalculateDuration();
                return _flightRepository.Create(flight1);
            }
            throw new Exception("Not allowed");
        }

        public int Update(FlightUpdateRequest flight)
        {
            var flightFound = _flightRepository.GetById(flight.FlightId);
            if (flightFound == null) throw new Exception("Flight not found");
            Flight flight1 = new Flight
            {
                DateGo = flight.DateGo,
                TimeDepartureGo = flight.TimeDepartureGo,
                TimeArrivalGo = flight.TimeArrivalGo,
                DateBack = flight.DateBack ?? null,
                TimeDepartureBack = flight.TimeDepartureBack ?? null,
                TimeArrivalBack = flight.TimeArrivalBack
            };
            flight1.CalculateDuration();
            return _flightRepository.Update(flightFound, flight1);
        }

    }
}