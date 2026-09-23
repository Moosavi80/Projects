namespace WebApi_FirstProject_EF.Response
{
    public class BaseResponse
    {
        public BaseResponse(int status = 200, string message = "")
        {
            StatusCode = status;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IResult Toresult() => TypedResults.Json(this, statusCode: StatusCode);
    }

    public class BaseResponse<T> : BaseResponse
    {
        public BaseResponse(T? result, int status = 200, string message = "") : base(status, message)
        {
            Result = result;
        }

        public T? Result { get; set; }
    }
}
