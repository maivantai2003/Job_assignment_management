using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chucNangs",
                columns: table => new
                {
                    MaChucNang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucNang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucNangs", x => x.MaChucNang);
                });

            migrationBuilder.CreateTable(
                name: "duAns",
                columns: table => new
                {
                    MaDuAn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDuAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duAns", x => x.MaDuAn);
                });

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    MaFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuongDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.MaFile);
                });

            migrationBuilder.CreateTable(
                name: "nhomQuyens",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhomQuyens", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "phanDuAns",
                columns: table => new
                {
                    MaPhanDuAn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDuAn = table.Column<int>(type: "int", nullable: false),
                    TenPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phanDuAns", x => x.MaPhanDuAn);
                    table.ForeignKey(
                        name: "FK_phanDuAns_duAns_MaDuAn",
                        column: x => x.MaDuAn,
                        principalTable: "duAns",
                        principalColumn: "MaDuAn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietQuyens",
                columns: table => new
                {
                    MaChiTietQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChucNang = table.Column<int>(type: "int", nullable: false),
                    MaNhomQuyen = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietQuyens", x => x.MaChiTietQuyen);
                    table.ForeignKey(
                        name: "FK_chiTietQuyens_chucNangs_MaChucNang",
                        column: x => x.MaChucNang,
                        principalTable: "chucNangs",
                        principalColumn: "MaChucNang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietQuyens_nhomQuyens_MaNhomQuyen",
                        column: x => x.MaNhomQuyen,
                        principalTable: "nhomQuyens",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "congViecs",
                columns: table => new
                {
                    MaCongViec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhanDuAn = table.Column<int>(type: "int", nullable: false),
                    MaCongViecCha = table.Column<int>(type: "int", nullable: true),
                    TenCongViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDoUuTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiCongViec = table.Column<bool>(type: "bit", nullable: false),
                    MucDoHoanThanh = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_congViecs", x => x.MaCongViec);
                    table.ForeignKey(
                        name: "FK_congViecs_congViecs_MaCongViecCha",
                        column: x => x.MaCongViecCha,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_congViecs_phanDuAns_MaPhanDuAn",
                        column: x => x.MaPhanDuAn,
                        principalTable: "phanDuAns",
                        principalColumn: "MaPhanDuAn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MocThoiGians",
                columns: table => new
                {
                    MaMocThoiGian = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCongViec = table.Column<int>(type: "int", nullable: false),
                    NgayDenHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MocThoiGians", x => x.MaMocThoiGian);
                    table.ForeignKey(
                        name: "FK_MocThoiGians_congViecs_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tienDoCongViecs",
                columns: table => new
                {
                    MaTienDoCongViec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCongViec = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MucDoHoanThanh = table.Column<double>(type: "float", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tienDoCongViecs", x => x.MaTienDoCongViec);
                    table.ForeignKey(
                        name: "FK_tienDoCongViecs_congViecs_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chuyenGiaoCongViecs",
                columns: table => new
                {
                    MaChuyenGiaoCongViec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhanCong = table.Column<int>(type: "int", nullable: false),
                    MaNhanVienThucHien = table.Column<int>(type: "int", nullable: false),
                    MaNhanVienChuyenGiao = table.Column<int>(type: "int", nullable: false),
                    LyDoChuyenGiao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayChuyenGiao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NhanVienMaNhanVien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuyenGiaoCongViecs", x => x.MaChuyenGiaoCongViec);
                });

            migrationBuilder.CreateTable(
                name: "congViecPhongBans",
                columns: table => new
                {
                    MaCongViecPhongBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhongBan = table.Column<int>(type: "int", nullable: false),
                    MaCongViec = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_congViecPhongBans", x => x.MaCongViecPhongBan);
                    table.ForeignKey(
                        name: "FK_congViecPhongBans_congViecs_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhongBan = table.Column<int>(type: "int", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "phanCongs",
                columns: table => new
                {
                    MaPhanCong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    MaCongViec = table.Column<int>(type: "int", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiCongViec = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phanCongs", x => x.MaPhanCong);
                    table.ForeignKey(
                        name: "FK_phanCongs_congViecs_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phanCongs_nhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "nhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phongBans",
                columns: table => new
                {
                    MaPhongBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTruongPhong = table.Column<int>(type: "int", nullable: true),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phongBans", x => x.MaPhongBan);
                    table.ForeignKey(
                        name: "FK_phongBans_nhanViens_MaTruongPhong",
                        column: x => x.MaTruongPhong,
                        principalTable: "nhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "taiKhoans",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    MaNhomQuyen = table.Column<int>(type: "int", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoans", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_taiKhoans_nhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "nhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taiKhoans_nhomQuyens_MaNhomQuyen",
                        column: x => x.MaNhomQuyen,
                        principalTable: "nhomQuyens",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thongBaos",
                columns: table => new
                {
                    MaThongBao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCongViec = table.Column<int>(type: "int", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongBaos", x => x.MaThongBao);
                    table.ForeignKey(
                        name: "FK_thongBaos_congViecs_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_thongBaos_nhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "nhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "traoDoiThongTins",
                columns: table => new
                {
                    MaTraoDoiThongTin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCongViec = table.Column<int>(type: "int", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    MaFile = table.Column<int>(type: "int", nullable: false),
                    ThoiGianGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDungTraoDoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traoDoiThongTins", x => x.MaTraoDoiThongTin);
                    table.ForeignKey(
                        name: "FK_traoDoiThongTins_congViecs_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "congViecs",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_traoDoiThongTins_nhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "nhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietQuyens_MaChucNang",
                table: "chiTietQuyens",
                column: "MaChucNang");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietQuyens_MaNhomQuyen",
                table: "chiTietQuyens",
                column: "MaNhomQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_chuyenGiaoCongViecs_MaNhanVienChuyenGiao",
                table: "chuyenGiaoCongViecs",
                column: "MaNhanVienChuyenGiao");

            migrationBuilder.CreateIndex(
                name: "IX_chuyenGiaoCongViecs_MaNhanVienThucHien",
                table: "chuyenGiaoCongViecs",
                column: "MaNhanVienThucHien");

            migrationBuilder.CreateIndex(
                name: "IX_chuyenGiaoCongViecs_MaPhanCong",
                table: "chuyenGiaoCongViecs",
                column: "MaPhanCong");

            migrationBuilder.CreateIndex(
                name: "IX_chuyenGiaoCongViecs_NhanVienMaNhanVien",
                table: "chuyenGiaoCongViecs",
                column: "NhanVienMaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_congViecPhongBans_MaCongViec",
                table: "congViecPhongBans",
                column: "MaCongViec");

            migrationBuilder.CreateIndex(
                name: "IX_congViecPhongBans_MaPhongBan",
                table: "congViecPhongBans",
                column: "MaPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_congViecs_MaCongViecCha",
                table: "congViecs",
                column: "MaCongViecCha");

            migrationBuilder.CreateIndex(
                name: "IX_congViecs_MaPhanDuAn",
                table: "congViecs",
                column: "MaPhanDuAn");

            migrationBuilder.CreateIndex(
                name: "IX_MocThoiGians_MaCongViec",
                table: "MocThoiGians",
                column: "MaCongViec");

            migrationBuilder.CreateIndex(
                name: "IX_nhanViens_MaPhongBan",
                table: "nhanViens",
                column: "MaPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_phanCongs_MaCongViec",
                table: "phanCongs",
                column: "MaCongViec");

            migrationBuilder.CreateIndex(
                name: "IX_phanCongs_MaNhanVien",
                table: "phanCongs",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_phanDuAns_MaDuAn",
                table: "phanDuAns",
                column: "MaDuAn");

            migrationBuilder.CreateIndex(
                name: "IX_phongBans_MaTruongPhong",
                table: "phongBans",
                column: "MaTruongPhong");

            migrationBuilder.CreateIndex(
                name: "IX_taiKhoans_MaNhomQuyen",
                table: "taiKhoans",
                column: "MaNhomQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_thongBaos_MaCongViec",
                table: "thongBaos",
                column: "MaCongViec");

            migrationBuilder.CreateIndex(
                name: "IX_thongBaos_MaNhanVien",
                table: "thongBaos",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_tienDoCongViecs_MaCongViec",
                table: "tienDoCongViecs",
                column: "MaCongViec");

            migrationBuilder.CreateIndex(
                name: "IX_traoDoiThongTins_MaCongViec",
                table: "traoDoiThongTins",
                column: "MaCongViec");

            migrationBuilder.CreateIndex(
                name: "IX_traoDoiThongTins_MaNhanVien",
                table: "traoDoiThongTins",
                column: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_chuyenGiaoCongViecs_nhanViens_MaNhanVienChuyenGiao",
                table: "chuyenGiaoCongViecs",
                column: "MaNhanVienChuyenGiao",
                principalTable: "nhanViens",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chuyenGiaoCongViecs_nhanViens_MaNhanVienThucHien",
                table: "chuyenGiaoCongViecs",
                column: "MaNhanVienThucHien",
                principalTable: "nhanViens",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chuyenGiaoCongViecs_nhanViens_NhanVienMaNhanVien",
                table: "chuyenGiaoCongViecs",
                column: "NhanVienMaNhanVien",
                principalTable: "nhanViens",
                principalColumn: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_chuyenGiaoCongViecs_phanCongs_MaPhanCong",
                table: "chuyenGiaoCongViecs",
                column: "MaPhanCong",
                principalTable: "phanCongs",
                principalColumn: "MaPhanCong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_congViecPhongBans_phongBans_MaPhongBan",
                table: "congViecPhongBans",
                column: "MaPhongBan",
                principalTable: "phongBans",
                principalColumn: "MaPhongBan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nhanViens_phongBans_MaPhongBan",
                table: "nhanViens",
                column: "MaPhongBan",
                principalTable: "phongBans",
                principalColumn: "MaPhongBan",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phongBans_nhanViens_MaTruongPhong",
                table: "phongBans");

            migrationBuilder.DropTable(
                name: "chiTietQuyens");

            migrationBuilder.DropTable(
                name: "chuyenGiaoCongViecs");

            migrationBuilder.DropTable(
                name: "congViecPhongBans");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "MocThoiGians");

            migrationBuilder.DropTable(
                name: "taiKhoans");

            migrationBuilder.DropTable(
                name: "thongBaos");

            migrationBuilder.DropTable(
                name: "tienDoCongViecs");

            migrationBuilder.DropTable(
                name: "traoDoiThongTins");

            migrationBuilder.DropTable(
                name: "chucNangs");

            migrationBuilder.DropTable(
                name: "phanCongs");

            migrationBuilder.DropTable(
                name: "nhomQuyens");

            migrationBuilder.DropTable(
                name: "congViecs");

            migrationBuilder.DropTable(
                name: "phanDuAns");

            migrationBuilder.DropTable(
                name: "duAns");

            migrationBuilder.DropTable(
                name: "nhanViens");

            migrationBuilder.DropTable(
                name: "phongBans");
        }
    }
}
