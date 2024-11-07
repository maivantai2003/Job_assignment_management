using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class ChuyenGiaoCongViec
    {
        [Key]
        public int MaChuyenGiaoCongViec {  get; set; }
        public int MaPhanCong {  get; set; }   
        public int MaNhanVienThucHien {  get; set; }
        public int MaNhanVienChuyenGiao {  get; set; }  
        public string ?LyDoChuyenGiao { get; set; }  
        public string? TenCongViec { get; set; }
        public string? VaiTro {  get; set; }
        public DateTime NgayChuyenGiao { get; set; }=DateTime.Now;
        public bool TrangThai {  get; set; }=true;
        [ForeignKey(nameof(MaPhanCong))]
        public PhanCong? PhanCong { get; set; }
        [ForeignKey(nameof(MaNhanVienThucHien))]
        public NhanVien? NhanVienThucHien{ get; set; }
        [ForeignKey(nameof(MaNhanVienChuyenGiao))]
        public NhanVien? NhanVienChuyenGiao{ get; set; }
    }
}
