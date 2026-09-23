namespace PropertyManagementProject.Services.Token
{
    public class PasswordService
    {
        public string HashPassword(string password)
        {
            const ulong offset = 14695981039346656037;
            const ulong prime = 1099511628211;

            ulong hash = offset;

            foreach (char c in password)
            {
                hash ^= c;
                hash *= prime;
            }

            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] result = new char[10];

            for (int i = 9; i >= 0; i--)
            {
                result[i] = chars[(int)(hash % 36)];
                hash /= 36;
            }

            return new string(result);
        }

        public bool VerifyPassword(string password, string encodedPassword)
        {
            return HashPassword(password).Equals(encodedPassword, StringComparison.Ordinal);
        }
    }
}
