using Microsoft.Extensions.Configuration;
using System;

namespace Maya.Exchange.Config
{
    public class SecurityConfig
    {
        private readonly IConfiguration _configuration;
        
        public SecurityConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetEncryptionKey()
        {
            return _configuration["Security:EncryptionKey"];
        }

        public string GetInitializationVector()
        {
            return _configuration["Security:InitializationVector"];
        }

        public int GetPasswordMinLength()
        {
            return int.Parse(_configuration["Security:PasswordMinLength"] ?? "8");
        }

        public bool GetRequireUppercase()
        {
            return bool.Parse(_configuration["Security:RequireUppercase"] ?? "true");
        }

        public bool GetRequireLowercase()
        {
            return bool.Parse(_configuration["Security:RequireLowercase"] ?? "true");
        }

        public bool GetRequireNumbers()
        {
            return bool.Parse(_configuration["Security:RequireNumbers"] ?? "true");
        }

        public bool GetRequireSpecialCharacters()
        {
            return bool.Parse(_configuration["Security:RequireSpecialCharacters"] ?? "true");
        }

        public int GetMaxFailedLoginAttempts()
        {
            return int.Parse(_configuration["Security:MaxFailedLoginAttempts"] ?? "5");
        }

        public int GetLockoutDurationMinutes()
        {
            return int.Parse(_configuration["Security:LockoutDurationMinutes"] ?? "30");
        }

        public int GetSessionTimeoutMinutes()
        {
            return int.Parse(_configuration["Security:SessionTimeoutMinutes"] ?? "30");
        }

        public bool GetEnableTwoFactorAuth()
        {
            return bool.Parse(_configuration["Security:EnableTwoFactorAuth"] ?? "true");
        }

        public string GetTwoFactorProvider()
        {
            return _configuration["Security:TwoFactorProvider"] ?? "Authenticator";
        }

        public int GetTwoFactorCodeLength()
        {
            return int.Parse(_configuration["Security:TwoFactorCodeLength"] ?? "6");
        }

        public int GetTwoFactorCodeExpiryMinutes()
        {
            return int.Parse(_configuration["Security:TwoFactorCodeExpiryMinutes"] ?? "5");
        }

        public string GetIpRateLimitingPolicy()
        {
            return _configuration["Security:IpRateLimitingPolicy"];
        }

        public int GetMaxRequestsPerMinute()
        {
            return int.Parse(_configuration["Security:MaxRequestsPerMinute"] ?? "60");
        }

        public string[] GetAllowedFileTypes()
        {
            return _configuration.GetSection("Security:AllowedFileTypes").Get<string[]>() ?? 
                   new string[] { ".jpg", ".jpeg", ".png", ".pdf" };
        }

        public long GetMaxFileUploadSize()
        {
            return long.Parse(_configuration["Security:MaxFileUploadSize"] ?? "10485760"); // Default 10MB
        }
    }
}
