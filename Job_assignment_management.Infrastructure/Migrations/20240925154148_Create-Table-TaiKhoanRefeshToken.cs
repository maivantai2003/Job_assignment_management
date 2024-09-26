using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTaiKhoanRefeshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taiKhoanRefreshTokens",
                columns: table => new
                {
                    MaTaiKhoanRefreshToken = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInvalidades = table.Column<bool>(type: "bit", nullable: false),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoanRefreshTokens", x => x.MaTaiKhoanRefreshToken);
                    table.ForeignKey(
                        name: "FK_taiKhoanRefreshTokens_taiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "taiKhoans",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taiKhoanRefreshTokens_MaTaiKhoan",
                table: "taiKhoanRefreshTokens",
                column: "MaTaiKhoan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taiKhoanRefreshTokens");
        }
    }
}
