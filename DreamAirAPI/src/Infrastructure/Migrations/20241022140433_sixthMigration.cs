using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flights_flightid",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_UserClients_userid",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "email",
                table: "UserClients");

            migrationBuilder.DropColumn(
                name: "password",
                table: "UserClients");

            migrationBuilder.DropColumn(
                name: "role",
                table: "UserClients");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_userid",
                table: "Tickets",
                newName: "IX_Tickets_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_flightid",
                table: "Tickets",
                newName: "IX_Tickets_flightid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Flights",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

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
                name: "FK_UserClients_Users_id",
                table: "UserClients",
                column: "id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_flightid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_UserClients_userid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClients_Users_id",
                table: "UserClients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_userid",
                table: "Ticket",
                newName: "IX_Ticket_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_flightid",
                table: "Ticket",
                newName: "IX_Ticket_flightid");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "UserClients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "UserClients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "UserClients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Flights",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flights_flightid",
                table: "Ticket",
                column: "flightid",
                principalTable: "Flights",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_UserClients_userid",
                table: "Ticket",
                column: "userid",
                principalTable: "UserClients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
