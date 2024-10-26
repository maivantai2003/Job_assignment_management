using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
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
        public Task<ChiTietFile> CreateAsync(ChiTietFile chiTietFile)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietFile>> GetByFilePhanCongAsync(int maPhanCong)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietFile>> GetByIdAsync(int maPhanCong)
        {
            throw new NotImplementedException();
        }
    }
}
