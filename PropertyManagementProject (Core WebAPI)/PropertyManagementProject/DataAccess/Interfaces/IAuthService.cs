using DataAccess.DTOs.Login;
using DataAccess.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> Login(LoginRequest request, string ip, string device);

        Task<LoginResponse?> RefreshToken(RefreshTokenRequest request, string ipAddress, string device);

        Task<bool> LogoutAsync(string userId, string refreshToken);

        Task<bool> ChangePasswordAsync(ChangePasswordRequest request, string userId);
    }
}
