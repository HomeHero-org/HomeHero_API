using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeHero_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Curriculum", "Email", "LocationResidenceID", "NamesUser", "Password", "ProfilePicture", "QualificationUser", "RealUserID", "RoleID_User", "Salt", "SexUser", "SurnamesUser", "VolunteerPermises", "VolunteerVoucher" },
                values: new object[,]
                {
                    { 1, null, "john.doe@example.com", 1, "John", new byte[] { 1, 2, 3, 4 }, null, 5, null, 1, new byte[] { 5, 6, 7, 8 }, "M", "Doe", true, null },
                    { 2, null, "john.doe@example.com", 1, "John", new byte[] { 1, 2, 3, 4 }, null, 5, null, 1, new byte[] { 5, 6, 7, 8 }, "M", "Doe", true, null }
                });
        }
    }
}
