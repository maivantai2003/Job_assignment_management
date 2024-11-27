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

        public async Task<List<CongViec>> SearchTasks(string nhanVien = "All", string phongBan = "All", string mucDo = "All", string trangThai = "All", string tenCongViec = "")
        {
            var query = _context.congViecs
                .AsNoTracking()
                .Include(cv => cv.PhanCongs)
                    .ThenInclude(pc => pc.NhanVien)
                .Include(cv => cv.congViecPhongBans)
                    .ThenInclude(cvpb => cvpb.PhongBan)
                .Where(cv => cv.TrangThai == true);

            if (!string.Equals(nhanVien, "All", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(cv => cv.PhanCongs.Any(pc => pc.NhanVien.TenNhanVien.ToLower().Contains(nhanVien.ToLower())));
            }
            if (!string.Equals(mucDo, "All", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(cv => cv.MucDoUuTien != null && cv.MucDoUuTien==mucDo);
            }
            if (!string.Equals(phongBan, "All", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(cv => cv.congViecPhongBans.Any(cvpb => cvpb.PhongBan.TenPhongBan.ToLower().Contains(phongBan.ToLower())));
            }
            if (!string.Equals(trangThai, "All", StringComparison.OrdinalIgnoreCase))
            {
                query = trangThai switch
                {
                    "Hoàn thành" => query.Where(cv => cv.MucDoHoanThanh == 100),
                    "Chưa hoàn thành" => query.Where(cv => cv.MucDoHoanThanh > 0 && cv.MucDoHoanThanh < 100),
                    "Trì hoãn" => query.Where(cv => cv.ThoiGianKetThuc < DateTime.Now && cv.MucDoHoanThanh < 100),
                    _ => query
                };
            }
            if (!string.Equals(tenCongViec, "", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(cv => cv.TenCongViec != null && cv.TenCongViec.ToLower().Contains(tenCongViec.ToLower()));
            }
            return await query.ToListAsync();
        }

    }
}
