using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    internal interface IChiTietQuyen
    {
        Task<IEnumerable<ChiTietQuyen>> GetAllAsync(string? search, int page = 1);
        Task<ChiTietQuyen> GetByIdAsync(int id);
        Task<ChiTietQuyen> CreateAsync(ChiTietQuyen chiTietQuyen);
        Task<int> UpdateAsync(int id, ChiTietQuyen chiTietQuyen);
        Task<int> DeleteAsync(int id);
    }
}
