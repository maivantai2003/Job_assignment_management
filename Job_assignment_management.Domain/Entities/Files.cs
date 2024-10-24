using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class Files
    {
        [Key]
        public int MaFile {  get; set; }
        public string? TenFile {  get; set; }   
        public string? DuongDan {  get; set; }  
        public string? LoaiFile {  get; set; }=String.Empty;
        public bool TrangThai { get; set; } = true;   
        public ICollection<TraoDoiThongTin> ?TraoDoiThongTins { get; set; }  
    }
}
