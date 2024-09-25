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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PhongBan>().HasMany(p=>p.NhanVien).WithOne(p=>p.PhongBan).HasForeignKey(p=>p.MaPhongBan).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PhongBan>().HasOne(p=>p.TruongPhong).WithMany().HasForeignKey(p=>p.MaTruongPhong).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<CongViec>().HasKey(p => p.MaCongViec);
            modelBuilder.Entity<CongViec>().HasOne(p => p.CongViecCha).WithMany(p => p.listCongViecCon).HasForeignKey(p => p.MaCongViecCha).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
