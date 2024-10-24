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

        }

        
        private UserAdmin[] CreateUserAdminDataSeed()
        {

            return new UserAdmin[]
            {
                new UserAdmin
                {
                    id = 1,
                    email = "admin@gmail.com",
                    password = HashGenerator.GenerateHash("admin"),
                    role = "admin"
                }
            };
        }

        private UserAirline[] CreateUserAirlineDataSeed()
        {

            return new UserAirline[]
            {
                new UserAirline
                {
                    id = 2,
                    name = "Emirates",
                    email = "Emirates@gmail.com",
                    password = HashGenerator.GenerateHash("emirates"),
                    role = "airline"
                },

                new UserAirline
                {
                    id = 3,
                    name = "Flybondi",
                    email = "Flybondi@gmail.com",
                    password = HashGenerator.GenerateHash("Flybondi"),
                    role = "airline"
                }
            };
        }


        private UserClient[] CreateUserClientDataSeed()
        {

            return new UserClient[]
            {
                new UserClient
                {
                    id = 4,
                    email = "joako.tanlon@gmail.com",
                    password = HashGenerator.GenerateHash("joako"),
                    name = "Joaquin",
                    lastName = "Tanlongo",
                    nationality = "Argentino",
                    dni = 44290276,
                    phone = "3412122907",
                    age = 22
                },
                new UserClient
                {
                    id = 5,
                    email = "frandepe7@gmail.com",
                    password = HashGenerator.GenerateHash("frandepe"),
                    name = "Francisco",
                    lastName = "Depetrini",
                    nationality = "Argentino",
                    dni = 45838091,
                    phone = "3472582334",
                    age = 19
                },

                new UserClient
                {
                    id = 6,
                    email = "marmax0504@gmail.com",
                    password = HashGenerator.GenerateHash("marmax"),
                    name = "Maximo",
                    lastName = "Martin",
                    nationality = "Argentino",
                    dni = 44778419,
                    phone = "3496502453",
                    age = 21
                },
            };
        }
    }
}
