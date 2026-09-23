using DataAccess.DTOs.Login;
using DataAccess.Interfaces;
using DataAccess.Models.Login;
using Org.BouncyCastle.Asn1.Ocsp;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Exceptions;
using PropertyManagementProject.Services.Token;
using System.Data;
using System.Security.Claims;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;

    public AuthService(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public async Task<LoginResponse?> Login(LoginRequest request, string IP, string Device)
    {
        string hashpass = new PasswordService().HashPassword(request.Password);

        DataTable? user = await DbConnectionFactory.DbInstance.Pr_Select_Login(request.Username, hashpass);

        if (user == null || user.Rows.Count == 0)
            throw new ValidationException("نام کاربری یا رمز عبور اشتباه است.");

        UserDto dto = new UserDto
        {
            UserId = user.Rows[0]["UserId"]?.ToString() ?? string.Empty,
            UserName = user.Rows[0]["UserName"]?.ToString() ?? string.Empty,
            Password = user.Rows[0]["Password"]?.ToString() ?? string.Empty,
            FullName = user.Rows[0]["FullName"]?.ToString() ?? string.Empty,
            MobileNumber = user.Rows[0]["MobileNumber"]?.ToString() ?? string.Empty,
            NationalNumber = user.Rows[0]["NationalNumber"]?.ToString() ?? string.Empty,
            UserType = user.Rows[0]["UserType"]?.ToString() ?? string.Empty,
            UserGroup = user.Rows[0]["UserGroup"]?.ToString() ?? string.Empty
        };

        string token = _tokenService.GenerateAccessToken(dto);
        string refreshToken = _tokenService.GenerateRefreshToken();
        string hash = _tokenService.HashRefreshToken(refreshToken);


        if (await DbConnectionFactory.DbInstance.Pr_SaveRefreshToken(dto.UserId, hash, DateTime.UtcNow.AddHours(8), IP, Device))
        {
            bool change = false;

            if (request.Username == dto.NationalNumber && hashpass == new PasswordService().HashPassword(dto.MobileNumber))
                change = true;

            return new LoginResponse
            {
                UserId = dto.UserId,
                FullName = dto.FullName,
                UserName = dto.UserName,
                AccessToken = token,
                RefreshToken = refreshToken,
                ChangePassword = change
                //AccessTokenExpireDate = DateTime.UtcNow.AddHours(8)
            };
        }

        throw new Exception("ثبت توکن با خطا مواجه شد.");
    }

    public async Task<LoginResponse?> RefreshToken(RefreshTokenRequest request, string ipAddress, string device)
    {
        ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

        string? userId = principal?.FindFirst("UI")!.Value;

        if (string.IsNullOrEmpty(userId))
            throw new ValidationException("نوکن معتبر نیست.");

        string hash = _tokenService.HashRefreshToken(request.RefreshToken);

        DataTable? oldToken = await DbConnectionFactory.DbInstance.Pr_GetRefreshToken(hash);

        if (oldToken == null || oldToken.Rows.Count == 0)
            throw new ValidationException("Refresh Token معتبر نیست.");

        DataRow row = oldToken.Rows[0];

        if (row == null)
            throw new ValidationException("دریافت اطلاعات با خطا مواجه شد.");

        UserRefreshToken userRefreshToken = new()
        {
            Id = Convert.ToInt64(row["ID"]),
            UserId = Convert.ToInt32(row["UserID"]),
            TokenHash = row["TokenHash"].ToString()!,
            ExpireDate = Convert.ToDateTime(row["ExpireDate"]),
            CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
            Revoked = Convert.ToBoolean(row["Revoked"]),
            RevokedDate = row["RevokedDate"] == DBNull.Value ? null : Convert.ToDateTime(row["RevokedDate"]),
            Device = row["Device"] == DBNull.Value ? "" : row["Device"].ToString(),
            IPAddress = row["IPAddress"] == DBNull.Value ? "" : row["IPAddress"].ToString()
        };

        if (Convert.ToInt64(userRefreshToken.UserId) != Convert.ToInt64(userId))
            throw new ValidationException("توکن متعلق به این کاربر نیست.");

        if (userRefreshToken.Revoked)
            throw new ValidationException("Refresh Token باطل شده است.");

        if (userRefreshToken.ExpireDate < DateTime.UtcNow)
            throw new ValidationException("Refresh Token کاربر منقضی شده است.");

        DataTable? user = await DbConnectionFactory.DbInstance.Pr_Select_Login(userRefreshToken.UserId.ToString(), "", "1");

        if (user == null || user.Rows.Count == 0)
            throw new ValidationException("کاربر یافت نشد.");

        UserDto dto = new UserDto
        {
            UserId = user.Rows[0]["UserId"]?.ToString() ?? string.Empty,
            UserName = user.Rows[0]["UserName"]?.ToString() ?? string.Empty,
            Password = user.Rows[0]["Password"]?.ToString() ?? string.Empty,
            FullName = user.Rows[0]["FullName"]?.ToString() ?? string.Empty,
            MobileNumber = user.Rows[0]["MobileNumber"]?.ToString() ?? string.Empty,
            NationalNumber = user.Rows[0]["NationalNumber"]?.ToString() ?? string.Empty,
            UserType = user.Rows[0]["UserType"]?.ToString() ?? string.Empty,
            UserGroup = user.Rows[0]["UserGroup"]?.ToString() ?? string.Empty
        };

        string accessToken = _tokenService.GenerateAccessToken(dto);
        string refreshToken = _tokenService.GenerateRefreshToken();
        string newHash = _tokenService.HashRefreshToken(refreshToken);

        await DbConnectionFactory.DbInstance.Pr_RevokeRefreshToken(userRefreshToken.Id.ToString());
         await DbConnectionFactory.DbInstance.Pr_SaveRefreshToken(dto.UserId, newHash, DateTime.UtcNow.AddHours(8), device, ipAddress);

        return new LoginResponse
        {
            UserId = dto.UserId,
            FullName = dto.FullName,
            UserName = dto.UserName,
            AccessToken = accessToken,
            RefreshToken = refreshToken
            //AccessTokenExpireDate = DateTime.UtcNow.AddHours(8),
        };
    }

    public async Task<bool> LogoutAsync(string userId, string refreshToken)
    {
        string hash = _tokenService.HashRefreshToken(refreshToken);

        DataTable? token = await DbConnectionFactory.DbInstance.Pr_GetRefreshToken(hash);

        if (token == null || token.Rows.Count == 0)
            throw new ValidationException("Refresh Token معتبر نیست.");

        string? dbUserId = token.Rows[0]["UserId"].ToString();

        if (string.IsNullOrEmpty(dbUserId) || dbUserId != userId)
            throw new ValidationException("توکن متعلق به این کاربر نیست.");

        bool RevokeRefreshToken = await DbConnectionFactory.DbInstance.Pr_RevokeAllRefreshTokens(dbUserId);

        if (!RevokeRefreshToken)
            throw new Exception("منقضی کردن توکن با خطا مواجه شد.");

        return true;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordRequest request, string userId)
    {
        string hashpass_Old = new PasswordService().HashPassword(request.OldPassword);
        string hashpass_New = new PasswordService().HashPassword(request.NewPassword);

        if (string.IsNullOrEmpty(hashpass_New) || string.IsNullOrEmpty(hashpass_Old))
            throw new ValidationException("رمز عبور کاربر معتبر نمی‌باشد.");

        if (string.IsNullOrEmpty(request.NewUserName))
            throw new ValidationException("نام کاربری معتبر نمی‌باشد.");

        string Res = await DbConnectionFactory.DbInstance.Pr_ChangePassword(userId, hashpass_Old, hashpass_New, request.NewUserName, 0);

        if (Res == "0")
            throw new ValidationException("تغییر رمز عبور با خطا مواجه شد.");
        else if (Res == "-1")
            throw new ValidationException("کاربر مورد نظر یافت نشد.");
        else if (Res == "-2")
            throw new ValidationException("نام کاربری یا رمز عبور تکراری می‌باشد.");
        else if (Res == "-500")
            throw new ValidationException("خطای غیر منتظره در دیتابیس");

        return true;
    }
}