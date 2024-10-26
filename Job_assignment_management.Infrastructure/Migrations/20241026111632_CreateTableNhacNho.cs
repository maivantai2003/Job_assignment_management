using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableNhacNho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nhacNhos",
                columns: table => new
                {
                    MaNhacNho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCongViec = table.Column<int>(type: "int", nullable: false),
                    ThoiGianNhacNho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDungNhacNho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhacNhos", x => x.MaNhacNho);
                    table.ForeignKey(
                        name: "FK_nhacNhos_congViecs_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nhacNhos_MaCongViec",
                table: "nhacNhos",
                column: "MaCongViec");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nhacNhos");
        }
    }
}
