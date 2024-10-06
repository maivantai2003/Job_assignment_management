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
    public class TaiKhoanRepository:ITaiKhoanRepository
    {
        private readonly ApplicationDbContext _context;
        public TaiKhoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaiKhoan>> GetAllAsync(string? search, int page = 1)
        {
            var listTaiKhoan = _context.taiKhoans.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listTaiKhoan = listTaiKhoan.Where(x => x.TenTaiKhoan.Contains(search));
            }
            //var result = PageList<TaiKhoan>.Create(listTaiKhoan, 10, page);
            var result = listTaiKhoan.Take(page);
            return result.ToList();
        }
        public async Task<TaiKhoan> GetByIdAsync(int id)
        {
            return await _context.taiKhoans.AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaNhanVien == id) ?? new TaiKhoan();
        }

        public async Task<TaiKhoan> CreateAsync(TaiKhoan taiKhoan)
        {
            await _context.taiKhoans.AddAsync(taiKhoan);
            await _context.SaveChangesAsync();
            return taiKhoan;
        }
        public async Task<int> UpdateAsync(int id, TaiKhoan taiKhoan)
        {
            return await _context.taiKhoans.Where(x => x.MaNhanVien == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(t => t.TenTaiKhoan, taiKhoan.TenTaiKhoan)
                    .SetProperty(t => t.MatKhau, taiKhoan.MatKhau)
                    .SetProperty(t => t.MaNhomQuyen, taiKhoan.MaNhomQuyen));
        }

        public async Task<int> DeleteAsync(int id)
        {
            var taiKhoan = await _context.taiKhoans.FirstOrDefaultAsync(x => x.MaNhanVien == id);
            if (taiKhoan != null)
            {
                taiKhoan.TrangThai=false;
                await _context.SaveChangesAsync();
            }
            return id;
        }
    }
}
