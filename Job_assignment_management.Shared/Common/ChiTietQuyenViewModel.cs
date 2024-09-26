using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common
{
    public class ChiTietQuyenViewModel
    {
        [Required]
        public int MaChucNang { get; set; }
        [Required]
        public int MaNhomQuyen { get; set; }
    }
}
