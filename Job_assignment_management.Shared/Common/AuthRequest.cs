using System.ComponentModel.DataAnnotations;

namespace RefreshToken.Models
{
    public class AuthRequest
    {
        [Required]
        public string TenTaiKhoan { get; set; }
        [Required]
        public string MatKhau { get; set; }    
    }
}
