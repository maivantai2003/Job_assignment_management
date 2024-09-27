using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Shared.Common;
using Microsoft.EntityFrameworkCore;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class MocThoiGianRepository : IMocThoiGianRepository
    {
        private readonly ApplicationDbContext _context;

        public MocThoiGianRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MocThoiGian> CreateAsync(MocThoiGian mocThoiGian)
        {
            await _context.mocThoiGians.AddAsync(mocThoiGian);
            await _context.SaveChangesAsync();
            return mocThoiGian;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var mocThoiGian = await _context.mocThoiGians.FirstOrDefaultAsync(x => x.MaMocThoiGian == id);
            if (mocThoiGian == null) return 0;
            mocThoiGian.TrangThai = false;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<MocThoiGian>> GetAllAsync(string? search, int page = 1)
        {
            var listMocThoiGian = _context.mocThoiGians.Include(x => x.CongViec).AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listMocThoiGian = listMocThoiGian.Where(x => x.NoiDung.Contains(search));
            }
            var result = PageList<MocThoiGian>.Create(listMocThoiGian, 10, page);
            return result.ToList();
        }

        public async Task<MocThoiGian> GetByIdAsync(int id)
        {
            return await _context.mocThoiGians.AsNoTracking().FirstOrDefaultAsync(x => x.MaMocThoiGian == id) ?? new MocThoiGian();
        }

        public async Task<int> UpdateAsync(int id, MocThoiGian mocThoiGian)
        {
            return await _context.mocThoiGians.Where(x => x.MaMocThoiGian == id).ExecuteUpdateAsync(x => x
                .SetProperty(m => m.NgayDenHan, mocThoiGian.NgayDenHan)
                .SetProperty(m => m.NoiDung, mocThoiGian.NoiDung)
                .SetProperty(m => m.TrangThai, mocThoiGian.TrangThai)
            );
        }
    }
}
