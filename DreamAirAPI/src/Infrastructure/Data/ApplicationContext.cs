using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserClient> UserClients { get; set; }

        public DbSet<UserAirline> UserAirlines { get; set; }
        public DbSet<UserAdmin> UserAdmins {  get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().UseTptMappingStrategy();

            modelBuilder.Entity<UserAdmin>().HasData(CreateUserAdminDataSeed());
            modelBuilder.Entity<UserAirline>().HasData(CreateUserAirlineDataSeed());
            modelBuilder.Entity<UserClient>().HasData(CreateUserClientDataSeed());
            modelBuilder.Entity<Flight>().HasData(CreateFlightDataSeed());
        }

        
        private UserAdmin[] CreateUserAdminDataSeed()
        {

            return new UserAdmin[]
            {
                new UserAdmin
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    Name = "admin",
                    Password = HashGenerator.GenerateHash("admin"),
                    Role = "admin"
                }
            };
        }

        private UserAirline[] CreateUserAirlineDataSeed()
        {

            return new UserAirline[]
            {
                new UserAirline
                {
                    Id = 2,
                    Name = "Emirates",
                    Email = "Emirates@gmail.com",
                    Password = HashGenerator.GenerateHash("emirates"),
                    Role = "airline"
                },

                new UserAirline
                {
                    Id = 3,
                    Name = "Flybondi",
                    Email = "Flybondi@gmail.com",
                    Password = HashGenerator.GenerateHash("Flybondi"),
                    Role = "airline"
                }
            };
        }


        private UserClient[] CreateUserClientDataSeed()
        {

            return new UserClient[]
            {
                new UserClient
                {
                    Id = 4,
                    Email = "joako.tanlon@gmail.com",
                    Password = HashGenerator.GenerateHash("joako"),
                    Name = "Joaquin",
                    LastName = "Tanlongo",
                    Nationality = "Argentino",
                    Dni = 44290276,
                    Phone = "3412122907",
                    Age = 22
                },
                new UserClient
                {
                    Id = 5,
                    Email = "frandepe7@gmail.com",
                    Password = HashGenerator.GenerateHash("frandepe"),
                    Name = "Francisco",
                    LastName = "Depetrini",
                    Nationality = "Argentino",
                    Dni = 45838091,
                    Phone = "3472582334",
                    Age = 19
                },

                new UserClient
                {
                    Id = 6,
                    Email = "marmax0504@gmail.com",
                    Password = HashGenerator.GenerateHash("marmax"),
                    Name = "Maximo",
                    LastName = "Martin",
                    Nationality = "Argentino",
                    Dni = 44778419,
                    Phone = "3496502453",
                    Age = 21
                },
            };
        }


        ///Vuelos creados
        private Object[] CreateFlightDataSeed()
        {

            return new object[]
            {
                new 
                {
                    Id = 1,
                    Travel = "Ida",
                    Departure= "Rosario (Ros)",
                    Arrival="Buenos Aires (Bsas)",
                    DateGo= new DateTime(2024,10, 25),
                    TimeDepartureGo = "12:00",
                    TimeArrivalGo = "15:00",
                    Duration = "3hs",
                    TotalAmountEconomic = 100,
                    FreeEconomicSeats = 0,
                    TotalAmountFirstClass = 25,
                    FreeFirstClassSeats = 0,
                    PriceDefault = 85000f,
                    UserAirlineId = 2,
                    Airline = "Emirates"

                } , new 
                {
                    Id = 2,
                    Travel = "IDAyVUELTA",
                    Departure= "Rosario (Ros)",
                    Arrival="Buenos Aires (Bsas)",
                    DateGo= new DateTime(2024,10,25),
                    TimeDepartureGo = "12:00",
                    TimeArrivalGo = "15:00",
                    DateBack= new DateTime(2024,11,25),
                    TimeDepartureBack = "22:00",
                    TimeArrivalBack = "01:00",
                    Duration = "3hs",
                    TotalAmountEconomic = 100,
                    FreeEconomicSeats = 0,
                    TotalAmountFirstClass = 25,
                    FreeFirstClassSeats = 0,
                    PriceDefault = 85000f,
                    UserAirlineId = 3,
                    Airline = "Flybondi",

                }
            };
        }
    

    }
}
