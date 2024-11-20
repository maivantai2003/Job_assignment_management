using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IChiTietQuyenReposity
    {
        Task<List<ChiTietQuyen>> GetAllAsync();
        Task<ChiTietQuyen> GetByIdAsync(int id);
        Task<ChiTietQuyen> CreateAsync(ChiTietQuyen chiTietQuyen);
        Task<int> UpdateAsync(int id, ChiTietQuyen chiTietQuyen);
        Task<int> DeleteAsync(int id);
        Task<bool> CheckQuyenAsync(ChiTietQuyen chiTietQuyen);
    }
}
