using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface INhacNhoRepository
    {
        Task<List<NhacNho>> GetAll();
        Task<NhacNho> CreateAsync(NhacNho entity);
        Task<int> DeleteByIdAsync(int id);
    }
}
