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
    public class FilesRepository : IFilesRepository
    {
        private readonly ApplicationDbContext _context;
        public FilesRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<Files> CreateAsync(Files file)
        {
            await _context.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var existing = await _context.files.FirstOrDefaultAsync(f => f.MaFile == id);
            if (existing != null)
            {
                existing.TrangThai = false;
                await _context.SaveChangesAsync();
            }
            return id;
        }

        public async Task<Files> GetByIdAsync(int id)
        {
            return await _context.files.AsNoTracking().FirstOrDefaultAsync(f => f.MaFile == id) ?? new Files();
        }
    }
}
