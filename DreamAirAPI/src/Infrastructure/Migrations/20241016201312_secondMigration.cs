using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "freeEconomicSeats",
                table: "Flights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "freeFirstClassSeats",
                table: "Flights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Seat = table.Column<string>(type: "TEXT", nullable: false),
                    classSeat = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    UserLastName = table.Column<string>(type: "TEXT", nullable: false),
                    flightid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_flightid",
                        column: x => x.flightid,
                        principalTable: "Flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_flightid",
                table: "Ticket",
                column: "flightid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropColumn(
                name: "freeEconomicSeats",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "freeFirstClassSeats",
                table: "Flights");
        }
    }
}
