using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class CongViecPhongBan
    {
        [Key]
        public int MaCongViecPhongBan {  get; set; }
        public int MaPhongBan { get; set; } 
        public int MaCongViec {  get; set; }  
        public bool TrangThai {  get; set; }=true;
        [JsonIgnore]
        [ForeignKey(nameof(MaPhongBan))]
        public PhongBan? PhongBan { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MaCongViec))]
        public CongViec? CongViec { get; set; }
    }
}
