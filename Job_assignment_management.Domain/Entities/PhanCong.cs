using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class PhanCong
    {
        [Key]
        public int MaPhanCong {  get; set; }  
        public int MaNhanVien {  get; set; }    
        public int MaCongViec {  get; set; }
        public string ?VaiTro {  get; set; }
        public bool TrangThaiCongViec { set; get; } = false;
        public bool TrangThai {  set; get; } = true; 
        [ForeignKey(nameof(MaCongViec))]   
        public CongViec? CongViec { set; get; }
        [ForeignKey(nameof(MaNhanVien))]
        public NhanVien? NhanVien { set; get; }  
        public ICollection<ChuyenGiaoCongViec>? chuyenGiaoCongViecs { get; set; }
    }
}
