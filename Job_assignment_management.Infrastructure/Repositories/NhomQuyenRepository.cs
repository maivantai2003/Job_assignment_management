﻿using Azure;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Shared.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class NhomQuyenRepository : INhomQuyenRepository
    {
        private readonly ApplicationDbContext _context;
        public NhomQuyenRepository(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<NhomQuyen> CreateAsync(NhomQuyen nhomQuyen)
        {
            await _context.nhomQuyens.AddAsync(nhomQuyen);
            await _context.SaveChangesAsync();
            return nhomQuyen;   
        }

        public async Task<int> DeleteAsync(int id)
        {
            var nhomquyen=await _context.nhomQuyens.FirstOrDefaultAsync(x=>x.MaQuyen==id);
            nhomquyen.TrangThai=false;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<NhomQuyen>> GetAllAsync(string? search, int page = 1)
        {
            var listNhomQuyen = _context.nhomQuyens.Include(x => x.ChiTietQuyens).ThenInclude(x=>x.ChucNang).AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                listNhomQuyen = listNhomQuyen.Where(x => x.TenQuyen.Contains(search));
            }
            //var result = PageList<NhomQuyen>.Create(listNhomQuyen, 10, page);
            var result = listNhomQuyen.Take(page);
            return result.ToList();
        }

        public async Task<List<NhomQuyen>> GetAllAsync()
        {
            return await _context.nhomQuyens.ToListAsync();
        }

        public async Task<NhomQuyen> GetByIdAsync(int id)
        {
            return await _context.nhomQuyens.Include(x=>x.ChiTietQuyens).ThenInclude(x => x.ChucNang).AsNoTracking().FirstOrDefaultAsync(x => x.MaQuyen == id && x.TrangThai == true)??new NhomQuyen();
        }

        public async Task<int> UpdateAsync(int id, NhomQuyen nhomQuyen)
        {
            return await _context.nhomQuyens.Where(x => x.MaQuyen == id).ExecuteUpdateAsync(x => x.SetProperty(m=>m.TenQuyen,nhomQuyen.TenQuyen));
        }
    }
}
