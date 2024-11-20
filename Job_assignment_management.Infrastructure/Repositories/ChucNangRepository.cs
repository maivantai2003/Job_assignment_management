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
    public class ChucNangRepository : IChucNangRepository
    {
        private readonly ApplicationDbContext _context;
        public ChucNangRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ChucNang> CreateAsync(ChucNang chucNang)
        {
            await _context.chucNangs.AddAsync(chucNang);
            await _context.SaveChangesAsync();
            return chucNang;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var chucNang = await _context.chucNangs.FirstOrDefaultAsync(x => x.MaChucNang == id);
            chucNang.TrangThai = false;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<ChucNang>> GetAllAsync(string? search, int page = 1)
        {
            var listChucNang = _context.chucNangs.AsNoTracking().Include(x=>x.ChiTietQuyens).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listChucNang = listChucNang.Where(x => x.TenChucNang.Contains(search));
            }
            //var result = PageList<ChucNang>.Create(listChucNang, 10, page);
            var result = listChucNang.Take(page);
            return result.ToList();
        }

        public async Task<ChucNang> GetByIdAsync(int id)
        {
            return await _context.chucNangs.AsNoTracking().FirstOrDefaultAsync(x => x.MaChucNang == id && x.TrangThai == true) ?? new ChucNang();
        }

        public async Task<ChucNang> GetFunctionAsync(string tenChucNang)
        {
            var result = await _context.chucNangs.AsNoTracking().FirstOrDefaultAsync(x => x.TenChucNang == tenChucNang && x.TrangThai==true);
            return result;
        }

        public async Task<int> UpdateAsync(int id, ChucNang chucNang)
        {
            return await _context.chucNangs.Where(x => x.MaChucNang == id).ExecuteUpdateAsync(x => x.SetProperty(m => m.TenChucNang, chucNang.TenChucNang));

        }
    }
}
