using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Job_assignment_management.Infrastructure.Repositories
{
    public class NhacNhoRepository:INhacNhoRepository
    {
        private readonly ApplicationDbContext _context;

        public NhacNhoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NhacNho> CreateAsync(NhacNho entity)
        {
            await _context.nhacNhos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<int> DeleteByIdAsync(int id)
        {
            var existingNhacNho = await _context.nhacNhos.FirstOrDefaultAsync(x => x.MaNhacNho == id);
            if (existingNhacNho != null)
            {
                existingNhacNho.TrangThai = false;
                await _context.SaveChangesAsync();
                return id;
            }
            return -1;
        }

        public async Task<List<NhacNho>> GetAll()
        {
            return await _context.nhacNhos.ToListAsync();
        }
    }
}
