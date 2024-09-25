using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class ChucNang
    {
        [Key]
        public int MaChucNang {  get; set; }
        public string? TenChucNang {  set; get; }
        public bool TrangThai {  get; set; }=true;
        public ICollection<ChiTietQuyen>? ChiTietQuyens { get; set; }
    }
}
