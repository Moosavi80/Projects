using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models.Login;
using System.Security.Claims;

namespace DataAccess.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserDto user);

        ClaimsPrincipal? ValidateAccessToken(string token, bool ignoreExpiry = false);

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);

        string GenerateRefreshToken();

        string HashRefreshToken(string refreshToken);
    }
}
