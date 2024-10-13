using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface ICongViecPhongBanRepository
    {
        Task<List<CongViecPhongBan>> GetAllAsync(string? search, int page = 1);
        Task<List<CongViecPhongBan>> GetPhongBanPhanCongAsync(int id);
        Task<CongViecPhongBan> GetByIdAsync(int id);
        Task<CongViecPhongBan> CreateAsync(CongViecPhongBan congViecPhongBan);
        Task<int> UpdateAsync(int id, CongViecPhongBan congViecPhongBan);
        Task<int> DeleteAsync(int id);
    }
}
