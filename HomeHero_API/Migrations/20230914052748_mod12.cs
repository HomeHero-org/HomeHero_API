using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHero_API.Migrations
{
    /// <inheritdoc />
    public partial class mod12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Curriculum", "Email", "LocationResidenceID", "NamesUser", "Password", "ProfilePicture", "QualificationUser", "RealUserID", "RoleID_User", "Salt", "SexUser", "SurnamesUser", "VolunteerPermises", "VolunteerVoucher" },
                values: new object[] { 2, null, "john.doe@example.com", 1, "John", new byte[] { 1, 2, 3, 4 }, null, 5, null, 1, new byte[] { 5, 6, 7, 8 }, "M", "Doe", true, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
