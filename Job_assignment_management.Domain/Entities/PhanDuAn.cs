﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class PhanDuAn
    {
        [Key]
        public int MaPhanDuAn {  get; set; }
        public int MaDuAn {  set; get; }
        public string? TenPhan {  get; set; }
        public bool TrangThai {  get; set; }=true;
        [ForeignKey(nameof(MaDuAn))]
        public DuAn? DuAn { get; set; }
    }
}
