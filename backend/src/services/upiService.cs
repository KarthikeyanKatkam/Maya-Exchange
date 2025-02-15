using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Models;
using Maya.Exchange.Data;
using Maya.Exchange.Common;

namespace Maya.Exchange.Services
{
    public interface IUpiService
    {
        Task<UpiTransaction> InitiateUpiTransaction(UpiTransactionRequest request);
        Task<UpiTransaction> VerifyUpiTransaction(string transactionId);
        Task<List<UpiTransaction>> GetUserUpiTransactions(string userId);
        Task<UpiTransaction> GetTransactionById(string transactionId);
        Task<bool> ValidateUpiId(string upiId);
    }

    public class UpiService : IUpiService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<UpiService> _logger;
        private readonly IDbContext _dbContext;
        private readonly IUserService _userService;
        private readonly IKycService _kycService;
        private readonly IWalletService _walletService;

        public UpiService(
            IConfiguration config,
            ILogger<UpiService> logger,
            IDbContext dbContext,
            IUserService userService,
            IKycService kycService,
            IWalletService walletService)
        {
            _config = config;
            _logger = logger;
            _dbContext = dbContext;
            _userService = userService;
            _kycService = kycService;
            _walletService = walletService;
        }

        public async Task<UpiTransaction> InitiateUpiTransaction(UpiTransactionRequest request)
        {
            // Validate KYC status
            var kycStatus = await _kycService.GetUserKycStatus(request.UserId);
            if (!kycStatus.IsVerified)
            {
                throw new UnauthorizedException("KYC verification required for UPI transactions");
            }

            // Validate UPI ID
            if (!await ValidateUpiId(request.UpiId))
            {
                throw new ValidationException("Invalid UPI ID");
            }

            // Create transaction
            var transaction = new UpiTransaction
            {
                Id = Guid.NewGuid().ToString(),
                UserId = request.UserId,
                Amount = request.Amount,
                UpiId = request.UpiId,
                Status = TransactionStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dbContext.UpiTransactions.InsertOneAsync(transaction);
            
            // Update wallet balance
            await _walletService.UpdateBalance(request.UserId, request.Amount, TransactionType.Upi);

            return transaction;
        }

        public async Task<UpiTransaction> VerifyUpiTransaction(string transactionId)
        {
            var transaction = await _dbContext.UpiTransactions
                .Find(t => t.Id == transactionId)
                .FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new NotFoundException("Transaction not found");
            }

            // Verify transaction status with UPI provider
            // Implementation depends on UPI provider's API

            transaction.Status = TransactionStatus.Completed;
            transaction.UpdatedAt = DateTime.UtcNow;

            await _dbContext.UpiTransactions.ReplaceOneAsync(
                t => t.Id == transactionId,
                transaction
            );

            return transaction;
        }

        public async Task<List<UpiTransaction>> GetUserUpiTransactions(string userId)
        {
            return await _dbContext.UpiTransactions
                .Find(t => t.UserId == userId)
                .SortByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<UpiTransaction> GetTransactionById(string transactionId)
        {
            var transaction = await _dbContext.UpiTransactions
                .Find(t => t.Id == transactionId)
                .FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new NotFoundException("Transaction not found");
            }

            return transaction;
        }

        public async Task<bool> ValidateUpiId(string upiId)
        {
            // Basic UPI ID validation
            if (string.IsNullOrEmpty(upiId))
                return false;

            // UPI ID format validation
            var upiRegex = @"^[\w\.\-]+@[\w\.\-]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(upiId, upiRegex);
        }
    }
}
