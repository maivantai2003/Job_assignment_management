using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MocThoiGians_congViecs_MaCongViec",
                table: "MocThoiGians");

            migrationBuilder.DropForeignKey(
                name: "FK_traoDoiThongTins_files_MaFile",
                table: "traoDoiThongTins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MocThoiGians",
                table: "MocThoiGians");

            migrationBuilder.RenameTable(
                name: "MocThoiGians",
                newName: "mocThoiGians");

            migrationBuilder.RenameIndex(
                name: "IX_MocThoiGians_MaCongViec",
                table: "mocThoiGians",
                newName: "IX_mocThoiGians_MaCongViec");

            migrationBuilder.AlterColumn<int>(
                name: "MaFile",
                table: "traoDoiThongTins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianKetThuc",
                table: "congViecs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mocThoiGians",
                table: "mocThoiGians",
                column: "MaMocThoiGian");

            migrationBuilder.AddForeignKey(
                name: "FK_mocThoiGians_congViecs_MaCongViec",
                table: "mocThoiGians",
                column: "MaCongViec",
                principalTable: "congViecs",
                principalColumn: "MaCongViec",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_traoDoiThongTins_files_MaFile",
                table: "traoDoiThongTins",
                column: "MaFile",
                principalTable: "files",
                principalColumn: "MaFile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mocThoiGians_congViecs_MaCongViec",
                table: "mocThoiGians");

            migrationBuilder.DropForeignKey(
                name: "FK_traoDoiThongTins_files_MaFile",
                table: "traoDoiThongTins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mocThoiGians",
                table: "mocThoiGians");

            migrationBuilder.RenameTable(
                name: "mocThoiGians",
                newName: "MocThoiGians");

            migrationBuilder.RenameIndex(
                name: "IX_mocThoiGians_MaCongViec",
                table: "MocThoiGians",
                newName: "IX_MocThoiGians_MaCongViec");

            migrationBuilder.AlterColumn<int>(
                name: "MaFile",
                table: "traoDoiThongTins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianKetThuc",
                table: "congViecs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MocThoiGians",
                table: "MocThoiGians",
                column: "MaMocThoiGian");

            migrationBuilder.AddForeignKey(
                name: "FK_MocThoiGians_congViecs_MaCongViec",
                table: "MocThoiGians",
                column: "MaCongViec",
                principalTable: "congViecs",
                principalColumn: "MaCongViec",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_traoDoiThongTins_files_MaFile",
                table: "traoDoiThongTins",
                column: "MaFile",
                principalTable: "files",
                principalColumn: "MaFile",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
