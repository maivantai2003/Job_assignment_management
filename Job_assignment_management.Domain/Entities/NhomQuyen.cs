using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class NhomQuyen
    {
        [Key]
        public int MaQuyen {  get; set; }
        public string? TenQuyen {  get; set; }
        public bool TrangThai { get; set; } = true; 
        public ICollection<ChiTietQuyen>? ChiTietQuyens { get; set; }
        [JsonIgnore]
        public ICollection<TaiKhoan>? taiKhoans { get; set; }
    }
}
