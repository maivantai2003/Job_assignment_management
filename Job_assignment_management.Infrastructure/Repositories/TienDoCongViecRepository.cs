using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Shared.Common;
using Microsoft.EntityFrameworkCore;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class TienDoCongViecRepository : ITienDoCongViecRepository
    {
        private readonly ApplicationDbContext _context;

        public TienDoCongViecRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TienDoCongViec> CreateAsync(TienDoCongViec tienDoCongViec)
        {
            await _context.tienDoCongViecs.AddAsync(tienDoCongViec);
            await _context.SaveChangesAsync();
            return tienDoCongViec;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var tienDoCongViec = await _context.tienDoCongViecs.FirstOrDefaultAsync(x => x.MaTienDoCongViec == id);
            if (tienDoCongViec == null) return 0;
            tienDoCongViec.TrangThai = false;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<TienDoCongViec>> GetAllAsync(string? search, int page = 1)
        {
            var listTienDoCongViec = _context.tienDoCongViecs.Include(x => x.CongViec).AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listTienDoCongViec = listTienDoCongViec.Where(x => x.NoiDung.Contains(search));
            }
            var result = PageList<TienDoCongViec>.Create(listTienDoCongViec, 10, page);
            return result.ToList();
        }

        public async Task<TienDoCongViec> GetByIdAsync(int id)
        {
            return await _context.tienDoCongViecs.AsNoTracking().FirstOrDefaultAsync(x => x.MaTienDoCongViec == id) ?? new TienDoCongViec();
        }

        public async Task<int> UpdateAsync(int id, TienDoCongViec tienDoCongViec)
        {
            return await _context.tienDoCongViecs.Where(x => x.MaTienDoCongViec == id).ExecuteUpdateAsync(x => x
                .SetProperty(m => m.NgayCapNhat, tienDoCongViec.NgayCapNhat)
                .SetProperty(m => m.MucDoHoanThanh, tienDoCongViec.MucDoHoanThanh)
                .SetProperty(m => m.NoiDung, tienDoCongViec.NoiDung)
                .SetProperty(m => m.TrangThai, tienDoCongViec.TrangThai)
            );
        }
    }
}
