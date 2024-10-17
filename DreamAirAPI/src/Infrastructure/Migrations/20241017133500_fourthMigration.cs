using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLastName",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Ticket",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserClients",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    nationality = table.Column<string>(type: "TEXT", nullable: false),
                    dni = table.Column<int>(type: "INTEGER", nullable: false),
                    phone = table.Column<int>(type: "INTEGER", nullable: false),
                    age = table.Column<int>(type: "INTEGER", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClients", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_userid",
                table: "Ticket",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_UserClients_userid",
                table: "Ticket",
                column: "userid",
                principalTable: "UserClients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_UserClients_userid",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "UserClients");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_userid",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "UserLastName",
                table: "Ticket",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Ticket",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
