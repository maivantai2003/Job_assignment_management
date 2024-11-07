using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IChiTietFileRepository
    {
        Task<List<ChiTietFile>> GetByIdAsync(int maPhanCong);
        Task<List<ChiTietFile>> GetByFilePhanCongAsync(int maPhanCong);
        Task<ChiTietFile> CreateAsync(ChiTietFile chiTietFile);
        Task<int> DeleteAsync(int id);
    }
}
