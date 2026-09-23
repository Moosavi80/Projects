namespace PropertyManagementProject.Response.Common
{
    public static class ApiResponse
    {
        public static BaseResponse<T> Success<T>(T result, string message = "")
        {
            return new BaseResponse<T>
            {
                StatusCode = StatusCodes.Status200OK,
                StatusMessage = message,
                Result = result
            };
        }

        public static BaseResponse<T?> Fail<T>(int statusCode, string message)
        {
            return new BaseResponse<T?>
            {
                StatusCode = statusCode,
                StatusMessage = message,
                Result = default
            };
        }
    }
}
