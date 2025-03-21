﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class ChiTietQuyen
    {
        [Key]
        public int MaChiTietQuyen {  get; set; }
        public int MaChucNang {  get; set; }
        public int MaNhomQuyen {  get; set; } 
        public string HanhDong {  get; set; }="X";
        [JsonIgnore]
        [ForeignKey(nameof(MaChucNang))]    
        public ChucNang? ChucNang { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MaNhomQuyen))]
        public NhomQuyen? NhomQuyen { get; set; }
    }
}
