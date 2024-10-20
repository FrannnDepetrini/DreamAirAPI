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
    [Migration("20241019233658_fifthMigration")]
    partial class fifthMigration
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

                    b.Property<string>("airline")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("arrival")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("date");

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

                    b.Property<string>("timeArrival")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("timeDeparture")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("totalAmountEconomic")
                        .HasColumnType("INTEGER");

                    b.Property<int>("totalAmountFirstClass")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

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

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Domain.Entities.UserClient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("dni")
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nationality")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("UserClients");
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

            modelBuilder.Entity("Domain.Entities.Flight", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("Domain.Entities.UserClient", b =>
                {
                    b.Navigation("tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
