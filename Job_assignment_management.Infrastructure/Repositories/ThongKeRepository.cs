using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class ThongKeRepository : IThongKeRepository
    {
        private readonly ApplicationDbContext _context;
        public ThongKeRepository(ApplicationDbContext context) { _context = context; }
        public async Task<List<CongViec>> ThongKeCongViec()
        {
            return await _context.congViecs.AsNoTracking().Where(x => x.TrangThai == true).ToListAsync();
        }
    }
}
