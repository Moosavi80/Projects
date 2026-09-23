namespace PropertyManagementProject.Response.Exceptions
{
    public sealed class ConflictException : AppException
    {
        public ConflictException(string message)
            : base(message, StatusCodes.Status409Conflict)
        {
        }
    }   
}
