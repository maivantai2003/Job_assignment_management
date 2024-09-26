using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface INhanVienRepository
    {
        Task<List<NhanVien>> GetAllAsync(string? search, int page = 1);
        Task<NhanVien> GetByIdAsync(int id);
        Task<NhanVien> CreateAsync(NhanVien nhanVien);
        Task<int> UpdateAsync(int id, NhanVien nhanVien);
        Task<int> DeleteAsync(int id);
    }
}
