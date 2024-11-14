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
    public class PhanDuAnRepository:IPhanDuAnRepository
    {
        private readonly ApplicationDbContext _context;

        public PhanDuAnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhanDuAn>> GetAllAsync(string? search, int page = 1)
        {
            var listPhanDuAn = _context.phanDuAns.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listPhanDuAn = listPhanDuAn.Where(x => x.TenPhan.Contains(search));
            }
            var result = PageList<PhanDuAn>.Create(listPhanDuAn, 10, page);
            return result.ToList();
        }
        public async Task<PhanDuAn> GetByIdAsync(int id)
        {
            return await _context.phanDuAns.AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaPhanDuAn == id && x.TrangThai == true) ?? new PhanDuAn();
        }

        public async Task<PhanDuAn> CreateAsync(PhanDuAn phanDuAn)
        {
            await _context.phanDuAns.AddAsync(phanDuAn);
            await _context.SaveChangesAsync();
            return phanDuAn;
        }

        public async Task<int> UpdateAsync(int id, PhanDuAn phanDuAn)
        {
            return await _context.phanDuAns.Where(x => x.MaPhanDuAn == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(t => t.TenPhan, phanDuAn.TenPhan));
        }
        public async Task<int> DeleteAsync(int id)
        {
            var phanDuAn = await _context.phanDuAns.FirstOrDefaultAsync(x => x.MaPhanDuAn == id);
            if (phanDuAn != null)
            {
                phanDuAn.TrangThai = false;
                await _context.SaveChangesAsync();
            }
            return id;
        }
    }
}
