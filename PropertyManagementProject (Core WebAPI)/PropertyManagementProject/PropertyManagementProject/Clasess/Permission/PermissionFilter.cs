using DataAccess.Interfaces;
using ErrorLogs.FileLogger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Common;
using System.Security;

namespace PropertyManagementProject.Clasess.Permission
{
    public class PermissionFilter : IAuthorizationFilter
    {
        private readonly string[] _permission;

        public PermissionFilter(string[] permissions)
        {
            _permission = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            System.Security.Claims.ClaimsPrincipal user = context.HttpContext.User;

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            string? userId = user.FindFirst("UI")?.Value;
            string? userType = user.FindFirst("UT")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new UnauthorizedResult();
                new FileLoggerService().LogException(null, "PermissionFilter::OnAuthorization()::UserId");
                return;
            }

            if (string.IsNullOrEmpty(userType))
            {
                context.Result = new UnauthorizedResult();
                new FileLoggerService().LogException(null, "PermissionFilter::OnAuthorization()::UserType");
                return;
            }

            if (userType == "1")//Admin
                return;

            foreach (string permission in _permission)
            {
                bool hasPermission = DbConnectionFactory.DbInstance.Pr_HasPermission_ForUser(userId, permission);

                if (hasPermission)
                    return;
            }

            context.Result = new ObjectResult
            (
                new BaseResponse<string>
                {
                    StatusCode = 403,
                    StatusMessage = "کاربر گرامی دسترسی شما به این بخش محدود شده است.",
                    Result = null
                }
            )
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
    }
}