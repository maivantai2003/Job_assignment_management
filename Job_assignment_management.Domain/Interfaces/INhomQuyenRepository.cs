using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public interface INhomQuyenRepository
    {
        Task<List<NhomQuyen>> GetAllAsync(string ?search,int page=1);
        Task<List<NhomQuyen>> GetAllAsync();
        Task<NhomQuyen> GetByIdAsync(int id);
        Task<NhomQuyen> CreateAsync(NhomQuyen nhomQuyen);
        Task<int> UpdateAsync(int id, NhomQuyen nhomQuyen);
        Task<int> DeleteAsync(int id);
    }
}
