using System;

namespace Job_assignment_management.Shared.Common
{
    public class PhanCongViewModel
    {
        public int MaPhanCong { get; set; }
        public int MaCongViec { get; set; }
        public int MaNhanVien { get; set; }
        public string? VaiTro { get; set; }
        public bool TrangThaiCongViec { get; set; }
        public bool TrangThai { get; set; }
    }
}