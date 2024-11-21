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
    public class CongViecRepository:ICongViecRepository
    {
        private readonly ApplicationDbContext _context;

        public CongViecRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CongViec>> GetAllAsync(string? search, int page = 1)
        {
            var listCongViec = _context.congViecs.AsNoTracking().Include(x=>x.listCongViecCon).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listCongViec = listCongViec.Where(x => x.TenCongViec.Contains(search));
            }
            var result = PageList<CongViec>.Create(listCongViec, 10, page);
            return result.ToList();
        }
        public async Task<CongViec> GetByIdAsync(int id)
        {
            //return await _context.congViecs.AsNoTracking().Include(x=>x.PhanCongs).ThenInclude(x=>x.NhanVien)
            //    .FirstOrDefaultAsync(x => x.MaCongViec == id && x.TrangThai == true) ?? new CongViec();
            var congViec = await _context.congViecs.FindAsync(id);

            if (congViec == null || !congViec.TrangThai)
            {
                return new CongViec();
            }
            await _context.Entry(congViec)
                .Collection(c => c.PhanCongs)
                .Query()
                .Include(pc => pc.NhanVien)
                .LoadAsync();

            return congViec;
        }

        public async Task<CongViec> CreateAsync(CongViec congViec)
        {
            await _context.congViecs.AddAsync(congViec);
            await _context.SaveChangesAsync();
            return congViec;
        }
        public async Task<int> UpdateAsync(int id, CongViec congViec)
        {
            return await _context.congViecs.Where(x => x.MaCongViec == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(t => t.TenCongViec, congViec.TenCongViec)
                    .SetProperty(t => t.MoTa, congViec.MoTa)
                    .SetProperty(t => t.MucDoUuTien, congViec.MucDoUuTien)
                    .SetProperty(t => t.ThoiGianBatDau, congViec.ThoiGianBatDau)
                    .SetProperty(t => t.ThoiGianKetThuc, congViec.ThoiGianKetThuc));
        }
        public async Task<int> DeleteAsync(int id)
        {
            var congViec = await _context.congViecs.FirstOrDefaultAsync(x => x.MaCongViec == id);
            if (congViec != null)
            {
                congViec.TrangThai = false;
                await _context.SaveChangesAsync();
            }
            return id;
        }

        public async Task<int> UpdateComplete(int id,bool trangThai, double mucDo)
        {
            var congViec=await _context.congViecs.FirstOrDefaultAsync(x=>x.MaCongViec==id);
            congViec.TrangThaiCongViec = trangThai;
            congViec.MucDoHoanThanh=mucDo;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<int> UpdateTaskDay(int id, DateTime ngayKetThuc)
        {
            return await _context.congViecs.Where(x => x.MaCongViec == id)
              .ExecuteUpdateAsync(x => x
                  .SetProperty(t => t.ThoiGianKetThuc, ngayKetThuc));
        }

        public Task<bool> UpdateTaskAsync(CongViec congViec)
        {
            throw new NotImplementedException();
        }
    }
}
