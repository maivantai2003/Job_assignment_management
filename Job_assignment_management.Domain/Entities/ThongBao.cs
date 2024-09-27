using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class ThongBao
    {
        [Key]
        public int MaThongBao { get; set; } 
        public int MaCongViec {  get; set; }
        public int MaNhanVien {  get; set; }
        public DateTime NgayGui { get; set; }
        public string NoiDungThongBao { get; set; }
        public bool TrangThai { get; set; }
        [ForeignKey(nameof(MaCongViec))]
        public CongViec? CongViec { set; get; }
        [ForeignKey(nameof(MaNhanVien))]
        public NhanVien? NhanVien { set; get; }
    }
}
