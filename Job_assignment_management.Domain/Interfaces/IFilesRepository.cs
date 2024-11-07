using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IFilesRepository
    {
        Task<List<Files>> GetAllAsync();
        Task<Files> GetByIdAsync(int id);
        Task<Files> CreateAsync(Files file);
        Task<int> DeleteAsync(int id);
    }
}
