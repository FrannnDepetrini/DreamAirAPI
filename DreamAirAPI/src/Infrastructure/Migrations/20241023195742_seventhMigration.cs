using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAirlineid",
                table: "Flights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserAirlines",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAirlines", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserAirlines_Users_id",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_UserAirlineid",
                table: "Flights",
                column: "UserAirlineid");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_UserAirlines_UserAirlineid",
                table: "Flights",
                column: "UserAirlineid",
                principalTable: "UserAirlines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_UserAirlines_UserAirlineid",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "UserAirlines");

            migrationBuilder.DropIndex(
                name: "IX_Flights_UserAirlineid",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "UserAirlineid",
                table: "Flights");
        }
    }
}
