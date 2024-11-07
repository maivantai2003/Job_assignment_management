using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lichSuCongViecs",
                columns: table => new
                {
                    MaLichSuCongViec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCongViec = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lichSuCongViecs", x => x.MaLichSuCongViec);
                    table.ForeignKey(
                        name: "FK_lichSuCongViecs_congViecs_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lichSuCongViecs_MaCongViec",
                table: "lichSuCongViecs",
                column: "MaCongViec");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lichSuCongViecs");
        }
    }
}
