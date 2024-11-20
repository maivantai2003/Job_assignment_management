using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class NhacNho
    {
        [Key]
        public int MaNhacNho {  get; set; }
        public int MaCongViec { get; set; }
        public DateTime ThoiGianNhacNho { get; set; } = DateTime.Now;
        public string? NoiDungNhacNho { get; set; }
        public bool TrangThai { get; set; } = true;
        [ForeignKey(nameof(MaCongViec))]
        public CongViec? CongViec { get; set; }
    }
}
