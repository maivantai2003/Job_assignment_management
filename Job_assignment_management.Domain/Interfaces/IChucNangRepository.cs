using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IChucNangRepository
    {
        Task<List<ChucNang>> GetAllAsync(string? search, int page = 1);
        Task<ChucNang> GetByIdAsync(int id);
        Task<ChucNang> GetFunctionAsync(string tenChucNang);
        Task<ChucNang> CreateAsync(ChucNang chucNang);
        Task<int> UpdateAsync(int id, ChucNang chucNang);
        Task<int> DeleteAsync(int id);
    }
}
