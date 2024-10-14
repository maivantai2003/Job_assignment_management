using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Shared.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Job_assignment_management.Infrastructure.Repositories;

public class ThongBaoRepository:IThongBaoRepository
{
    private readonly ApplicationDbContext _context;

    public ThongBaoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ThongBao> CreateAsync(ThongBao thongBao)
    {
        
        await _context.AddAsync(thongBao);
        await _context.SaveChangesAsync();
        return thongBao;
    }
    
    public async Task<List<ThongBao>> GetAllAsync(int taskId, int page, int pageSize)
    {
        var listThongBao = _context.thongBaos.AsNoTracking().AsQueryable();
        listThongBao = listThongBao.Where(x => x.MaCongViec == taskId).OrderByDescending(x => x.NgayGui);
    
        var result = PageList<ThongBao>.Create(listThongBao, pageSize, page);
        return result.ToList();
    }

    public async Task<ThongBao> GetByIdAsync(int id)
    {
        var thongBao = await _context.FindAsync<ThongBao>(id);
        return thongBao;
    }

    public async Task<int> UpdateAsync(int id, ThongBao thongBao)
    {
        var existingThongBao = await _context.thongBaos.FirstOrDefaultAsync(x=>x.MaThongBao == id);

        if (existingThongBao == null)
        {
            throw new KeyNotFoundException("No Notifications Found");
        }
        
        existingThongBao.NoiDungThongBao = thongBao.NoiDungThongBao;
        existingThongBao.TrangThai = thongBao.TrangThai;

        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var existingThongBao = await _context.thongBaos.FirstOrDefaultAsync(x => x.MaThongBao == id);
        if (existingThongBao == null)
        {
            throw new KeyNotFoundException("No Notifications Found");
        }
        _context.thongBaos.Remove(existingThongBao);
        await _context.SaveChangesAsync();
        return id;
    }
}