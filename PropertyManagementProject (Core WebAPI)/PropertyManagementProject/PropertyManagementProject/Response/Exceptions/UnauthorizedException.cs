namespace PropertyManagementProject.Response.Exceptions
{
    public sealed class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message)
            : base(message, StatusCodes.Status401Unauthorized)
        {
        }
    }
}
