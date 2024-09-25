using Job_assignment_management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<NhomQuyen> nhomQuyens { get; set; }    
        public DbSet<ChucNang> chucNangs { get; set; } 
        public DbSet<ChiTietQuyen> chiTietQuyens { get; set; }
        public DbSet<TaiKhoan> taiKhoans { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }  
        public DbSet<CongViec> congViecs { get; set; }  
        public DbSet<ChuyenGiaoCongViec> chuyenGiaoCongViecs { get; set; }  
        public DbSet<ThongBao> thongBaos { get; set; }  
        public DbSet<MocThoiGian> MocThoiGians { get; set; }    
        public DbSet<TienDoCongViec> tienDoCongViecs { get; set; }
        public DbSet<DuAn> duAns { get; set; }
        public DbSet<PhanDuAn> phanDuAns { get; set; }  
        public DbSet<PhanCong> phanCongs { get; set; }  
        public DbSet<CongViecPhongBan> congViecPhongBans { get; set; }
        public DbSet<TraoDoiThongTin> traoDoiThongTins { get; set; }    
        public DbSet<Files> files { get; set; }  
        public DbSet<PhongBan> phongBans { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PhongBan>().HasMany(p=>p.NhanVien).WithOne(p=>p.PhongBan).HasForeignKey(p=>p.MaPhongBan).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PhongBan>().HasOne(p=>p.TruongPhong).WithMany().HasForeignKey(p=>p.MaTruongPhong).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<CongViec>().HasKey(p => p.MaCongViec);
            modelBuilder.Entity<CongViec>().HasOne(p => p.CongViecCha).WithMany(p => p.listCongViecCon).HasForeignKey(p => p.MaCongViecCha).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NhanVien>()
               .HasOne(nv => nv.TaiKhoan)
               .WithOne(tk => tk.NhanVien)
               .HasForeignKey<TaiKhoan>(tk => tk.MaNhanVien)
               .OnDelete(DeleteBehavior.Cascade);
                    modelBuilder.Entity<ChuyenGiaoCongViec>()
                        .HasOne(cg => cg.NhanVienChuyenGiao)
                        .WithMany()
                        .HasForeignKey(cg => cg.MaNhanVienChuyenGiao)
                        .OnDelete(DeleteBehavior.Restrict);

                    modelBuilder.Entity<ChuyenGiaoCongViec>()
                        .HasOne(cg => cg.NhanVienThucHien)
                        .WithMany()
                        .HasForeignKey(cg => cg.MaNhanVienThucHien)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
