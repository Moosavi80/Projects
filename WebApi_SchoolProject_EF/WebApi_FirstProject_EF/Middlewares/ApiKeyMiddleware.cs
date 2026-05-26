using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace WebApi_FirstProject_EF.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if ((context.Request.Path.Value ?? "").Contains("api"))
            {
                if (!context.Request.Headers.TryGetValue("X-Api-Key", out StringValues extractedApiKey) ||
                    extractedApiKey.FirstOrDefault() != _configuration.GetValue<string>("ApiKey"))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Api Key Is Not Valid.");
                    return;
                }
            }

            await _next(context);
        }
    }
}
