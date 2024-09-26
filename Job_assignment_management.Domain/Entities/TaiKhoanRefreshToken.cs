using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Entities
{
    public class TaiKhoanRefreshToken
    {
        [Key]
        public int MaTaiKhoanRefreshToken{ get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        [NotMapped]
        public bool IsActive
        {
            get
            {
                return ExpirationDate > DateTime.UtcNow;
            }
        }
        public string IpAddress { get; set; }
        public bool IsInvalidades { get; set; }
        public int MaTaiKhoan { get; set; }
        [ForeignKey(nameof(MaTaiKhoan))]
        public  TaiKhoan? TaiKhoan { get; set; }
    }
}
