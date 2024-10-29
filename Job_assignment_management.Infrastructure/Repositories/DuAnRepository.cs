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
    public class DuAnRepository:IDuAnRepository
    {
        private readonly ApplicationDbContext _context;

        public DuAnRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<DuAn>> GetAllAsync(string? search, int page = 1)
        {
            var listDuAn = _context.duAns.Include(x=>x.PhanDuAn).ThenInclude(x => x.congViecs).AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listDuAn = listDuAn.Where(x => x.TenDuAn.Contains(search));
            }
            //var result = PageList<DuAn>.Create(listDuAn, 20, page);
            var result = listDuAn.Take(page);
            return result.ToList();
        }
        public async Task<DuAn> GetByIdAsync(int id)
        {
            return await _context.duAns.Include(x => x.PhanDuAn).ThenInclude(x => x.congViecs).ThenInclude(x => x.listCongViecCon).AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaDuAn == id) ?? new DuAn();
        }

        public async Task<DuAn> CreateAsync(DuAn duAn)
        {
            await _context.duAns.AddAsync(duAn);
            await _context.SaveChangesAsync();
            return duAn;
        }

        public async Task<int> UpdateAsync(int id, DuAn duAn)
        {
            return await _context.duAns.Where(x => x.MaDuAn == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(t => t.TenDuAn, duAn.TenDuAn));
        }

        public async Task<int> DeleteAsync(int id)
        {
            var duAn = await _context.duAns.FirstOrDefaultAsync(x => x.MaDuAn == id);
            if (duAn != null)
            {
                duAn.TrangThai = false;
                await _context.SaveChangesAsync();
            }
            return id;
        }
    }
}
