using Job_assignment_management.Application.Interfaces;
using Job_assignment_management.Application.Services;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefreshToken.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly ApplicationDbContext _context;
        public AuthenticationController(IJwtService jwtService, ApplicationDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(AuthRequest authRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResponse { IsSuccess = false, Reason = "UserName and Password must be provider" });
            }
            var authResponse = await _jwtService.GetTokenAsync(authRequest, HttpContext.Connection.RemoteIpAddress.ToString());
            if (authResponse == null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResponse { IsSuccess = false, Reason = "UserName and Password must be provider" });
            }
            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var token = GetJwtToken(request.ExpiredToken);
            var userRefreshToken = _context.taiKhoanRefreshTokens.FirstOrDefault(x => x.IsInvalidades == false && x.Token == request.ExpiredToken &&
            x.RefreshToken == request.RefreshToken && x.IpAddress == ipAddress);
            AuthResponse response = ValidateDetails(token, userRefreshToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            userRefreshToken.IsInvalidades = true;
            _context.taiKhoanRefreshTokens.Update(userRefreshToken);
            await _context.SaveChangesAsync();
            var userName = token.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.NameId).Value;
            var authResponse = await _jwtService.GetRefreshTokenAsync(ipAddress, userRefreshToken.MaTaiKhoan, userName);
            return Ok(authResponse);
        }
        private AuthResponse ValidateDetails(JwtSecurityToken token, TaiKhoanRefreshToken? userRefreshToken)
        {
            if (userRefreshToken == null)
            {
                return new AuthResponse { IsSuccess = false, Reason = "Invalid Token Details." };
            }
            if (token.ValidTo > DateTime.UtcNow)
            {
                return new AuthResponse { IsSuccess = false, Reason = "Token not expired" };
            }
            if (!userRefreshToken.IsActive)
            {
                return new AuthResponse { IsSuccess = false, Reason = "Refresh Token Expired" };
            }
            return new AuthResponse { IsSuccess = true };
        }

        private JwtSecurityToken GetJwtToken(string expiredToken)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(expiredToken);
        }
    }
}
