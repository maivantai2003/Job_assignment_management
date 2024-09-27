using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface ITienDoCongViecRepository
    {
        Task<List<TienDoCongViec>> GetAllAsync(string? search, int page = 1);
        Task<TienDoCongViec> GetByIdAsync(int id);
        Task<TienDoCongViec> CreateAsync(TienDoCongViec tienDoCongViec);
        Task<int> UpdateAsync(int id, TienDoCongViec tienDoCongViec);
        Task<int> DeleteAsync(int id);
    }
}
