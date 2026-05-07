namespace ClipShare_Youtube_.ViewModels
{
    public class ApiResponse
    {
        public ApiResponse() { }

        public ApiResponse(int statusCode, string tittle, string message, object result = null)
        {
            StatusCode = statusCode;

            if (!string.IsNullOrEmpty(tittle))
                Tittle = tittle;
            else
                Tittle = SetDefaultValue(statusCode);

            if (!string.IsNullOrEmpty(message))
                Message = message;
            else
                Message = SetDefaultValue(statusCode);

            this.result = result;
            IsSuccess = false;

            if (statusCode == 200)
                IsSuccess = true;
        }

        public int StatusCode { get; set; }
        public string Tittle { get; set; }
        public string Message { get; set; }
        public object result { get; set; }
        public bool IsSuccess { get; set; }


        private string SetDefaultValue(int status)
        {
            return status switch
            {
                200 => "Success",
                201 => "Success",
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => ""
            };
        }
    }
}
