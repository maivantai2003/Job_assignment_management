using Microsoft.IdentityModel.Tokens;
using RefreshToken.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Job_assignment_management.Application.Services;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore;
using Job_assignment_management.Application.Interfaces;
namespace RefreshToken.Services
{
    public class JwtService : IJwtService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public static int MaNhomQuyen;
        public static string TenQuyen;
        public static string TenNhanVien;
        public static List<string> listChucNang;
        public JwtService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponse> GetRefreshTokenAsync(string ipAddress, int userId, string userName)
        {
            var refreshToken = GenerateRefreshToken();
            var accessToken = GenerateToken(userName,userId);
            return await SaveTokenDetails(ipAddress, userId, accessToken, refreshToken);

        }

        public async Task<AuthResponse> GetTokenAsync(AuthRequest request, string ipAddress)
        {
            var user =await _context.taiKhoans.AsNoTracking().Include(x=>x.NhanVien).FirstOrDefaultAsync(x => x.TenTaiKhoan.Equals(request.TenTaiKhoan) && x.MatKhau.Equals(request.MatKhau) && x.TrangThai==true);
            if (user == null)
            {
                return await Task.FromResult<AuthResponse>(null);
            }
            MaNhomQuyen = user.MaNhomQuyen;
            TenNhanVien=user.NhanVien.TenNhanVien;
            string tokenString = GenerateToken(user.TenTaiKhoan,user.MaNhanVien);
            string refreshToken = GenerateRefreshToken();
            return await SaveTokenDetails(ipAddress, user.MaNhanVien, tokenString, refreshToken);

        }
        private async Task<AuthResponse> SaveTokenDetails(string ipAddress, int userId, string tokenString, string refreshToken)
        {
            var useRefreshToken = new TaiKhoanRefreshToken
            {
                CreateDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddDays(2),
                IpAddress = ipAddress,
                IsInvalidades = false,
                RefreshToken = refreshToken,
                Token = tokenString,
                MaTaiKhoan = userId
            };
            await _context.taiKhoanRefreshTokens.AddAsync(useRefreshToken);
            await _context.SaveChangesAsync();
            return new AuthResponse
            {
                Token = tokenString,
                RefreshToken = refreshToken,
                IsSuccess = true
            };
        }

        private string GenerateRefreshToken()
        {
            var byteArray = new byte[64];
            using (var crytoProvider = new RNGCryptoServiceProvider())
            {
                crytoProvider.GetBytes(byteArray);
                return Convert.ToBase64String(byteArray);
            }
        }

        private string GenerateToken(string TenTaiKhoan,int userId)
        {
            var JwtKey = _configuration.GetSection("Jwt")["key"];
            var keyBytes = Encoding.ASCII.GetBytes(JwtKey);
            var TokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, TenTaiKhoan),
                        new Claim(ClaimTypes.Role, userId.ToString()),
                        new Claim("MaTaiKhoan", userId.ToString()),
                        new Claim("MaNhomQuyen",MaNhomQuyen.ToString()),
                        new Claim("TenNhanVien",TenNhanVien)
                        
                    };
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256
                )
            };
            var token = TokenHandler.CreateToken(descriptor);
            string tokenString = TokenHandler.WriteToken(token);
            return tokenString;
        }

        public async Task<bool> IsTokenValid(string accessToken, string ipAddress)
        {
            var isValid = _context.taiKhoanRefreshTokens.FirstOrDefault(x => x.Token == accessToken && x.IpAddress == ipAddress) != null;
            return await Task.FromResult(isValid);
        }
    }
}
