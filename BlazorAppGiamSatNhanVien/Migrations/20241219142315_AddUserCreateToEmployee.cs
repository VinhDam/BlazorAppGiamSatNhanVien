using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppGiamSatNhanVien.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCreateToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCreate",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUpdate",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCreate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserUpdate",
                table: "Employees");
        }
    }
}
