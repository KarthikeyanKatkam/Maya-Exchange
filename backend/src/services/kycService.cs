using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MayaExchange.Models;
using MayaExchange.Exceptions;

namespace MayaExchange.Services
{
    public interface IKycService
    {
        Task<KycStatus> GetUserKycStatus(string userId);
        Task<bool> CheckKycStatus(string userId); 
        Task<KycSubmissionResult> SubmitKycDocuments(string userId, KycDocuments documents);
        Task<KycVerificationResult> VerifyKycDocuments(string userId);
        Task<List<KycDocument>> GetUserKycDocuments(string userId);
        Task<bool> UpdateKycStatus(string userId, KycStatus status);
        Task<KycLimits> GetUserKycLimits(string userId);
    }

    public class KycService : IKycService
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;
        private readonly ILogger<KycService> _logger;

        public KycService(
            IMongoDatabase database,
            IConfiguration configuration, 
            ILogger<KycService> logger)
        {
            _database = database;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<KycStatus> GetUserKycStatus(string userId)
        {
            try
            {
                var collection = _database.GetCollection<KycStatus>("kycStatus");
                var status = await collection.Find(x => x.UserId == userId).FirstOrDefaultAsync();
                return status ?? new KycStatus { UserId = userId, IsVerified = false };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting KYC status for user {userId}: {ex.Message}");
                throw new KycException("Failed to retrieve KYC status", ex);
            }
        }

        public async Task<bool> CheckKycStatus(string userId)
        {
            var status = await GetUserKycStatus(userId);
            return status.IsVerified;
        }

        public async Task<KycSubmissionResult> SubmitKycDocuments(string userId, KycDocuments documents)
        {
            try
            {
                var collection = _database.GetCollection<KycDocuments>("kycDocuments");
                await collection.InsertOneAsync(documents);

                await UpdateKycStatus(userId, new KycStatus 
                { 
                    UserId = userId,
                    IsVerified = false,
                    Status = "Pending",
                    SubmissionDate = DateTime.UtcNow
                });

                return new KycSubmissionResult
                {
                    Success = true,
                    Message = "KYC documents submitted successfully",
                    SubmissionId = documents.Id
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error submitting KYC documents for user {userId}: {ex.Message}");
                throw new KycException("Failed to submit KYC documents", ex);
            }
        }

        public async Task<KycVerificationResult> VerifyKycDocuments(string userId)
        {
            try
            {
                var documents = await GetUserKycDocuments(userId);
                if (documents == null || !documents.Any())
                {
                    return new KycVerificationResult
                    {
                        Success = false,
                        Message = "No KYC documents found"
                    };
                }

                // Implement document verification logic here
                var verificationPassed = true; // Replace with actual verification

                await UpdateKycStatus(userId, new KycStatus
                {
                    UserId = userId,
                    IsVerified = verificationPassed,
                    Status = verificationPassed ? "Verified" : "Failed",
                    VerificationDate = DateTime.UtcNow
                });

                return new KycVerificationResult
                {
                    Success = verificationPassed,
                    Message = verificationPassed ? "KYC verification successful" : "KYC verification failed"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error verifying KYC documents for user {userId}: {ex.Message}");
                throw new KycException("Failed to verify KYC documents", ex);
            }
        }

        public async Task<List<KycDocument>> GetUserKycDocuments(string userId)
        {
            try
            {
                var collection = _database.GetCollection<KycDocuments>("kycDocuments");
                var documents = await collection.Find(x => x.UserId == userId).FirstOrDefaultAsync();
                return documents?.Documents ?? new List<KycDocument>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving KYC documents for user {userId}: {ex.Message}");
                throw new KycException("Failed to retrieve KYC documents", ex);
            }
        }

        public async Task<bool> UpdateKycStatus(string userId, KycStatus status)
        {
            try
            {
                var collection = _database.GetCollection<KycStatus>("kycStatus");
                var result = await collection.ReplaceOneAsync(
                    x => x.UserId == userId,
                    status,
                    new ReplaceOptions { IsUpsert = true }
                );
                return result.ModifiedCount > 0 || result.UpsertedId != null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating KYC status for user {userId}: {ex.Message}");
                throw new KycException("Failed to update KYC status", ex);
            }
        }

        public async Task<KycLimits> GetUserKycLimits(string userId)
        {
            try
            {
                var status = await GetUserKycStatus(userId);
                return new KycLimits
                {
                    DailyTransactionLimit = status.IsVerified ? 1000000 : 50000,
                    MonthlyTransactionLimit = status.IsVerified ? 10000000 : 200000,
                    SingleTransactionLimit = status.IsVerified ? 500000 : 10000
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting KYC limits for user {userId}: {ex.Message}");
                throw new KycException("Failed to retrieve KYC limits", ex);
            }
        }
    }
}
