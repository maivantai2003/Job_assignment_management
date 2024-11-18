using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class ThongKeNhanVien
    {
        public int MaNhanVien { get; set; }
        public string? TenNhanVien { get; set; }
        public int PhanCongHoanThanh { get; set; }
        public int PhanCongChuaHoanhThanh { get; set; }
        public double PhanTramPhanCong { get; set; }
    }
}
