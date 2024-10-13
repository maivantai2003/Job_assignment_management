using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IPhongBanRepository
    {
        Task<List<PhongBan>> GetAllAsync(string? search, int page = 1);
        Task<PhongBan> GetByIdAsync(int id);
        Task<List<PhongBan>> GetTruongPhongByIdAsync(int id);
        Task<PhongBan> CreateAsync(PhongBan phongBan);
        Task<int> UpdateAsync(int id, PhongBan phongBan);
        Task<int> DeleteAsync(int id);
    }
}
