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


}
}
