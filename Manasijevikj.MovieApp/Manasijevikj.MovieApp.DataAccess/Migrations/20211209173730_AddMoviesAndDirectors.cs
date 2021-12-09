using Microsoft.EntityFrameworkCore.Migrations;

namespace Manasijevikj.MovieApp.DataAccess.Migrations
{
    public partial class AddMoviesAndDirectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Country", "FirstName", "LastName" },
                values: new object[] { 1, "England", "Christopher", "Nolan" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Country", "FirstName", "LastName" },
                values: new object[] { 2, "USA", "Quentin", "Tarantino" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Country", "FirstName", "LastName" },
                values: new object[] { 3, "USA", "Stanley", "Kubrick" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Genre", "Title", "Year" },
                values: new object[] { 1, "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", 1, 3, "Interstellar", 2014 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Genre", "Title", "Year" },
                values: new object[] { 3, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 2, 13, "Pulp Fiction", 1994 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Genre", "Title", "Year" },
                values: new object[] { 2, "A pragmatic U.S. Marine observes the dehumanizing effects the Vietnam War has on his fellow recruits from their brutal boot camp training to the bloody street fighting in Hue.", 3, 1, "Full Metal Jacket", 1987 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
