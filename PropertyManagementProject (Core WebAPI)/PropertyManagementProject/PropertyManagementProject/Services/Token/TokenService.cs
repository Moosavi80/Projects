using DataAccess.Interfaces;
using DataAccess.Models.Login;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string GenerateAccessToken(UserDto user)
    {
        long expiry = DateTimeOffset.UtcNow
            .AddMinutes(Convert.ToDouble(configuration["Jwt:AccessTokenExpireMinutes"]))
            .ToUnixTimeSeconds();

        var payload = $"{user.UserId}|{user.UserGroup}|{(Convert.ToBoolean(user.UserType) ? 1 : 0)}|{expiry}";

        return BuildToken(payload);
    }

    public ClaimsPrincipal? ValidateAccessToken(string token, bool ignoreExpiry = false)
    {
        if (!TryParseToken(token, out var payload, out var segments))
            return null;

        if (!ignoreExpiry &&
            DateTimeOffset.UtcNow.ToUnixTimeSeconds() > long.Parse(segments![3]))
            return null;

        return BuildPrincipal(segments!);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        => ValidateAccessToken(token, ignoreExpiry: true);

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        RandomNumberGenerator.Fill(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    public string HashRefreshToken(string refreshToken)
        => Convert.ToHexString(
            SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken)));

    // ─── private helpers ───────────────────────────────────────

    private string BuildToken(string payload)
    {
        var encodedPayload = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload))
            .TrimEnd('=');

        var sig = ComputeSignature(payload);

        return $"{encodedPayload}.{sig}";
    }

    private bool TryParseToken(string token, out string? payload, out string[]? segments)
    {
        payload = null;
        segments = null;

        var parts = token.Split('.');
        if (parts.Length != 2) return false;

        try
        {
            payload = Encoding.UTF8.GetString(
                Convert.FromBase64String(parts[0] + "=="));
        }
        catch { return false; }

        segments = payload.Split('|');
        if (segments.Length != 4) return false;

        var expectedSig = ComputeSignature(payload);

        if (!CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(expectedSig),
            Encoding.UTF8.GetBytes(parts[1]))) return false;

        return true;
    }

    private string ComputeSignature(string payload)
    {
        var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
        using var hmac = new HMACSHA256(key);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));

        return Convert.ToBase64String(hash[..8])
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
    }

    private static ClaimsPrincipal BuildPrincipal(string[] segments)
    {
        List<Claim> claims =
        [
            new("UI", segments[0]),
            new("UG", segments[1]),
            new("UT", segments[2])
        ];

        return new ClaimsPrincipal(
            new ClaimsIdentity(claims, "CustomToken"));
    }
}