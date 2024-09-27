using Job_assignment_management.Domain.Entities;

namespace Job_assignment_management.Domain.Interfaces;

public interface IThongBaoRepository
{
    Task<List<ThongBao>> GetAllAsync(int taskId);
    Task<ThongBao> GetByIdAsync(int id);
    Task<ThongBao> CreateAsync(ThongBao thongBao);
    Task<int> UpdateAsync(int id, ThongBao thongBao);
    Task<int> DeleteAsync(int id);
}