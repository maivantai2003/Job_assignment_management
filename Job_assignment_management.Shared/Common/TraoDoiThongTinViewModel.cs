using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common
{
    public class TraoDoiThongTinViewModel
    {
        [Required]
        public int MaCongViec { get; set; }

        [Required]
        public int MaNhanVien { get; set; }
        public int? MaFile { get; set; }
        public string? NoiDungTraoDoi { get; set; }
    }
}
