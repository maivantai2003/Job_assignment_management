using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Shared.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class PhanCongRepository : IPhanCongRepository
    {
        private readonly ApplicationDbContext _context;

        public PhanCongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PhanCong> CreateAsync(PhanCong phanCong)
        {
            await _context.phanCongs.AddAsync(phanCong);
            await _context.SaveChangesAsync();
            return phanCong;
        }

        public async Task DeleteAsync(int id)
        {
            var phanCong = await _context.phanCongs.FirstOrDefaultAsync(x => x.MaPhanCong == id);
            if (phanCong != null)
            {
                _context.phanCongs.Remove(phanCong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PhanCong>> GetAllAsync(string? search, int page = 1)
        {
            var listPhanCong = _context.phanCongs.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listPhanCong = listPhanCong.Where(x => x.NhanVien.TenNhanVien.Contains(search) ||
                x.MaNhanVien.ToString().Contains(search) || x.NhanVien.Email.Contains(search));
            }
            var result = PageList<PhanCong>.Create(listPhanCong, 10, page);
            return result.ToList();
        }

        public async Task<PhanCong> GetByIdAsync(int id)
        {
            return await _context.phanCongs.AsNoTracking().FirstOrDefaultAsync(x => x.MaPhanCong == id) ?? new PhanCong();
        }

        public async Task UpdateAsync(int id, PhanCong phanCong)
        {
            await _context.phanCongs
                .Where(x => x.MaPhanCong == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(m => m.VaiTro, phanCong.VaiTro)
                    .SetProperty(m => m.MaNhanVien, phanCong.MaNhanVien)
                    .SetProperty(m => m.MaCongViec, phanCong.MaCongViec));
        }
    }
}
