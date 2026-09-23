using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClipShare_Youtube_.Utility
{
    public static class SD
    {
        public static string UserName { get; set; } = "";
        public static string UserRole { get; set; } = "";
        public static string UserId { get; set; } = "";

        public static string IsActive(this IHtmlHelper html, string Controller, string Action, string cssClass = "active")
        {
            Microsoft.AspNetCore.Routing.RouteData routeData = html.ViewContext.RouteData;
            string routeAction = routeData.Values["action"]?.ToString();
            string routeController = routeData.Values["controller"]?.ToString();

            if (Controller == routeController && Action == routeAction)
                return cssClass;

            return string.Empty;
        }
    }
}
