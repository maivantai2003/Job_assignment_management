using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface ITraoDoiThongTinRepository
    {
        Task<List<TraoDoiThongTin>> GetAllAsync(string? search, int page = 1);
        Task<TraoDoiThongTin> GetByIdAsync(int id);
        Task<TraoDoiThongTin> CreateAsync(TraoDoiThongTin traodoiThongTin);
        Task<int> UpdateAsync(int id, TraoDoiThongTin traodoiThongTin);
        Task<int> DeleteAsync(int id);
    }
}
