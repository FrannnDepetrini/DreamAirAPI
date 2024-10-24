using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timeDeparture",
                table: "Flights",
                newName: "travel");

            migrationBuilder.RenameColumn(
                name: "timeArrival",
                table: "Flights",
                newName: "timeDepartureGo");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Flights",
                newName: "timeArrivalGo");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateBack",
                table: "Flights",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateGo",
                table: "Flights",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "timeArrivalBack",
                table: "Flights",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "timeDepartureBack",
                table: "Flights",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateBack",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "dateGo",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "timeArrivalBack",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "timeDepartureBack",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "travel",
                table: "Flights",
                newName: "timeDeparture");

            migrationBuilder.RenameColumn(
                name: "timeDepartureGo",
                table: "Flights",
                newName: "timeArrival");

            migrationBuilder.RenameColumn(
                name: "timeArrivalGo",
                table: "Flights",
                newName: "date");
        }
    }
}
