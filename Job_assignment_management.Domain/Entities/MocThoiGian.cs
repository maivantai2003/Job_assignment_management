using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class MocThoiGian
    {
        [Key]
        public int MaMocThoiGian { get; set; }   
        public int MaCongViec {  get; set; }    
        public DateTime NgayDenHan { get; set; }
        public string? NoiDung {  get; set; } 
        public bool TrangThai {  get; set; }=true;
        [ForeignKey(nameof(MaCongViec))]
        public CongViec? CongViec { get; set; }
    }
}
