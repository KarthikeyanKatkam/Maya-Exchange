using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Maya.Exchange.Utils
{
    public static class CryptoHelpers
    {
        // Generate random salt for password hashing
        public static string GenerateSalt(int length = 32)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[length];
                rng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        // Hash password with salt using PBKDF2
        public static string HashPassword(string password, string salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000))
            {
                var hash = pbkdf2.GetBytes(32);
                return Convert.ToBase64String(hash);
            }
        }

        // Verify password against stored hash
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var computedHash = HashPassword(password, storedSalt);
            return computedHash == storedHash;
        }

        // Generate random API key
        public static string GenerateApiKey(int length = 32)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[length];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes)
                    .Replace("/", "_")
                    .Replace("+", "-")
                    .Replace("=", "");
            }
        }

        // Encrypt sensitive data
        public static string EncryptData(string data, string key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor())
                {
                    var plainBytes = Encoding.UTF8.GetBytes(data);
                    var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                    var combined = new byte[aes.IV.Length + cipherBytes.Length];
                    Array.Copy(aes.IV, 0, combined, 0, aes.IV.Length);
                    Array.Copy(cipherBytes, 0, combined, aes.IV.Length, cipherBytes.Length);
                    return Convert.ToBase64String(combined);
                }
            }
        }

        // Decrypt sensitive data
        public static string DecryptData(string encryptedData, string key)
        {
            var combined = Convert.FromBase64String(encryptedData);
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                var iv = new byte[aes.BlockSize / 8];
                var cipherBytes = new byte[combined.Length - iv.Length];
                Array.Copy(combined, iv, iv.Length);
                Array.Copy(combined, iv.Length, cipherBytes, 0, cipherBytes.Length);
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor())
                {
                    var plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    return Encoding.UTF8.GetString(plainBytes);
                }
            }
        }

        // Generate wallet address
        public static string GenerateWalletAddress()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var privateKey = new byte[32];
                rng.GetBytes(privateKey);
                return "0x" + BitConverter.ToString(privateKey).Replace("-", "").ToLower();
            }
        }

        // Generate transaction hash
        public static string GenerateTransactionHash(string data)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
                return "0x" + BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
