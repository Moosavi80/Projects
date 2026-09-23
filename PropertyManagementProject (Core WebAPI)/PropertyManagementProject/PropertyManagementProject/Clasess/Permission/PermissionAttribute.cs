using Microsoft.AspNetCore.Mvc;

namespace PropertyManagementProject.Clasess.Permission
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(params string[] permissions)
        : base(typeof(PermissionFilter))
        {
            Arguments = new object[]
            {
                permissions
            };
        }
    }
}
