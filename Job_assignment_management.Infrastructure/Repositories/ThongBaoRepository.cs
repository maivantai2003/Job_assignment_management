using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;

namespace Job_assignment_management.Infrastructure.Repositories;

public class ThongBaoRepository:IThongBaoRepository
{
    private readonly ApplicationDbContext _context;

    public async Task<ThongBao> CreateAsync(ThongBao thongBao)
    {
        await _context.AddAsync(thongBao);
        await _context.SaveChangesAsync();
        return thongBao;
    }
    public Task<List<ThongBao>> GetAllAsync(int taskId)
    {
        throw new NotImplementedException();
    }

    public Task<ThongBao> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(int id, ThongBao thongBao)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}