using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IThongKeRepository
    {

        public Task<List<CongViec>> ThongKeCongViec();
    }
}
