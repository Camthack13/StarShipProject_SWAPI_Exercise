using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarshipProject.Migrations
{
    /// <inheritdoc />
    public partial class updateStarShipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CargoCapacity",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consumables",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostInCredits",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Crew",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HyperdriveRating",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MGLT",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxAtmospheringSpeed",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passengers",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoCapacity",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Consumables",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "CostInCredits",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Crew",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "HyperdriveRating",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "MGLT",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "MaxAtmospheringSpeed",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Passengers",
                table: "Starships");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Starships",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
