using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IPhanDuAnRepository
    {
        Task<List<PhanDuAn>> GetAllAsync(string? search, int page = 1);
        Task<PhanDuAn> GetByIdAsync(int id);
        Task<PhanDuAn> CreateAsync(PhanDuAn phanDuAn);
        Task<int> UpdateAsync(int id, PhanDuAn phanDuAn);
        Task<int> DeleteAsync(int id);
    }
}
