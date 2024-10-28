using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class ChiTietFile
    {
        [Key]
        public int MaChiTietFile {  get; set; }
        public int MaFile {  get; set; }
        public int MaPhanCong {  get; set; }
        public DateTime NgayGui {  get; set; }=DateTime.Now;
        [ForeignKey(nameof(MaPhanCong))]
        public PhanCong? PhanCong { get; set; }
        [ForeignKey(nameof(MaFile))]
        public Files? Files { get; set; }
        public bool TrangThai { get; set; } = true;
    }
}
