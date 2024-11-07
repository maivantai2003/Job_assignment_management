using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface ICongViecRepository
    {
        Task<List<CongViec>> GetAllAsync(string? search, int page = 1);
        Task<CongViec> GetByIdAsync(int id);
        Task<CongViec> CreateAsync(CongViec congViec);
        Task<int> UpdateAsync(int id, CongViec congViec);
        Task<int> UpdateTaskDay(int id, DateTime ngayKetThuc);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateComplete(int id,bool trangThai);
    }
}
