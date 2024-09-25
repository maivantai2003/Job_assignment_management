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
namespace RefreshToken.Services
{
    public class JwtService : IJwtService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public JwtService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponse> GetRefreshTokenAsync(string ipAddress, int userId, string userName)
        {
            var refreshToken = GenerateRefreshToken();
            var accessToken = GenerateToken(userName);
            return await SaveTokenDetails(ipAddress, userId, accessToken, refreshToken);

        }

        public async Task<AuthResponse> GetTokenAsync(AuthRequest request, string ipAddress)
        {
            var user = _context.taiKhoans.FirstOrDefault(x => x.TenTaiKhoan.Equals(request.TenTaiKhoan) && x.MatKhau.Equals(request.MatKhau));
            if (user == null)
            {
                return await Task.FromResult<AuthResponse>(null);
            }
            string tokenString = GenerateToken(user.TenTaiKhoan);
            string refreshToken = GenerateRefreshToken();
            return await SaveTokenDetails(ipAddress, user.MaNhanVien, tokenString, refreshToken);

        }
        private async Task<AuthResponse> SaveTokenDetails(string ipAddress, int userId, string tokenString, string refreshToken)
        {
            var useRefreshToken = new TaiKhoanRefreshToken
            {
                CreateDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMinutes(20),
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

        private string GenerateToken(string TenTaiKhoan)
        {
            var JwtKey = _configuration.GetSection("Jwt")["key"];
            var keyBytes = Encoding.ASCII.GetBytes(JwtKey);
            var TokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,TenTaiKhoan),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Role,"Employee")
                }),
                Expires = DateTime.UtcNow.AddSeconds(60),
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
