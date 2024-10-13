﻿// <auto-generated />
using System;
using Job_assignment_management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Job_assignment_management.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241008062351_UpdatePhanCong_NhanVien")]
    partial class UpdatePhanCong_NhanVien
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.ChiTietQuyen", b =>
                {
                    b.Property<int>("MaChiTietQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietQuyen"));

                    b.Property<string>("HanhDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaChucNang")
                        .HasColumnType("int");

                    b.Property<int>("MaNhomQuyen")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietQuyen");

                    b.HasIndex("MaChucNang");

                    b.HasIndex("MaNhomQuyen");

                    b.ToTable("chiTietQuyens");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.ChucNang", b =>
                {
                    b.Property<int>("MaChucNang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChucNang"));

                    b.Property<string>("TenChucNang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaChucNang");

                    b.ToTable("chucNangs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.ChuyenGiaoCongViec", b =>
                {
                    b.Property<int>("MaChuyenGiaoCongViec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChuyenGiaoCongViec"));

                    b.Property<string>("LyDoChuyenGiao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaNhanVienChuyenGiao")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVienThucHien")
                        .HasColumnType("int");

                    b.Property<int>("MaPhanCong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayChuyenGiao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NhanVienMaNhanVien")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaChuyenGiaoCongViec");

                    b.HasIndex("MaNhanVienChuyenGiao");

                    b.HasIndex("MaNhanVienThucHien");

                    b.HasIndex("MaPhanCong");

                    b.HasIndex("NhanVienMaNhanVien");

                    b.ToTable("chuyenGiaoCongViecs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.CongViec", b =>
                {
                    b.Property<int>("MaCongViec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCongViec"));

                    b.Property<int?>("MaCongViecCha")
                        .HasColumnType("int");

                    b.Property<int>("MaPhanDuAn")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MucDoHoanThanh")
                        .HasColumnType("float");

                    b.Property<string>("MucDoUuTien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCongViec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<bool>("TrangThaiCongViec")
                        .HasColumnType("bit");

                    b.HasKey("MaCongViec");

                    b.HasIndex("MaCongViecCha");

                    b.HasIndex("MaPhanDuAn");

                    b.ToTable("congViecs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.CongViecPhongBan", b =>
                {
                    b.Property<int>("MaCongViecPhongBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCongViecPhongBan"));

                    b.Property<int>("MaCongViec")
                        .HasColumnType("int");

                    b.Property<int>("MaPhongBan")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaCongViecPhongBan");

                    b.HasIndex("MaCongViec");

                    b.HasIndex("MaPhongBan");

                    b.ToTable("congViecPhongBans");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.DuAn", b =>
                {
                    b.Property<int>("MaDuAn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDuAn"));

                    b.Property<string>("TenDuAn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaDuAn");

                    b.ToTable("duAns");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.Files", b =>
                {
                    b.Property<int>("MaFile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaFile"));

                    b.Property<string>("DuongDan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaFile");

                    b.ToTable("files");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.MocThoiGian", b =>
                {
                    b.Property<int>("MaMocThoiGian")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaMocThoiGian"));

                    b.Property<int>("MaCongViec")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDenHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaMocThoiGian");

                    b.HasIndex("MaCongViec");

                    b.ToTable("mocThoiGians");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.NhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNhanVien"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaPhongBan")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChucVu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNhanVien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaNhanVien");

                    b.HasIndex("MaPhongBan");

                    b.ToTable("nhanViens");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.NhomQuyen", b =>
                {
                    b.Property<int>("MaQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaQuyen"));

                    b.Property<string>("TenQuyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaQuyen");

                    b.ToTable("nhomQuyens");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhanCong", b =>
                {
                    b.Property<int>("MaPhanCong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhanCong"));

                    b.Property<int>("MaCongViec")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<bool>("TrangThaiCongViec")
                        .HasColumnType("bit");

                    b.Property<string>("VaiTro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPhanCong");

                    b.HasIndex("MaCongViec");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("phanCongs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhanDuAn", b =>
                {
                    b.Property<int>("MaPhanDuAn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhanDuAn"));

                    b.Property<int>("MaDuAn")
                        .HasColumnType("int");

                    b.Property<string>("TenPhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaPhanDuAn");

                    b.HasIndex("MaDuAn");

                    b.ToTable("phanDuAns");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhongBan", b =>
                {
                    b.Property<int>("MaPhongBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhongBan"));

                    b.Property<int?>("MaTruongPhong")
                        .HasColumnType("int");

                    b.Property<string>("TenPhongBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaPhongBan");

                    b.HasIndex("MaTruongPhong");

                    b.ToTable("phongBans");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TaiKhoan", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<int>("MaNhomQuyen")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTaiKhoan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaNhanVien");

                    b.HasIndex("MaNhomQuyen");

                    b.ToTable("taiKhoans");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TaiKhoanRefreshToken", b =>
                {
                    b.Property<int>("MaTaiKhoanRefreshToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTaiKhoanRefreshToken"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInvalidades")
                        .HasColumnType("bit");

                    b.Property<int>("MaTaiKhoan")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTaiKhoanRefreshToken");

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("taiKhoanRefreshTokens");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.ThongBao", b =>
                {
                    b.Property<int>("MaThongBao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaThongBao"));

                    b.Property<int>("MaCongViec")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGui")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDungThongBao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaThongBao");

                    b.HasIndex("MaCongViec");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("thongBaos");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TienDoCongViec", b =>
                {
                    b.Property<int>("MaTienDoCongViec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTienDoCongViec"));

                    b.Property<int>("MaCongViec")
                        .HasColumnType("int");

                    b.Property<double>("MucDoHoanThanh")
                        .HasColumnType("float");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaTienDoCongViec");

                    b.HasIndex("MaCongViec");

                    b.ToTable("tienDoCongViecs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TraoDoiThongTin", b =>
                {
                    b.Property<int>("MaTraoDoiThongTin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTraoDoiThongTin"));

                    b.Property<int>("MaCongViec")
                        .HasColumnType("int");

                    b.Property<int?>("MaFile")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<string>("NoiDungTraoDoi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGianGui")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaTraoDoiThongTin");

                    b.HasIndex("MaCongViec");

                    b.HasIndex("MaFile");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("traoDoiThongTins");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.ChiTietQuyen", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.ChucNang", "ChucNang")
                        .WithMany("ChiTietQuyens")
                        .HasForeignKey("MaChucNang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.NhomQuyen", "NhomQuyen")
                        .WithMany("ChiTietQuyens")
                        .HasForeignKey("MaNhomQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucNang");

                    b.Navigation("NhomQuyen");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.ChuyenGiaoCongViec", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.NhanVien", "NhanVienChuyenGiao")
                        .WithMany()
                        .HasForeignKey("MaNhanVienChuyenGiao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.NhanVien", "NhanVienThucHien")
                        .WithMany()
                        .HasForeignKey("MaNhanVienThucHien")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.PhanCong", "PhanCong")
                        .WithMany("chuyenGiaoCongViecs")
                        .HasForeignKey("MaPhanCong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.NhanVien", null)
                        .WithMany("chuyenGiaoCongViecs")
                        .HasForeignKey("NhanVienMaNhanVien");

                    b.Navigation("NhanVienChuyenGiao");

                    b.Navigation("NhanVienThucHien");

                    b.Navigation("PhanCong");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.CongViec", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.CongViec", "CongViecCha")
                        .WithMany("listCongViecCon")
                        .HasForeignKey("MaCongViecCha")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Job_assignment_management.Domain.Entities.PhanDuAn", "PhanDuAn")
                        .WithMany("congViecs")
                        .HasForeignKey("MaPhanDuAn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViecCha");

                    b.Navigation("PhanDuAn");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.CongViecPhongBan", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.CongViec", "CongViec")
                        .WithMany("congViecPhongBans")
                        .HasForeignKey("MaCongViec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.PhongBan", "PhongBan")
                        .WithMany("CongViecPhongBans")
                        .HasForeignKey("MaPhongBan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViec");

                    b.Navigation("PhongBan");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.MocThoiGian", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.CongViec", "CongViec")
                        .WithMany("MocThoiGians")
                        .HasForeignKey("MaCongViec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViec");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.NhanVien", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.PhongBan", "PhongBan")
                        .WithMany("NhanVien")
                        .HasForeignKey("MaPhongBan")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PhongBan");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhanCong", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.CongViec", "CongViec")
                        .WithMany("PhanCongs")
                        .HasForeignKey("MaCongViec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.NhanVien", "NhanVien")
                        .WithMany("phanCongs")
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViec");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhanDuAn", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.DuAn", "DuAn")
                        .WithMany("PhanDuAn")
                        .HasForeignKey("MaDuAn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DuAn");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhongBan", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.NhanVien", "TruongPhong")
                        .WithMany()
                        .HasForeignKey("MaTruongPhong")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("TruongPhong");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TaiKhoan", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.NhanVien", "NhanVien")
                        .WithOne("TaiKhoan")
                        .HasForeignKey("Job_assignment_management.Domain.Entities.TaiKhoan", "MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.NhomQuyen", "NhomQuyen")
                        .WithMany("taiKhoans")
                        .HasForeignKey("MaNhomQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhanVien");

                    b.Navigation("NhomQuyen");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TaiKhoanRefreshToken", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.TaiKhoan", "TaiKhoan")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.ThongBao", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.CongViec", "CongViec")
                        .WithMany("ThongBaos")
                        .HasForeignKey("MaCongViec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.NhanVien", "NhanVien")
                        .WithMany("ThongBaos")
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViec");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TienDoCongViec", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.CongViec", "CongViec")
                        .WithMany("tienDoCongViecs")
                        .HasForeignKey("MaCongViec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViec");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TraoDoiThongTin", b =>
                {
                    b.HasOne("Job_assignment_management.Domain.Entities.CongViec", "CongViec")
                        .WithMany("TraoDoiThongTins")
                        .HasForeignKey("MaCongViec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_assignment_management.Domain.Entities.Files", "Files")
                        .WithMany("TraoDoiThongTins")
                        .HasForeignKey("MaFile");

                    b.HasOne("Job_assignment_management.Domain.Entities.NhanVien", "NhanVien")
                        .WithMany("TraoDoiThongTins")
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViec");

                    b.Navigation("Files");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.ChucNang", b =>
                {
                    b.Navigation("ChiTietQuyens");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.CongViec", b =>
                {
                    b.Navigation("MocThoiGians");

                    b.Navigation("PhanCongs");

                    b.Navigation("ThongBaos");

                    b.Navigation("TraoDoiThongTins");

                    b.Navigation("congViecPhongBans");

                    b.Navigation("listCongViecCon");

                    b.Navigation("tienDoCongViecs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.DuAn", b =>
                {
                    b.Navigation("PhanDuAn");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.Files", b =>
                {
                    b.Navigation("TraoDoiThongTins");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.NhanVien", b =>
                {
                    b.Navigation("TaiKhoan");

                    b.Navigation("ThongBaos");

                    b.Navigation("TraoDoiThongTins");

                    b.Navigation("chuyenGiaoCongViecs");

                    b.Navigation("phanCongs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.NhomQuyen", b =>
                {
                    b.Navigation("ChiTietQuyens");

                    b.Navigation("taiKhoans");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhanCong", b =>
                {
                    b.Navigation("chuyenGiaoCongViecs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhanDuAn", b =>
                {
                    b.Navigation("congViecs");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.PhongBan", b =>
                {
                    b.Navigation("CongViecPhongBans");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Job_assignment_management.Domain.Entities.TaiKhoan", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
