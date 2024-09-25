using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class TienDoCongViec
    {
        [Key]
        public int MaTienDoCongViec {  get; set; }
        public int MaCongViec { get; set; } 
        public DateTime NgayCapNhat { get; set; }
        public double MucDoHoanThanh {  get; set; }
        public string? NoiDung {  get; set; }  
        public bool TrangThai {  get; set; }=true;
        [ForeignKey(nameof(MaCongViec))]
        public CongViec? CongViec { set; get; }
    }
}
