using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseTableFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_traoDoiThongTins_MaFile",
                table: "traoDoiThongTins",
                column: "MaFile");

            migrationBuilder.AddForeignKey(
                name: "FK_traoDoiThongTins_files_MaFile",
                table: "traoDoiThongTins",
                column: "MaFile",
                principalTable: "files",
                principalColumn: "MaFile",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_traoDoiThongTins_files_MaFile",
                table: "traoDoiThongTins");

            migrationBuilder.DropIndex(
                name: "IX_traoDoiThongTins_MaFile",
                table: "traoDoiThongTins");
        }
    }
}
