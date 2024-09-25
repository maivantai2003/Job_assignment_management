using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class DuAn
    {
        [Key]
        public int MaDuAn { get; set; }
        public string? TenDuAn {  set; get; }
        public bool TrangThai {  get; set; }=true;
        public ICollection<PhanDuAn>? PhanDuAn { get; set; }
    }
}
