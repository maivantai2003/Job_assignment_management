using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IMocThoiGianRepository
    {
        Task<List<MocThoiGian>> GetAllAsync(string? search, int page = 1);
        Task<MocThoiGian> GetByIdAsync(int id);
        Task<MocThoiGian> CreateAsync(MocThoiGian mocThoiGian);
        Task<int> UpdateAsync(int id, MocThoiGian mocThoiGian);
        Task<int> DeleteAsync(int id);
    }
}
