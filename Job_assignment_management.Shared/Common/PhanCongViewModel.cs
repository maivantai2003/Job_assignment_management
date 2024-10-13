using System;

namespace Job_assignment_management.Shared.Common
{
    public class PhanCongViewModel
    {
        public int MaCongViec { get; set; }
        public int MaNhanVien { get; set; }
        public string? VaiTro { get; set; }
        public bool TrangThaiCongViec { set; get; } = false;
    }
}