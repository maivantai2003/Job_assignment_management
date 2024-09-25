using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class PhongBan
    {
        [Key]
        public int MaPhongBan {  get; set; }  
        public int? MaTruongPhong {  get; set; }
        public string? TenPhongBan {  set; get; }  
        public bool TrangThai {  get; set; }=true;
        public ICollection<NhanVien>? NhanVien { get; set; }
        [ForeignKey(nameof(MaTruongPhong))]
        public NhanVien? TruongPhong {  set; get; }
    }
}
