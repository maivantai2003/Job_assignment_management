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
    public class ChiTietFileRepository : IChiTietFileRepository
    {
        private readonly ApplicationDbContext _context;
        public ChiTietFileRepository(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<ChiTietFile> CreateAsync(ChiTietFile chiTietFile)
        {
            await _context.chiTietFiles.AddAsync(chiTietFile);
            await _context.SaveChangesAsync();
            return chiTietFile;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var chiTietFile=await _context.chiTietFiles.AsNoTracking().FirstOrDefaultAsync(x=>x.MaChiTietFile==id);
            chiTietFile.TrangThai=false;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<ChiTietFile>> GetByFilePhanCongAsync(int maPhanCong)
        {
             var listFile=await _context.chiTietFiles.AsNoTracking().Where(x=>x.MaPhanCong==maPhanCong).ToListAsync();
             return listFile;    
        }
        public Task<List<ChiTietFile>> GetByIdAsync(int maPhanCong)
        {
            throw new NotImplementedException();
        }
    }
}