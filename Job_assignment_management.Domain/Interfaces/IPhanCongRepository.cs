using Job_assignment_management.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IPhanCongRepository
    {
        Task<List<PhanCong>> GetAllAsync(string search, int page);
        Task<List<PhanCong>> GetPhanCongNhanVienAsync(int maNhanVien);
        Task<PhanCong> GetByIdAsync(int id);
        Task<PhanCong> CreateAsync(PhanCong entity);
        Task UpdateAsync(int id, PhanCong entity);
        Task DeleteAsync(int id);
    }
}