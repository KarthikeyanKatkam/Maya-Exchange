using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MayaExchange.Models;
using MayaExchange.Data;

namespace MayaExchange.Services
{
    public interface IAnalyticsService
    {
        Task<Dictionary<string, int>> GetUserActivityMetrics(string userId);
        Task<List<TransactionMetrics>> GetTransactionMetrics(DateTime startDate, DateTime endDate);
        Task<Dictionary<string, double>> GetCurrencyConversionStats();
        Task<KycMetrics> GetKycVerificationStats();
        Task LogUserActivity(string userId, string activity);
    }

    public class AnalyticsService : IAnalyticsService
    {
        private readonly ILogger<AnalyticsService> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IKycService _kycService;
        private readonly IDbContext _dbContext;

        public AnalyticsService(
            ILogger<AnalyticsService> logger,
            ITransactionService transactionService,
            IKycService kycService,
            IDbContext dbContext)
        {
            _logger = logger;
            _transactionService = transactionService;
            _kycService = kycService;
            _dbContext = dbContext;
        }

        public async Task<Dictionary<string, int>> GetUserActivityMetrics(string userId)
        {
            try
            {
                var metrics = new Dictionary<string, int>();
                var transactions = await _transactionService.GetUserTransactions(userId);
                
                metrics.Add("totalTransactions", transactions.Count);
                metrics.Add("successfulTransactions", transactions.Count(t => t.Status == "Completed"));
                metrics.Add("failedTransactions", transactions.Count(t => t.Status == "Failed"));

                return metrics;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting user activity metrics: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TransactionMetrics>> GetTransactionMetrics(DateTime startDate, DateTime endDate)
        {
            try
            {
                var metrics = await _dbContext.TransactionMetrics
                    .Where(t => t.Timestamp >= startDate && t.Timestamp <= endDate)
                    .ToListAsync();

                return metrics;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting transaction metrics: {ex.Message}");
                throw;
            }
        }

        public async Task<Dictionary<string, double>> GetCurrencyConversionStats()
        {
            try
            {
                var stats = new Dictionary<string, double>();
                var conversions = await _dbContext.CurrencyConversions.ToListAsync();

                stats.Add("totalVolume", conversions.Sum(c => c.Amount));
                stats.Add("averageAmount", conversions.Average(c => c.Amount));
                stats.Add("successRate", CalculateSuccessRate(conversions));

                return stats;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting currency conversion stats: {ex.Message}");
                throw;
            }
        }

        public async Task<KycMetrics> GetKycVerificationStats()
        {
            try
            {
                var kycStats = new KycMetrics
                {
                    TotalVerifications = await _dbContext.KycVerifications.CountAsync(),
                    PendingVerifications = await _dbContext.KycVerifications
                        .CountAsync(k => k.Status == "Pending"),
                    ApprovedVerifications = await _dbContext.KycVerifications
                        .CountAsync(k => k.Status == "Approved"),
                    RejectedVerifications = await _dbContext.KycVerifications
                        .CountAsync(k => k.Status == "Rejected")
                };

                return kycStats;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting KYC verification stats: {ex.Message}");
                throw;
            }
        }

        public async Task LogUserActivity(string userId, string activity)
        {
            try
            {
                var userActivity = new UserActivity
                {
                    UserId = userId,
                    Activity = activity,
                    Timestamp = DateTime.UtcNow
                };

                await _dbContext.UserActivities.AddAsync(userActivity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error logging user activity: {ex.Message}");
                throw;
            }
        }

        private double CalculateSuccessRate(List<CurrencyConversion> conversions)
        {
            if (!conversions.Any()) return 0;
            
            var successful = conversions.Count(c => c.Status == "Completed");
            return (double)successful / conversions.Count * 100;
        }
    }
}
