using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarshipProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedStarships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Starships",
                columns: new[] { "Id", "Manufacturer", "Model", "Name", "StarshipClass" },
                values: new object[,]
                {
                    { 1, "Corellian Engineering Corporation", "YT-1300 light freighter", "Millennium Falcon", "Light freighter" },
                    { 2, "Incom Corporation", "T-65 X-wing starfighter", "X-Wing", "Starfighter" },
                    { 3, "Sienar Fleet Systems", "Twin Ion Engine starfighter", "TIE Fighter", "Starfighter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Starships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Starships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Starships",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
