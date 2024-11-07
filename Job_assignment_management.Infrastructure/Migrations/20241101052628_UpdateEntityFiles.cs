using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_traoDoiThongTins_files_MaFile",
                table: "traoDoiThongTins");

            migrationBuilder.DropIndex(
                name: "IX_traoDoiThongTins_MaFile",
                table: "traoDoiThongTins");

            migrationBuilder.DropColumn(
                name: "MaFile",
                table: "traoDoiThongTins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaFile",
                table: "traoDoiThongTins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_traoDoiThongTins_MaFile",
                table: "traoDoiThongTins",
                column: "MaFile");

            migrationBuilder.AddForeignKey(
                name: "FK_traoDoiThongTins_files_MaFile",
                table: "traoDoiThongTins",
                column: "MaFile",
                principalTable: "files",
                principalColumn: "MaFile");
        }
    }
}
