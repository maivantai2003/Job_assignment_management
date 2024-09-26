using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class TraoDoiThongTin
    {
        [Key]
        public int MaTraoDoiThongTin {  get; set; } 
        public int MaCongViec {  get; set; }    
        public int MaNhanVien {  get; set; }    
        public int? MaFile {  get; set; }    
        public DateTime ThoiGianGui { get; set; }= DateTime.Now;    
        public string? NoiDungTraoDoi {  get; set; }
        public bool TrangThai {  get; set; }=true;
        [ForeignKey(nameof(MaCongViec))]
        public CongViec? CongViec { get; set; }
        [ForeignKey(nameof(MaNhanVien))]
        public NhanVien? NhanVien { get; set; }
        [ForeignKey(nameof(MaFile))] 
        public Files? Files { get; set; }
    }
}
