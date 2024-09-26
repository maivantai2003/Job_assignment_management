using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface ITaiKhoanRepository
    {
        Task<List<TaiKhoan>> GetAllAsync(string? search, int page = 1);
        Task<TaiKhoan> GetByIdAsync(int id);
        Task<TaiKhoan> CreateAsync(TaiKhoan taiKhoan);
        Task<int> UpdateAsync(int id, TaiKhoan taiKhoan);
        Task<int> DeleteAsync(int id);
    }
}
