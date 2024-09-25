﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class CongViec
    {
        [Key]
        public int MaCongViec {  get; set; }
        public int MaPhanDuAn {  get; set; }
        public int? MaCongViecCha {  get; set; }
        public string? TenCongViec { get; set; }
        public string? MoTa {  get; set; }
        public string? MucDoUuTien {  get; set; }   
        public DateTime ThoiGianBatDau {  get; set; }=DateTime.Now;
        public DateTime ThoiGianKetThuc { get; set; }
        public bool TrangThaiCongViec { get; set; }=false;
        public double MucDoHoanThanh {  get; set; }  
        public bool TrangThai {  get; set; }=true;
        [ForeignKey(nameof(MaPhanDuAn))]
        public PhanDuAn? PhanDuAn{ get; set; }
        [ForeignKey(nameof(MaCongViecCha))]
        public CongViec? CongViecCha{ get; set; }
        public ICollection<CongViec>? listCongViecCon { get; set;}
        public ICollection<CongViecPhongBan>? congViecPhongBans { get; set; }
        public ICollection<MocThoiGian>? MocThoiGians { get; set; }  
        public ICollection<PhanCong>? PhanCongs { get; set; } 
        public ICollection<TienDoCongViec>? tienDoCongViecs { get; set; }
        public ICollection<ThongBao>? ThongBaos { get; set; }
        public ICollection<TraoDoiThongTin>? TraoDoiThongTins { get; set; }
    }
}
