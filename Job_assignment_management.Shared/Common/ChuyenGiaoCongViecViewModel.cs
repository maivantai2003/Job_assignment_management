using System;

namespace Job_assignment_management.Shared.Common
{
    public class ChuyenGiaoCongViecViewModel
    {
        public int MaChuyenGiaoCongViec { get; set; }
        public string? LyDoChuyenGiao { get; set; }
        public int MaNhanVienChuyenGiao { get; set; }
        public int MaNhanVienThucHien { get; set; }
        public int MaPhanCong { get; set; }
        public DateTime NgayChuyenGiao { get; set; } = DateTime.Now;
    }
}
