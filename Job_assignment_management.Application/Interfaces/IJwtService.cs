using Job_assignment_management.Domain.Entities;
using RefreshToken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Application.Interfaces
{
    public interface IJwtService
    {
        Task<AuthResponse> GetTokenAsync(AuthRequest request, string ipAddress);
        Task<AuthResponse> GetRefreshTokenAsync(string ipAddress, int userId, string userName);
        Task<bool> IsTokenValid(string accessToken, string ipAddress);
    }
}
