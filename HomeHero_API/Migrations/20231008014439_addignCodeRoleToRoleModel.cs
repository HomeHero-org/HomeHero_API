using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHero_API.Migrations
{
    /// <inheritdoc />
    public partial class addignCodeRoleToRoleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodeRole",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeRole",
                table: "Role");
        }
    }
}
