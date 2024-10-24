using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class twelfthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role" },
                values: new object[,]
                {
                    { 2, "Emirates@gmail.com", "ba2436bd25a09dd572c044797e6978eaa9c498fb36fa0f59fb672ca03cc3faf7", "airline" },
                    { 3, "Flybondi@gmail.com", "70b9b5d2b27a567b84e80e7213fa3223b4a2332ac0725bb10b3f0761c892e9ca", "airline" },
                    { 4, "joako.tanlon@gmail.com", "54f4b7d00e3bd65c83d48611676db7d46aea0dd2e1d9367ec22b726e9bfdaf2e", "cliente" },
                    { 5, "frandepe7@gmail.com", "cd982f7c8f2a4cc48b615887fa6aa97a6127d8cc87046ccc955a45454e1e27b4", "cliente" },
                    { 6, "marmax0504@gmail.com", "d7d4e80d1597ec0d878279dbde7fa7623924f8f06d24ce477b5f20f686b85cbe", "cliente" }
                });

            migrationBuilder.InsertData(
                table: "UserAirlines",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 2, "Emirates" },
                    { 3, "Flybondi" }
                });

            migrationBuilder.InsertData(
                table: "UserClients",
                columns: new[] { "id", "age", "dni", "lastName", "name", "nationality", "phone" },
                values: new object[,]
                {
                    { 4, 22, 44290276, "Tanlongo", "Joaquin", "Argentino", "3412122907" },
                    { 5, 19, 45838091, "Depetrini", "Francisco", "Argentino", "3472582334" },
                    { 6, 21, 44778419, "Martin", "Maximo", "Argentino", "3496502453" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAirlines",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAirlines",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserClients",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserClients",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserClients",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
