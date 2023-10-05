using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHero_API.Migrations
{
    /// <inheritdoc />
    public partial class userCityIDFIX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Location");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
