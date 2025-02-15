using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Maya.Exchange.Services
{
    public interface ISecurityService
    {
        Task<string> GenerateJwtToken(string userId, string role);
        Task<bool> ValidateToken(string token);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
        string GenerateApiKey();
        bool ValidateKycStatus(string userId);
    }

    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _key;

        public SecurityService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
        }

        public async Task<string> GenerateJwtToken(string userId, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(_key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                tokenHandler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public bool VerifyPassword(string password, string hash)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hash;
        }

        public string GenerateApiKey()
        {
            var key = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            return Convert.ToBase64String(key);
        }

        public bool ValidateKycStatus(string userId)
        {
            // TODO: Implement KYC validation logic based on Maya-kyc.docx requirements
            // This should check user's KYC level and verification status
            // Return true if KYC is valid for the requested operation
            return true;
        }

        private string GenerateSecureRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(random);
            }

            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random[i] % chars.Length];
            }
            return new string(result);
        }
    }
}
