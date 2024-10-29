using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fourteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_UserAirlines_UserAirlineid",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_flightid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_UserClients_userid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdmins_Users_id",
                table: "UserAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAirlines_Users_id",
                table: "UserAirlines");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClients_Users_id",
                table: "UserClients");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "UserClients",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "nationality",
                table: "UserClients",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "UserClients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "UserClients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "dni",
                table: "UserClients",
                newName: "Dni");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "UserClients",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserClients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "UserAirlines",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserAirlines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserAdmins",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Tickets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "flightid",
                table: "Tickets",
                newName: "FlightId");

            migrationBuilder.RenameColumn(
                name: "classSeat",
                table: "Tickets",
                newName: "ClassSeat");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_userid",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_flightid",
                table: "Tickets",
                newName: "IX_Tickets_FlightId");

            migrationBuilder.RenameColumn(
                name: "travel",
                table: "Flights",
                newName: "Travel");

            migrationBuilder.RenameColumn(
                name: "totalAmountFirstClass",
                table: "Flights",
                newName: "TotalAmountFirstClass");

            migrationBuilder.RenameColumn(
                name: "totalAmountEconomic",
                table: "Flights",
                newName: "TotalAmountEconomic");

            migrationBuilder.RenameColumn(
                name: "timeDepartureGo",
                table: "Flights",
                newName: "TimeDepartureGo");

            migrationBuilder.RenameColumn(
                name: "timeDepartureBack",
                table: "Flights",
                newName: "TimeDepartureBack");

            migrationBuilder.RenameColumn(
                name: "timeArrivalGo",
                table: "Flights",
                newName: "TimeArrivalGo");

            migrationBuilder.RenameColumn(
                name: "timeArrivalBack",
                table: "Flights",
                newName: "TimeArrivalBack");

            migrationBuilder.RenameColumn(
                name: "priceDefault",
                table: "Flights",
                newName: "PriceDefault");

            migrationBuilder.RenameColumn(
                name: "freeFirstClassSeats",
                table: "Flights",
                newName: "FreeFirstClassSeats");

            migrationBuilder.RenameColumn(
                name: "freeEconomicSeats",
                table: "Flights",
                newName: "FreeEconomicSeats");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Flights",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "departure",
                table: "Flights",
                newName: "Departure");

            migrationBuilder.RenameColumn(
                name: "dateGo",
                table: "Flights",
                newName: "DateGo");

            migrationBuilder.RenameColumn(
                name: "dateBack",
                table: "Flights",
                newName: "DateBack");

            migrationBuilder.RenameColumn(
                name: "arrival",
                table: "Flights",
                newName: "Arrival");

            migrationBuilder.RenameColumn(
                name: "airline",
                table: "Flights",
                newName: "Airline");

            migrationBuilder.RenameColumn(
                name: "UserAirlineid",
                table: "Flights",
                newName: "UserAirlineId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Flights",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_UserAirlineid",
                table: "Flights",
                newName: "IX_Flights_UserAirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_UserAirlines_UserAirlineId",
                table: "Flights",
                column: "UserAirlineId",
                principalTable: "UserAirlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_UserClients_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "UserClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdmins_Users_Id",
                table: "UserAdmins",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAirlines_Users_Id",
                table: "UserAirlines",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClients_Users_Id",
                table: "UserClients",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_UserAirlines_UserAirlineId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_UserClients_UserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdmins_Users_Id",
                table: "UserAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAirlines_Users_Id",
                table: "UserAirlines");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClients_Users_Id",
                table: "UserClients");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "UserClients",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "UserClients",
                newName: "nationality");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserClients",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserClients",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "UserClients",
                newName: "dni");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "UserClients",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserClients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserAirlines",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserAirlines",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserAdmins",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Tickets",
                newName: "flightid");

            migrationBuilder.RenameColumn(
                name: "ClassSeat",
                table: "Tickets",
                newName: "classSeat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                newName: "IX_Tickets_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                newName: "IX_Tickets_flightid");

            migrationBuilder.RenameColumn(
                name: "UserAirlineId",
                table: "Flights",
                newName: "UserAirlineid");

            migrationBuilder.RenameColumn(
                name: "Travel",
                table: "Flights",
                newName: "travel");

            migrationBuilder.RenameColumn(
                name: "TotalAmountFirstClass",
                table: "Flights",
                newName: "totalAmountFirstClass");

            migrationBuilder.RenameColumn(
                name: "TotalAmountEconomic",
                table: "Flights",
                newName: "totalAmountEconomic");

            migrationBuilder.RenameColumn(
                name: "TimeDepartureGo",
                table: "Flights",
                newName: "timeDepartureGo");

            migrationBuilder.RenameColumn(
                name: "TimeDepartureBack",
                table: "Flights",
                newName: "timeDepartureBack");

            migrationBuilder.RenameColumn(
                name: "TimeArrivalGo",
                table: "Flights",
                newName: "timeArrivalGo");

            migrationBuilder.RenameColumn(
                name: "TimeArrivalBack",
                table: "Flights",
                newName: "timeArrivalBack");

            migrationBuilder.RenameColumn(
                name: "PriceDefault",
                table: "Flights",
                newName: "priceDefault");

            migrationBuilder.RenameColumn(
                name: "FreeFirstClassSeats",
                table: "Flights",
                newName: "freeFirstClassSeats");

            migrationBuilder.RenameColumn(
                name: "FreeEconomicSeats",
                table: "Flights",
                newName: "freeEconomicSeats");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Flights",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Departure",
                table: "Flights",
                newName: "departure");

            migrationBuilder.RenameColumn(
                name: "DateGo",
                table: "Flights",
                newName: "dateGo");

            migrationBuilder.RenameColumn(
                name: "DateBack",
                table: "Flights",
                newName: "dateBack");

            migrationBuilder.RenameColumn(
                name: "Arrival",
                table: "Flights",
                newName: "arrival");

            migrationBuilder.RenameColumn(
                name: "Airline",
                table: "Flights",
                newName: "airline");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Flights",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_UserAirlineId",
                table: "Flights",
                newName: "IX_Flights_UserAirlineid");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_UserAirlines_UserAirlineid",
                table: "Flights",
                column: "UserAirlineid",
                principalTable: "UserAirlines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_flightid",
                table: "Tickets",
                column: "flightid",
                principalTable: "Flights",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_UserClients_userid",
                table: "Tickets",
                column: "userid",
                principalTable: "UserClients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdmins_Users_id",
                table: "UserAdmins",
                column: "id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAirlines_Users_id",
                table: "UserAirlines",
                column: "id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClients_Users_id",
                table: "UserClients",
                column: "id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
