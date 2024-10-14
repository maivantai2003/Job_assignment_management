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
    public class ChiTietQuyenRepository : IChiTietQuyenReposity
    {
        private readonly ApplicationDbContext _context;
        public ChiTietQuyenRepository(ApplicationDbContext context) { 
            _context = context; 
        }

        public Task<bool> CheckQuyen(int MaQuyen, int MaChucNang, string HanhDong)
        {
            throw new NotImplementedException();
        }

        public async Task<ChiTietQuyen> CreateAsync(ChiTietQuyen chiTietQuyen)
        {
            await _context.chiTietQuyens.AddAsync(chiTietQuyen);
            await _context.SaveChangesAsync();
            return chiTietQuyen;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var chiTietQuyen = await _context.chiTietQuyens.FirstOrDefaultAsync(x => x.MaChiTietQuyen == id);
            chiTietQuyen.HanhDong = "X";
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<ChiTietQuyen>> GetAllAsync(string? search, int page = 1)
        {
            var listChiTietQuyen = _context.chiTietQuyens.Include(x=>x.ChucNang).Include(x=>x.NhomQuyen).AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listChiTietQuyen= listChiTietQuyen.Where(x => x.ChucNang.TenChucNang.Contains(search) || x.NhomQuyen.TenQuyen.Contains(search));
            }
            var result = PageList<ChiTietQuyen>.Create(listChiTietQuyen, 10, page);
            return result.ToList();
        }

        public async Task<ChiTietQuyen> GetByIdAsync(int id)
        {
            return await _context.chiTietQuyens.AsNoTracking().FirstOrDefaultAsync(x => x.MaChiTietQuyen == id) ?? new ChiTietQuyen();
        }

        public async Task<int> UpdateAsync(int id, ChiTietQuyen chiTietQuyen)
        {
            return await _context.chiTietQuyens.Where(x => x.MaChiTietQuyen == id).ExecuteUpdateAsync(x => x.SetProperty(m => m.MaNhomQuyen, chiTietQuyen.MaNhomQuyen)
            .SetProperty(m=>m.MaChucNang,chiTietQuyen.MaChucNang).SetProperty(m=>m.HanhDong, chiTietQuyen.HanhDong));
        }
    }
}
