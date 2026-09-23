namespace DataAccess.Models.Login
{
    public class UserDto
    {
        public required string UserId { get; set; }

        public required string UserName { get; set; }

        public required string Password { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string NationalNumber { get; set; } = string.Empty;

        public string UserType { get; set; } = string.Empty;

        public string UserGroup { get; set; } = string.Empty;
    }
}
