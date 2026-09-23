using System.Security.Claims;

namespace ClipShare_Youtube_.Extensions
{
    public static class UserClaimsExtensions
    {
        public static string GetName(this ClaimsPrincipal principal)
        {
            return principal.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static bool GetRole(this ClaimsPrincipal principal)
        {
            string rl = principal.FindFirst(ClaimTypes.Role)?.Value;

            if (rl != null && rl == "Admin")
                return true;

            return false;
        }

        public static string GetNameIdentifier(this ClaimsPrincipal principal)
        {
            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
