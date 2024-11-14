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
    public class ChuyenGiaoCongViecRepository : IChuyenGiaoCongViecRepository
    {
        private readonly ApplicationDbContext _context;

        public ChuyenGiaoCongViecRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChuyenGiaoCongViec> CreateAsync(ChuyenGiaoCongViec chuyenGiaoCongViec)
        {
            await _context.chuyenGiaoCongViecs.AddAsync(chuyenGiaoCongViec);
            await _context.SaveChangesAsync();
            return chuyenGiaoCongViec;
        }

        public async Task DeleteAsync(int id)
        {
            var chuyenGiaoCongViec = await _context.chuyenGiaoCongViecs.FirstOrDefaultAsync(x => x.MaChuyenGiaoCongViec == id);
            if (chuyenGiaoCongViec != null)
            {
                _context.chuyenGiaoCongViecs.Remove(chuyenGiaoCongViec);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ChuyenGiaoCongViec>> GetAllAsync(string? search, int page = 1)
        {
            var listChuyenGiaoCongViec = _context.chuyenGiaoCongViecs.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listChuyenGiaoCongViec = listChuyenGiaoCongViec.Where(x => x.LyDoChuyenGiao.Contains(search));
            }
            var result = PageList<ChuyenGiaoCongViec>.Create(listChuyenGiaoCongViec, 10, page);
            return result.ToList();
        }

        public async Task<ChuyenGiaoCongViec> GetByIdAsync(int id)
        {
            return await _context.chuyenGiaoCongViecs.AsNoTracking().FirstOrDefaultAsync(x => x.MaChuyenGiaoCongViec == id) ?? new ChuyenGiaoCongViec();
        }

        public async Task UpdateAsync(int id, ChuyenGiaoCongViec chuyenGiaoCongViec)
        {
            await _context.chuyenGiaoCongViecs
                .Where(x => x.MaChuyenGiaoCongViec == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(m => m.LyDoChuyenGiao, chuyenGiaoCongViec.LyDoChuyenGiao)
                    .SetProperty(m => m.MaNhanVienChuyenGiao, chuyenGiaoCongViec.MaNhanVienChuyenGiao)
                    .SetProperty(m => m.MaNhanVienThucHien, chuyenGiaoCongViec.MaNhanVienThucHien)
                    .SetProperty(m => m.MaPhanCong, chuyenGiaoCongViec.MaPhanCong)
                    .SetProperty(m=>m.VaiTro,chuyenGiaoCongViec.VaiTro)
                    .SetProperty(m=>m.TenCongViec,chuyenGiaoCongViec.TenCongViec)
                    .SetProperty(m => m.NgayChuyenGiao, chuyenGiaoCongViec.NgayChuyenGiao));
        }
    }
}
