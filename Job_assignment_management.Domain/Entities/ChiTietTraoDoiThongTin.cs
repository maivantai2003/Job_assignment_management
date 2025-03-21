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
    public class ChiTietTraoDoiThongTin
    {
        [Key]
        public int MaChiTietTraoDoiThongTin {  get; set; }
        public int MaTraoDoi {  get; set; }
        public int MaFile {  get; set; }
        public bool TrangThaiTraoDoi { get; set; } = true;
        [JsonIgnore]
        [ForeignKey(nameof(MaFile))]    
        public Files? Files { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MaTraoDoi))]    
        
        public TraoDoiThongTin? TraoDoiThongTin { get; set; }    
    }
}
