namespace DataAccess.DTOs.Login
{
    public class LoginResponse
    {
        public required string UserId { get; set; }

        public required string UserName { get; set; }

        public string FullName { get; set; } = string.Empty;

        public required string AccessToken { get; set; }

        public required string RefreshToken { get; set; }

        public bool ChangePassword { get; set; } = false;


        //public DateTime AccessTokenExpireDate { get; set; }
    }
}
