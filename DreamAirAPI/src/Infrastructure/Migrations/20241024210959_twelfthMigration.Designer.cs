﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241024210959_twelfthMigration")]
    partial class twelfthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Domain.Entities.Flight", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserAirlineid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("airline")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("arrival")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("dateBack")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dateGo")
                        .HasColumnType("TEXT");

                    b.Property<string>("departure")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("duration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("freeEconomicSeats")
                        .HasColumnType("INTEGER");

                    b.Property<int>("freeFirstClassSeats")
                        .HasColumnType("INTEGER");

                    b.Property<float>("priceDefault")
                        .HasColumnType("REAL");

                    b.Property<string>("timeArrivalBack")
                        .HasColumnType("TEXT");

                    b.Property<string>("timeArrivalGo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("timeDepartureBack")
                        .HasColumnType("TEXT");

                    b.Property<string>("timeDepartureGo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("totalAmountEconomic")
                        .HasColumnType("INTEGER");

                    b.Property<int>("totalAmountFirstClass")
                        .HasColumnType("INTEGER");

                    b.Property<string>("travel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("UserAirlineid");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Seat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("classSeat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("flightid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("flightid");

                    b.HasIndex("userid");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.UserAdmin", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.ToTable("UserAdmins");

                    b.HasData(
                        new
                        {
                            id = 1,
                            email = "admin@gmail.com",
                            password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            role = "admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserAirline", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("UserAirlines");

                    b.HasData(
                        new
                        {
                            id = 2,
                            email = "Emirates@gmail.com",
                            password = "ba2436bd25a09dd572c044797e6978eaa9c498fb36fa0f59fb672ca03cc3faf7",
                            role = "airline",
                            name = "Emirates"
                        },
                        new
                        {
                            id = 3,
                            email = "Flybondi@gmail.com",
                            password = "70b9b5d2b27a567b84e80e7213fa3223b4a2332ac0725bb10b3f0761c892e9ca",
                            role = "airline",
                            name = "Flybondi"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserClient", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<int>("age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("dni")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nationality")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("UserClients");

                    b.HasData(
                        new
                        {
                            id = 4,
                            email = "joako.tanlon@gmail.com",
                            password = "54f4b7d00e3bd65c83d48611676db7d46aea0dd2e1d9367ec22b726e9bfdaf2e",
                            role = "cliente",
                            age = 22,
                            dni = 44290276,
                            lastName = "Tanlongo",
                            name = "Joaquin",
                            nationality = "Argentino",
                            phone = "3412122907"
                        },
                        new
                        {
                            id = 5,
                            email = "frandepe7@gmail.com",
                            password = "cd982f7c8f2a4cc48b615887fa6aa97a6127d8cc87046ccc955a45454e1e27b4",
                            role = "cliente",
                            age = 19,
                            dni = 45838091,
                            lastName = "Depetrini",
                            name = "Francisco",
                            nationality = "Argentino",
                            phone = "3472582334"
                        },
                        new
                        {
                            id = 6,
                            email = "marmax0504@gmail.com",
                            password = "d7d4e80d1597ec0d878279dbde7fa7623924f8f06d24ce477b5f20f686b85cbe",
                            role = "cliente",
                            age = 21,
                            dni = 44778419,
                            lastName = "Martin",
                            name = "Maximo",
                            nationality = "Argentino",
                            phone = "3496502453"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Flight", b =>
                {
                    b.HasOne("Domain.Entities.UserAirline", "UserAirline")
                        .WithMany("flights")
                        .HasForeignKey("UserAirlineid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAirline");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Domain.Entities.Flight", "flight")
                        .WithMany("tickets")
                        .HasForeignKey("flightid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserClient", "user")
                        .WithMany("tickets")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flight");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Domain.Entities.UserAdmin", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.UserAdmin", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.UserAirline", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.UserAirline", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.UserClient", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.UserClient", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Flight", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("Domain.Entities.UserAirline", b =>
                {
                    b.Navigation("flights");
                });

            modelBuilder.Entity("Domain.Entities.UserClient", b =>
                {
                    b.Navigation("tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
