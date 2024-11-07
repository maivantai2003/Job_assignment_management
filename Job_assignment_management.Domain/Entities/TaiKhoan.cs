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
    public class TaiKhoan
    {
        [Key]
        public int MaNhanVien {  get; set; }
        public int MaNhomQuyen {  get; set; }
        public string? TenTaiKhoan {  get; set; }
        public string? MatKhau {  get; set; }
        public bool TrangThai { get; set; } = true;
        [ForeignKey(nameof(MaNhomQuyen))]
        public NhomQuyen? NhomQuyen { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MaNhanVien))]
        public NhanVien? NhanVien { get; set; }
        public ICollection<TaiKhoanRefreshToken>? RefreshTokens { get; set; }
    }
}
