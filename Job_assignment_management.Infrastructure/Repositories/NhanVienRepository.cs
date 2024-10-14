using Azure;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Shared.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class NhanVienRepository:INhanVienRepository
    {
        private readonly ApplicationDbContext _context;

        public NhanVienRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NhanVien> CreateAsync(NhanVien nhanVien)
        {
            await _context.nhanViens.AddAsync(nhanVien);
            await _context.SaveChangesAsync();
            return nhanVien;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var nhanVien = await _context.nhanViens.FirstOrDefaultAsync(x => x.MaNhanVien == id);
            if (nhanVien != null)
            {
                nhanVien.TrangThai = false;
                await _context.SaveChangesAsync();
            }
            return id;
        }

        public async Task<List<NhanVien>> GetAllAsync(string? search, int page = 1)
        {
            var listNhanVien = _context.nhanViens.Include(x=>x.chuyenGiaoCongViecs).Include(x=>x.TraoDoiThongTins).Include(x => x.ThongBaos).AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listNhanVien = listNhanVien.Where(x => x.TenNhanVien.Contains(search));
            }
            //var result = PageList<NhanVien>.Create(listNhanVien, 10, page);
            var result=listNhanVien.Take(page);
            return result.ToList();
        }

        public async Task<NhanVien> GetByIdAsync(int id)
        {
            return await _context.nhanViens.AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaNhanVien == id) ?? new NhanVien();
        }

        public async Task<int> UpdateAsync(int id, NhanVien nhanVien)
        {
            return await _context.nhanViens.Where(x => x.MaNhanVien == id)
               .ExecuteUpdateAsync(x => x
                   .SetProperty(t => t.TenNhanVien, nhanVien.TenNhanVien)
                   .SetProperty(t => t.TenChucVu, nhanVien.TenChucVu)
                   .SetProperty(t => t.Email, nhanVien.Email)
                   .SetProperty(t => t.SoDienThoai, nhanVien.SoDienThoai)
                   .SetProperty(t => t.MaPhongBan, nhanVien.MaPhongBan));
        }
    }
}
