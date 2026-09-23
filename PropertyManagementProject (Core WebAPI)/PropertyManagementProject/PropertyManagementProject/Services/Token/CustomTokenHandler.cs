using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text.Encodings.Web;

public class CustomTokenHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder,
    ITokenService tokenService) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("Authorization", out var header))
            return Task.FromResult(AuthenticateResult.NoResult());

        var token = header.ToString().Replace("Bearer ", "").Trim();

        if (string.IsNullOrEmpty(token))
            return Task.FromResult(AuthenticateResult.NoResult());

        // ValidateAccessToken داخلش expiry چک میکنه
        System.Security.Claims.ClaimsPrincipal? principal = tokenService.ValidateAccessToken(token);

        if (principal is null)
        {
            // بفهمیم expired شده یا invalid
            var expiredPrincipal = tokenService.ValidateAccessToken(token, ignoreExpiry: true);

            if (expiredPrincipal is not null)
            {
                // توکن معتبره ولی منقضی شده
                Response.Headers.Append("Token-Expired", "true");
                return Task.FromResult(
                    AuthenticateResult.Fail("Token expired"));
            }

            return Task.FromResult(
                AuthenticateResult.Fail("Invalid token"));
        }

        AuthenticationTicket ticket = new AuthenticationTicket(principal, "CustomToken");
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }

    protected override Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        Response.ContentType = "application/json";
        return Task.CompletedTask;
    }

    protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
    {
        Response.StatusCode = StatusCodes.Status403Forbidden;
        Response.ContentType = "application/json";
        return Task.CompletedTask;
    }
}