using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class ThongKeRepository : IThongKeRepository
    {
        private readonly ApplicationDbContext _context;
        public ThongKeRepository(ApplicationDbContext context) { _context = context; }
        public async Task<ThongKeNhanVien> NhanVien(int maNhanVien, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string? trangThai)
        {
            //var nhanVien=await _context.nhanViens.AsNoTracking().FirstOrDefaultAsync(x=>x.MaNhanVien==maNhanVien);
            //var congViec = await _context.congViecs.AsNoTracking().Include(x => x.PhanCongs).Where(x => x.ThoiGianBatDau >= thoiGianBatDau && x.ThoiGianKetThuc <= thoiGianKetThuc).ToListAsync();
            throw new NotImplementedException();

        }
        public Task<ThongKePhongBan> PhongBan(int maPhongBan, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string? trangThai)
        {
            throw new NotImplementedException();
        }
        public Task<List<ThongKeNhanVien>> ThongKeNhanVien(DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string? trangThai)
        {
            throw new NotImplementedException();
        }

        public Task<List<ThongKePhongBan>> ThongKePhongBan(DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string? trangThai)
        {
            throw new NotImplementedException();
        }
    }
}
