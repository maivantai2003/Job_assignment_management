using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common
{
        public class LichSuCongViecViewModel
        {
            [Required]
            public int MaCongViec { get; set; }
            [Required]
            public DateTime NgayCapNhat { get; set; }=DateTime.Now;
            public string? NoiDung { get; set; }
        }
}
