using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IDuAnRepository
    {
        Task<List<DuAn>> GetAllAsync(string? search, int page = 1);
        Task<DuAn> GetByIdAsync(int id);
        Task<DuAn> CreateAsync(DuAn duAn);
        Task<int> UpdateAsync(int id, DuAn duAn);
        Task<int> DeleteAsync(int id);
    }
}
