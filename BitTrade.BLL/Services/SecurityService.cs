using System.Security.Cryptography;
using System.Text;

namespace BitTrade.BLL.Services
{
    public class SecurityService : ISecurityService
    {
        public string GetRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[5];
                rng.GetBytes(randomBytes);

                StringBuilder stringBuilder = new StringBuilder(5);
                foreach (byte b in randomBytes)
                {
                    int index = b % chars.Length;
                    char randomChar = chars[index];
                    stringBuilder.Append(randomChar);
                }

                return stringBuilder.ToString();
            }
        }

        public string GetSHA256(string content)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {

                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes($"{content}"));

                // Convert byte array to a string
                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public bool ValidatePassword(string inputPassword, string userPassword, string salt)
        {
            return GetSHA256($"{inputPassword}{salt}") == userPassword;
        }
    }
}
