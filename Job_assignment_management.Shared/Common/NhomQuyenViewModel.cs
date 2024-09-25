using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common
{
    public class NhomQuyenViewModel
    {
        [Required]
        public string? TenQuyen { get; set; }
    }
}
