using PropertyManagementProject.Response.Common;
using PropertyManagementProject.Response.Exceptions;
using System.Text.Json;
using ErrorLogs;
using ErrorLogs.FileLogger;

namespace PropertyManagementProject.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly FileLoggerService _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = new FileLoggerService();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                _logger.LogException(ex, $"AppException - Path: {context.Request.Path}");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.StatusCode;

                BaseResponse<object?> response = ApiResponse.Fail<object>(ex.StatusCode, ex.Message);

                await context.Response.WriteAsync
                (
                    JsonSerializer.Serialize(response)
                );
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"UnhandledException - Path: {context.Request.Path}");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                BaseResponse<object?> response = ApiResponse.Fail<object>
                (
                    StatusCodes.Status500InternalServerError,
                    "خطای داخلی سرور رخ داده است."
                );

                await context.Response.WriteAsync
                (
                    JsonSerializer.Serialize(response)
                );
            }
        }
    }
}