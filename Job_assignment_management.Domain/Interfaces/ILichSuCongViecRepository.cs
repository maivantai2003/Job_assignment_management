using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface ILichSuCongViecRepository
    {
        Task<List<LichSuCongViec>> GetAllAsync();
        Task<List<LichSuCongViec>> GetByIdAsync(int id);
        Task<LichSuCongViec> CreateAsync(LichSuCongViec tienDoCongViec);
        Task<int> UpdateAsync(int id, LichSuCongViec tienDoCongViec);
        Task<int> DeleteAsync(int id);
    }
}
