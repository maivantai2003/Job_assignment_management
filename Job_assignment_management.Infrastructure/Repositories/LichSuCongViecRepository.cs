using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Shared.Common;
using Microsoft.EntityFrameworkCore;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class LichSuCongViecRepository : ILichSuCongViecRepository
    {
        private readonly ApplicationDbContext _context;

        public LichSuCongViecRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LichSuCongViec> CreateAsync(LichSuCongViec tienDoCongViec)
        {
            await _context.lichSuCongViecs.AddAsync(tienDoCongViec);
            await _context.SaveChangesAsync();
            return tienDoCongViec;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var tienDoCongViec = await _context.lichSuCongViecs.FirstOrDefaultAsync(x => x.MaLichSuCongViec == id);
            if (tienDoCongViec == null) return 0;
            tienDoCongViec.TrangThai = false;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<LichSuCongViec>> GetAllAsync()
        //Chuyển dữ liệu thành dạng truy vấn LINQ để có thể áp dụng các bộ lọc, sắp xếp hoặc phân trang sau này.
        {
            var listTienDoCongViec = _context.lichSuCongViecs.AsNoTracking().AsQueryable();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    listTienDoCongViec = listTienDoCongViec.Where(x => x.NoiDung.Contains(search));
            //}
            //var result = PageList<LichSuCongViec>.Create(listTienDoCongViec, 10, page);
            return listTienDoCongViec.ToList();
        }

        public async Task<List<LichSuCongViec>> GetByIdAsync(int id)
        {
            return await _context.lichSuCongViecs.AsNoTracking().Where(x => x.MaCongViec== id).ToListAsync();
        }

        public async Task<int> UpdateAsync(int id, LichSuCongViec tienDoCongViec)
        {
            return await _context.lichSuCongViecs.Where(x => x.MaLichSuCongViec == id).ExecuteUpdateAsync(x => x
                .SetProperty(m => m.NgayCapNhat, tienDoCongViec.NgayCapNhat)
                .SetProperty(m => m.NoiDung, tienDoCongViec.NoiDung)
                .SetProperty(m => m.TrangThai, tienDoCongViec.TrangThai)
            );
        }
    }
}
