using System.ComponentModel.DataAnnotations;

namespace RefreshToken.Models
{
    public class RefreshTokenRequest
    {
        [Required]
        public string ExpiredToken { get; set; }
        [Required]
        public string RefreshToken { get; set; }    

    }
}
