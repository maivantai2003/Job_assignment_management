using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChiTietQuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "chiTietQuyens");

            migrationBuilder.AddColumn<string>(
                name: "HanhDong",
                table: "chiTietQuyens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HanhDong",
                table: "chiTietQuyens");

            migrationBuilder.AddColumn<bool>(
                name: "TrangThai",
                table: "chiTietQuyens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
