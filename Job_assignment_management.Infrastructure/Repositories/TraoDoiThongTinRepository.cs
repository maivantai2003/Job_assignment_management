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
    public class TraoDoiThongTinRepository : ITraoDoiThongTinRepository
    {
        private readonly ApplicationDbContext _context;
        public TraoDoiThongTinRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TraoDoiThongTin> CreateAsync(TraoDoiThongTin traodoiThongTin)
        {
            await _context.AddAsync(traodoiThongTin);
            await _context.SaveChangesAsync();
            return traodoiThongTin;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var existingTraoDoiTT = await _context.traoDoiThongTins.FirstOrDefaultAsync(x => x.MaTraoDoiThongTin == id);
            existingTraoDoiTT.TrangThai = false;
            await _context.SaveChangesAsync();
            return id;
        }
        public async Task<List<TraoDoiThongTin>> GetAllAsync(int maCongViec)
        {
            var listTraoDoiThongTin=await _context.traoDoiThongTins.AsNoTracking().Where(x=>x.MaCongViec==maCongViec && x.TrangThai==true).Include(x=>x.chiTietTraoDoiThongTins).ToListAsync();
            //var listTraoDoiTT = _context.traoDoiThongTins.AsNoTracking().AsQueryable();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    listTraoDoiTT = listTraoDoiTT.Where(x => x.NoiDungTraoDoi.Contains(search) || x.ThoiGianGui.ToString().Contains(search));
            //}
            //var result = PageList<TraoDoiThongTin>.Create(listTraoDoiTT, 10, page);
            //return result.ToList();
            return listTraoDoiThongTin;
        }

        public async Task<TraoDoiThongTin> GetByIdAsync(int id)
        {
            return await _context.traoDoiThongTins.AsNoTracking().FirstOrDefaultAsync(x => x.MaTraoDoiThongTin == id && x.TrangThai==true) ?? new TraoDoiThongTin();
        }

        public async Task<int> UpdateAsync(int id, TraoDoiThongTin traodoiThongTin)
        {
            return await _context.traoDoiThongTins.Where(x => x.MaTraoDoiThongTin == id).ExecuteUpdateAsync(x =>
                x.SetProperty(m => m.NoiDungTraoDoi, traodoiThongTin.NoiDungTraoDoi)
            );
        }
    }
}
