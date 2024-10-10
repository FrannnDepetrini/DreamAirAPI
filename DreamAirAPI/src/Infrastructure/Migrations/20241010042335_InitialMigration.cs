using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    departure = table.Column<string>(type: "TEXT", nullable: false),
                    arrival = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    timeDeparture = table.Column<string>(type: "TEXT", nullable: false),
                    timeArrival = table.Column<string>(type: "TEXT", nullable: false),
                    duration = table.Column<string>(type: "TEXT", nullable: false),
                    totalAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    priceDefault = table.Column<float>(type: "REAL", nullable: false),
                    airline = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
