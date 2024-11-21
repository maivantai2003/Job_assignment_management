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
    public class TraoDoiThongTin
    {
        [Key]
        public int MaTraoDoiThongTin {  get; set; } 
        public int MaCongViec {  get; set; }    
        public int MaNhanVien {  get; set; } 
        public string? TenNhanVien { get; set; }
        public DateTime ThoiGianGui { get; set; }= DateTime.Now;    
        public string? NoiDungTraoDoi {  get; set; }
        public bool TrangThai {  get; set; }=true;
        [JsonIgnore]
        [ForeignKey(nameof(MaCongViec))]
        public CongViec? CongViec { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MaNhanVien))]
        public NhanVien? NhanVien { get; set; }
        public ICollection<ChiTietTraoDoiThongTin>? chiTietTraoDoiThongTins { get; set; }
    }
}
