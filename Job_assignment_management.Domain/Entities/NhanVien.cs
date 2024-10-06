using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class NhanVien
    {
        [Key]
        public int MaNhanVien {  get; set; }
        public int MaPhongBan {  get; set; }
        public string? TenChucVu {  get; set; }
        public string? TenNhanVien { get; set; }
        public string? SoDienThoai {  get; set; }
        public string? Email {  get; set; } 
        public bool TrangThai {  get; set; }=true;
        //[ForeignKey(nameof(MaNhanVien))]
        public TaiKhoan? TaiKhoan { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MaPhongBan))]
        public PhongBan? PhongBan { get; set; }
        public ICollection<ChuyenGiaoCongViec>? chuyenGiaoCongViecs { get; set; }
        public ICollection<ThongBao>? ThongBaos { get; set; }    
        public ICollection<TraoDoiThongTin>? TraoDoiThongTins { get; set; }
    }
}
