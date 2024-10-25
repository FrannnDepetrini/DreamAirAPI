using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thirteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "id", "UserAirlineid", "airline", "arrival", "dateBack", "dateGo", "departure", "duration", "freeEconomicSeats", "freeFirstClassSeats", "priceDefault", "timeArrivalBack", "timeArrivalGo", "timeDepartureBack", "timeDepartureGo", "totalAmountEconomic", "totalAmountFirstClass", "travel" },
                values: new object[,]
                {
                    { 1, 2, "Emirates", "Buenos Aires (Bsas)", null, new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosario (Ros)", "3hs", 0, 0, 85000f, null, "15:00", null, "12:00", 100, 25, "Ida" },
                    { 2, 3, "Flybondi", "Buenos Aires (Bsas)", new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosario (Ros)", "3hs", 0, 0, 85000f, "01:00", "15:00", "22:00", "12:00", 100, 25, "IDAyVUELTA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
