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
    public class PhongBanRepository : IPhongBanRepository
    {
        private readonly ApplicationDbContext _context;

        public PhongBanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhongBan>> GetAllAsync(string? search, int page = 1)
        {
            var listPhongBan = _context.phongBans.Include(x=>x.NhanVien).Include(x=>x.TruongPhong).AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listPhongBan = listPhongBan.Where(x => x.TenPhongBan.Contains(search));
            }
            //var result = PageList<PhongBan>.Create(listPhongBan, 10, page);
            var result = listPhongBan.Take(page);
            return result.ToList();
        }
        public async Task<PhongBan> GetByIdAsync(int id)
        {
            return await _context.phongBans.AsNoTracking().Include(x => x.NhanVien).Include(x => x.TruongPhong)
                .FirstOrDefaultAsync(x => x.MaPhongBan == id && x.TrangThai == true) ?? new PhongBan();
        }


        public async Task<PhongBan> CreateAsync(PhongBan phongBan)
        {
            await _context.phongBans.AddAsync(phongBan);
            await _context.SaveChangesAsync();
            return phongBan;
        }
        public async Task<int> UpdateAsync(int id,PhongBan phongBan)
        {
            return await _context.phongBans.Where(x => x.MaPhongBan == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(t => t.MaTruongPhong, phongBan.MaTruongPhong)
                    .SetProperty(t => t.TenPhongBan, phongBan.TenPhongBan));
        }

        public async Task<int> DeleteAsync(int id)
        {
            var phongBan = await _context.phongBans.FirstOrDefaultAsync(x => x.MaPhongBan == id);
            if (phongBan != null)
            {
                _context.phongBans.Remove(phongBan);
                await _context.SaveChangesAsync();
            }
            return id;
        }

        public async Task<List<PhongBan>> GetTruongPhongByIdAsync(int id)
        {
            return await _context.phongBans.AsNoTracking().Where(x => x.MaTruongPhong == id && x.TrangThai == true).Include(x => x.NhanVien).ToListAsync();
        }
    }
}
