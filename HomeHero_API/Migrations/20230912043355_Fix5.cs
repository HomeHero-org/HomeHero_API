using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHero_API.Migrations
{
    /// <inheritdoc />
    public partial class Fix5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationID", "Address", "City" },
                values: new object[] { 4, null, "MOSQUERA" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "LocationID",
                keyValue: 4);
        }
    }
}
