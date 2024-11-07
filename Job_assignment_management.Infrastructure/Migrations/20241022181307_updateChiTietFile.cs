using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateChiTietFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chiTietFiles",
                columns: table => new
                {
                    MaChiTietFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaFile = table.Column<int>(type: "int", nullable: false),
                    MaPhanCong = table.Column<int>(type: "int", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietFiles", x => x.MaChiTietFile);
                    table.ForeignKey(
                        name: "FK_chiTietFiles_files_MaFile",
                        column: x => x.MaFile,
                        principalTable: "files",
                        principalColumn: "MaFile",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietFiles_phanCongs_MaPhanCong",
                        column: x => x.MaPhanCong,
                        principalTable: "phanCongs",
                        principalColumn: "MaPhanCong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietFiles_MaFile",
                table: "chiTietFiles",
                column: "MaFile");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietFiles_MaPhanCong",
                table: "chiTietFiles",
                column: "MaPhanCong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietFiles");
        }
    }
}
