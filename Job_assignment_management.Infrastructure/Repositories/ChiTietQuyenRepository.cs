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
    public class ChiTietQuyenRepository : IChiTietQuyenReposity
    {
        private readonly ApplicationDbContext _context;
        public ChiTietQuyenRepository(ApplicationDbContext context) { 
            _context = context; 
        }

        public async Task<List<string>> CheckQuyenAsync(ChiTietQuyen chiTietQuyen)
        {
            var result =await _context.chiTietQuyens.AsNoTracking().Where(x => x.MaNhomQuyen == chiTietQuyen.MaNhomQuyen && x.MaChucNang == chiTietQuyen.MaChucNang).Select(x=>x.HanhDong).ToListAsync();
            if (result == null)
            {
                return new List<string>();
            }
            return result;
        }

        //public async Task<bool> CheckQuyenAsync(ChiTietQuyen chiTietQuyen)
        //{
        //    var result= await _context.chiTietQuyens.AsNoTracking().FirstOrDefaultAsync(x=>x.MaNhomQuyen==chiTietQuyen.MaNhomQuyen && x.MaChucNang==chiTietQuyen.MaChucNang && x.HanhDong==x.HanhDong);
        //    if (result == null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public async Task<ChiTietQuyen> CreateAsync(ChiTietQuyen chiTietQuyen)
        {
            await _context.chiTietQuyens.AddAsync(chiTietQuyen);
            await _context.SaveChangesAsync();
            return chiTietQuyen;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var chiTietQuyen = await _context.chiTietQuyens.FirstOrDefaultAsync(x => x.MaChiTietQuyen == id);
            _context.chiTietQuyens.Remove(chiTietQuyen);
            await _context.SaveChangesAsync();
            return id;
        }
        public async Task<List<ChiTietQuyen>> GetAllAsync()
        {
            var listChiTietQuyen = _context.chiTietQuyens.Include(x=>x.ChucNang).Include(x=>x.NhomQuyen).AsNoTracking().AsQueryable();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    listChiTietQuyen= listChiTietQuyen.Where(x => x.ChucNang.TenChucNang.Contains(search) || x.NhomQuyen.TenQuyen.Contains(search));
            //}
            //var result = PageList<ChiTietQuyen>.Create(listChiTietQuyen, 10, page);
            //return result.ToList();
            return listChiTietQuyen.ToList();
        }

        public async Task<ChiTietQuyen> GetByIdAsync(int id)
        {
            return await _context.chiTietQuyens.AsNoTracking().FirstOrDefaultAsync(x => x.MaChiTietQuyen == id) ?? new ChiTietQuyen();
        }

        public async Task<int> UpdateAsync(int id, ChiTietQuyen chiTietQuyen)
        {
            return await _context.chiTietQuyens.Where(x => x.MaChiTietQuyen == id).ExecuteUpdateAsync(x => x.SetProperty(m => m.MaNhomQuyen, chiTietQuyen.MaNhomQuyen)
            .SetProperty(m=>m.MaChucNang,chiTietQuyen.MaChucNang).SetProperty(m=>m.HanhDong, chiTietQuyen.HanhDong));
        }
    }
}
