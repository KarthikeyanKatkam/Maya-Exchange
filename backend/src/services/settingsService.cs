using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Maya.Exchange.Models;
using Maya.Exchange.Data;
using Maya.Exchange.Utils;

namespace Maya.Exchange.Services
{
    public interface ISettingsService
    {
        Task<UserSettings> GetUserSettingsAsync(string userId);
        Task UpdateUserSettingsAsync(string userId, UserSettings settings);
        Task<SystemSettings> GetSystemSettingsAsync();
        Task UpdateSystemSettingsAsync(SystemSettings settings);
        Task<KycSettings> GetKycSettingsAsync();
        Task UpdateKycSettingsAsync(KycSettings settings);
    }

    public class SettingsService : ISettingsService
    {
        private readonly IConfiguration _configuration;
        private readonly ISettingsRepository _settingsRepository;
        private readonly ILogger<SettingsService> _logger;

        public SettingsService(
            IConfiguration configuration,
            ISettingsRepository settingsRepository,
            ILogger<SettingsService> logger)
        {
            _configuration = configuration;
            _settingsRepository = settingsRepository;
            _logger = logger;
        }

        public async Task<UserSettings> GetUserSettingsAsync(string userId)
        {
            try
            {
                var settings = await _settingsRepository.GetUserSettingsAsync(userId);
                return settings ?? new UserSettings 
                {
                    UserId = userId,
                    Language = "en",
                    Theme = "light",
                    NotificationsEnabled = true,
                    TwoFactorEnabled = false
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user settings for user {UserId}", userId);
                throw;
            }
        }

        public async Task UpdateUserSettingsAsync(string userId, UserSettings settings)
        {
            try
            {
                settings.UserId = userId;
                await _settingsRepository.UpdateUserSettingsAsync(settings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user settings for user {UserId}", userId);
                throw;
            }
        }

        public async Task<SystemSettings> GetSystemSettingsAsync()
        {
            try
            {
                return await _settingsRepository.GetSystemSettingsAsync() ?? new SystemSettings
                {
                    MaintenanceMode = false,
                    MaxTransactionLimit = decimal.Parse(_configuration["DefaultMaxTransactionLimit"]),
                    MinTransactionLimit = decimal.Parse(_configuration["DefaultMinTransactionLimit"]),
                    SupportedCurrencies = new[] { "USD", "EUR", "BTC", "ETH" },
                    KycRequired = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting system settings");
                throw;
            }
        }

        public async Task UpdateSystemSettingsAsync(SystemSettings settings)
        {
            try
            {
                await _settingsRepository.UpdateSystemSettingsAsync(settings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating system settings");
                throw;
            }
        }

        public async Task<KycSettings> GetKycSettingsAsync()
        {
            try
            {
                return await _settingsRepository.GetKycSettingsAsync() ?? new KycSettings
                {
                    RequiredDocuments = new[] { "ID", "ProofOfAddress", "Selfie" },
                    MaxVerificationAttempts = 3,
                    VerificationTimeout = TimeSpan.FromDays(7),
                    MinimumAge = 18,
                    RequiredVerificationLevel = KycLevel.Advanced
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting KYC settings");
                throw;
            }
        }

        public async Task UpdateKycSettingsAsync(KycSettings settings)
        {
            try
            {
                await _settingsRepository.UpdateKycSettingsAsync(settings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating KYC settings");
                throw;
            }
        }
    }
}
