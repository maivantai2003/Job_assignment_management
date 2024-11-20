using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IChiTietTraoDoiThongTinRepository
    {
        Task<int> AddAsync(ChiTietTraoDoiThongTin chiTietTraoDoiThongTin);
        Task<int> DeleteAsync(int id);
    }
}
