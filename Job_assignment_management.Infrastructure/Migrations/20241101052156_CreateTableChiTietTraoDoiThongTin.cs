using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableChiTietTraoDoiThongTin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chiTietTraoDoiThongTins",
                columns: table => new
                {
                    MaChiTietTraoDoiThongTin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTraoDoi = table.Column<int>(type: "int", nullable: false),
                    MaFile = table.Column<int>(type: "int", nullable: false),
                    TrangThaiTraoDoi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietTraoDoiThongTins", x => x.MaChiTietTraoDoiThongTin);
                    table.ForeignKey(
                        name: "FK_chiTietTraoDoiThongTins_files_MaFile",
                        column: x => x.MaFile,
                        principalTable: "files",
                        principalColumn: "MaFile",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietTraoDoiThongTins_traoDoiThongTins_MaTraoDoi",
                        column: x => x.MaTraoDoi,
                        principalTable: "traoDoiThongTins",
                        principalColumn: "MaTraoDoiThongTin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietTraoDoiThongTins_MaFile",
                table: "chiTietTraoDoiThongTins",
                column: "MaFile");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietTraoDoiThongTins_MaTraoDoi",
                table: "chiTietTraoDoiThongTins",
                column: "MaTraoDoi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietTraoDoiThongTins");
        }
    }
}
