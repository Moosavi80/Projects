namespace DataAccess.DTOs.Login
{
    public class UserRefreshToken
    {
        public long Id { get; set; }

        public int UserId { get; set; }

        public string TokenHash { get; set; } = "";

        public DateTime ExpireDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Revoked { get; set; }

        public DateTime? RevokedDate { get; set; }

        public string? Device { get; set; }

        public string? IPAddress { get; set; }
    }
}
