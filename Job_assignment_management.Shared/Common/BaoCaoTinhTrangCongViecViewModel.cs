using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common
{
    public class BaoCaoTinhTrangCongViecViewModel
    {
        public string? PhongBan {  get; set; }
        public string? CongViec {  get; set; }
        public string? TrangThaiCongViec { get; set; }
        public DateTime ThoiGianBatDau { get; set; }=DateTime.Now;
        public DateTime ThoiGianKetThuc {  get; set; }=DateTime.Now;
        public double MucDoHoanhThanh {  get; set; }
    }
}
