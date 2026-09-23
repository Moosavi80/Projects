using DataAccess.DTOs.Login;
using DataAccess.Interfaces;
using DataAccess.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Common;
using PropertyManagementProject.Response.Exceptions;
using System.Security.Claims;

namespace PropertyManagementProject.Controllers.Auth
{
    [ApiController]
    [Route("api/v1/Auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(BaseResponse<LoginResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<LoginResponse>>> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
                string device = Request.Headers.UserAgent.ToString() ?? "";

                LoginResponse? result = await _authService.Login(request, ip, device);

                if (result != null)
                    await DbConnectionFactory.DbInstance.Pr_Ins_UserLogs(result.UserId, "0", "0", null, true, null, "ورود کاربر");
                
                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("Refresh")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(BaseResponse<LoginResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
                string device = Request.Headers.UserAgent.ToString() ?? "";

                LoginResponse? result = await _authService.RefreshToken(request, ip, device);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("Logout")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _authService.LogoutAsync(userId, request.RefreshToken);

                if (result)
                    await DbConnectionFactory.DbInstance.Pr_Ins_UserLogs(userId, "0", "1", null, true, null, "خروج کاربر");

                return Ok(ApiResponse.Success(result, "باموفقیت خارج شدید."));
            }
            catch { throw; }
        }

        [HttpPost("ChangePassword")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _authService.ChangePasswordAsync(request, userId);

                if (result)
                    await DbConnectionFactory.DbInstance.Pr_Ins_UserLogs(userId, "1", "0", null, true, null, "تغییر رمز عبور");

                return Ok(ApiResponse.Success(result, "رمز عبور با موفقیت تغییر کرد."));
            }
            catch { throw; }
        }

    }
}
