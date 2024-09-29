using Job_assignment_management.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IChuyenGiaoCongViecRepository
    {
        Task<List<ChuyenGiaoCongViec>> GetAllAsync(string search, int page);
        Task<ChuyenGiaoCongViec> GetByIdAsync(int id);
        Task<ChuyenGiaoCongViec> CreateAsync(ChuyenGiaoCongViec entity);
        Task UpdateAsync(int id, ChuyenGiaoCongViec entity); // Ensure this returns Task
        Task DeleteAsync(int id);
    }
}