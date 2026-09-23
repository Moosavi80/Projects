namespace DataAccess.Models.Login
{
    public class LogoutRequest
    {
        public required string RefreshToken { get; set; }
    }
}
