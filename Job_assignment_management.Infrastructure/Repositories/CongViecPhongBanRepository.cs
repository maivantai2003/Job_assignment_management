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
    public class CongViecPhongBanRepository : ICongViecPhongBanRepository
    {
        private readonly ApplicationDbContext _context;
        public CongViecPhongBanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CongViecPhongBan> CreateAsync(CongViecPhongBan congViecPhongBan)
        {
            await _context.congViecPhongBans.AddAsync(congViecPhongBan);
            await _context.SaveChangesAsync();
            return congViecPhongBan;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var congViecPhongBan = await _context.congViecPhongBans.FirstOrDefaultAsync(x => x.MaCongViecPhongBan == id);
            congViecPhongBan.TrangThai = false;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<CongViecPhongBan>> GetAllAsync(string? search, int page = 1)
        {
            var listCongViecPhongBan = _context.congViecPhongBans.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                //listChiTietQuyen = listChiTietQuyen.Where(x => x.ChucNang.TenChucNang.Contains(search) || x.NhomQuyen.TenQuyen.Contains(search));
            }
            var result = PageList<CongViecPhongBan>.Create(listCongViecPhongBan, 10, page);
            return result.ToList();
        }

        public async Task<CongViecPhongBan> GetByIdAsync(int id)
        {
            return await _context.congViecPhongBans.AsNoTracking().FirstOrDefaultAsync(x => x.MaCongViecPhongBan == id && x.TrangThai == true) ?? new CongViecPhongBan();
        }
        public async Task<List<CongViecPhongBan>> GetPhongBanPhanCongAsync(int id)
        {
            return await _context.congViecPhongBans.AsNoTracking().Where(x => x.MaPhongBan == id && x.TrangThai==true).ToListAsync();
        }
        public async Task<int> UpdateAsync(int id, CongViecPhongBan congViecPhongBan)
        {
            return await _context.congViecPhongBans.Where(x => x.MaCongViecPhongBan == id).
                ExecuteUpdateAsync(x => x.SetProperty(m => m.MaCongViec, congViecPhongBan.MaCongViec).
                SetProperty(m => m.MaPhongBan, congViecPhongBan.MaPhongBan));
        }
    }
}
