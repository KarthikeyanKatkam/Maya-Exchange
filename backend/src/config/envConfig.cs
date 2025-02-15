using Microsoft.Extensions.Configuration;
using System;

namespace Maya.Exchange.Config
{
    public class EnvConfig
    {
        private readonly IConfiguration _configuration;
        
        public EnvConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetEnvironment()
        {
            return _configuration["Environment"] ?? "Development";
        }

        public bool IsProduction()
        {
            return GetEnvironment().Equals("Production", StringComparison.OrdinalIgnoreCase);
        }

        public bool IsDevelopment() 
        {
            return GetEnvironment().Equals("Development", StringComparison.OrdinalIgnoreCase);
        }

        public bool IsStaging()
        {
            return GetEnvironment().Equals("Staging", StringComparison.OrdinalIgnoreCase);
        }

        public bool IsTestEnvironment()
        {
            return GetEnvironment().Equals("Test", StringComparison.OrdinalIgnoreCase);
        }

        public string GetApiUrl()
        {
            return _configuration["Api:BaseUrl"];
        }

        public string GetFrontendUrl() 
        {
            return _configuration["Frontend:BaseUrl"];
        }

        public int GetApiPort()
        {
            return int.Parse(_configuration["Api:Port"]);
        }

        public string GetLogLevel()
        {
            return _configuration["Logging:LogLevel:Default"] ?? "Information";
        }

        public string GetLogFilePath()
        {
            return _configuration["Logging:FilePath"];
        }

        public bool GetEnableCors()
        {
            return bool.Parse(_configuration["Api:EnableCors"] ?? "true");
        }

        public string[] GetAllowedOrigins()
        {
            return _configuration.GetSection("Api:AllowedOrigins").Get<string[]>();
        }

        public string GetJwtSecret()
        {
            return _configuration["Jwt:Secret"];
        }

        public int GetJwtExpirationMinutes()
        {
            return int.Parse(_configuration["Jwt:ExpirationMinutes"] ?? "60");
        }

        public string GetSmtpHost()
        {
            return _configuration["Email:SmtpHost"];
        }

        public int GetSmtpPort()
        {
            return int.Parse(_configuration["Email:SmtpPort"]);
        }

        public string GetSmtpUsername()
        {
            return _configuration["Email:Username"];
        }

        public string GetSmtpPassword()
        {
            return _configuration["Email:Password"];
        }

        public bool GetSmtpUseSsl()
        {
            return bool.Parse(_configuration["Email:UseSsl"] ?? "true");
        }

        public string GetSupportEmail()
        {
            return _configuration["Email:SupportEmail"];
        }
    }
}
