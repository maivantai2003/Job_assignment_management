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
    public class ChiTietTraoDoiThongTinRepository : IChiTietTraoDoiThongTinRepository
    {
        private readonly ApplicationDbContext _context;
        public ChiTietTraoDoiThongTinRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(ChiTietTraoDoiThongTin chiTietTraoDoiThongTin)
        {
            await _context.chiTietTraoDoiThongTins.AddAsync(chiTietTraoDoiThongTin);
            await _context.SaveChangesAsync();
            return chiTietTraoDoiThongTin.MaChiTietTraoDoiThongTin;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var chiTiet=await _context.chiTietTraoDoiThongTins.FirstOrDefaultAsync(x=>x.MaChiTietTraoDoiThongTin==id);
            chiTiet.TrangThaiTraoDoi = false;
            await _context.SaveChangesAsync();
            return chiTiet.MaChiTietTraoDoiThongTin;
        }
    }
}
