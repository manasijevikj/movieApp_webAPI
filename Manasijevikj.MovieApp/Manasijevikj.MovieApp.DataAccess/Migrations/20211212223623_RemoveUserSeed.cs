using Microsoft.EntityFrameworkCore.Migrations;

namespace Manasijevikj.MovieApp.DataAccess.Migrations
{
    public partial class RemoveUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 1, "Aleksandar", "Manasijevikj", "Test123!", "User", "am91" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 2, "Ana", "Jovkovska", "Test456!", "SuperAdmin", "aj94" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 3, "Sara", "Dimitrovska", "Test789!", "Admin", "sd99" });
        }
    }
}
