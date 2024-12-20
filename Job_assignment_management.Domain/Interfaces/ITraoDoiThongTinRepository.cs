﻿using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface ITraoDoiThongTinRepository
    {
        Task<List<TraoDoiThongTin>> GetAllAsync(int maCongViec);
        Task<TraoDoiThongTin> GetByIdAsync(int id);
        Task<int> CreateAsync(TraoDoiThongTin traodoiThongTin);
        Task<int> UpdateAsync(int id, TraoDoiThongTin traodoiThongTin);
        Task<int> DeleteAsync(int id);
    }
}
