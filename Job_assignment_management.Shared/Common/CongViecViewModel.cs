using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common
{
    public class  CongViecViewModel
    {
        public int MaPhanDuAn { get; set; }
        public int? MaCongViecCha { get; set; }
        public string? TenCongViec { get; set; }
        public string? MoTa { get; set; }
        public string? MucDoUuTien { get; set; }
        public DateTime ThoiGianBatDau { get; set; } = DateTime.Now;
        public DateTime? ThoiGianKetThuc { get; set; }
        public bool TrangThaiCongViec { get; set; } = false;
        public double MucDoHoanThanh { get; set; } = 0;
    }
}
