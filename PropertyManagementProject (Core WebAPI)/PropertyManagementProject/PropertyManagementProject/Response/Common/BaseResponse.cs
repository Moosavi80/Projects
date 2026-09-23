namespace PropertyManagementProject.Response.Common
{
    public class BaseResponse<T>
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
        public T? Result { get; set; }
    }
}
