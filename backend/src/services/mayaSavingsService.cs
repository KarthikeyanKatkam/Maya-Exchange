using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Maya.Models;
using Maya.Data;
using Maya.Common;
using Maya.Services.Interfaces;

namespace Maya.Services
{
    public class MayaSavingsService : IMayaSavingsService
    {
        private readonly ILogger<MayaSavingsService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IKycService _kycService;

        public MayaSavingsService(
            ILogger<MayaSavingsService> logger,
            IUserRepository userRepository, 
            ITransactionRepository transactionRepository,
            IWalletRepository walletRepository,
            IKycService kycService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
            _kycService = kycService;
        }

        public async Task<SavingsAccount> CreateSavingsAccountAsync(string userId, string currency)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                    throw new NotFoundException("User not found");

                var kycStatus = await _kycService.GetUserKycStatusAsync(userId);
                if (!kycStatus.IsVerified)
                    throw new UnauthorizedException("KYC verification required");

                var account = new SavingsAccount
                {
                    UserId = userId,
                    Currency = currency,
                    Balance = 0,
                    InterestRate = GetInterestRate(currency),
                    CreatedAt = DateTime.UtcNow,
                    Status = AccountStatus.Active
                };

                await _walletRepository.CreateSavingsAccountAsync(account);
                _logger.LogInformation($"Savings account created for user {userId}");

                return account;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating savings account: {ex.Message}");
                throw;
            }
        }

        public async Task<decimal> GetSavingsBalanceAsync(string userId, string currency)
        {
            var account = await _walletRepository.GetSavingsAccountAsync(userId, currency);
            if (account == null)
                throw new NotFoundException("Savings account not found");

            return account.Balance;
        }

        public async Task<TransactionResult> DepositToSavingsAsync(string userId, string currency, decimal amount)
        {
            try
            {
                var account = await _walletRepository.GetSavingsAccountAsync(userId, currency);
                if (account == null)
                    throw new NotFoundException("Savings account not found");

                var transaction = new Transaction
                {
                    UserId = userId,
                    Type = TransactionType.SavingsDeposit,
                    Amount = amount,
                    Currency = currency,
                    Status = TransactionStatus.Pending,
                    Timestamp = DateTime.UtcNow
                };

                await _transactionRepository.CreateAsync(transaction);
                account.Balance += amount;
                await _walletRepository.UpdateSavingsAccountAsync(account);

                return new TransactionResult
                {
                    Success = true,
                    TransactionId = transaction.Id,
                    NewBalance = account.Balance
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing savings deposit: {ex.Message}");
                throw;
            }
        }

        private decimal GetInterestRate(string currency)
        {
            // Interest rates can be configured based on currency and market conditions
            return currency.ToUpper() switch
            {
                "PHP" => 0.04m, // 4% for PHP
                "USD" => 0.02m, // 2% for USD
                "EUR" => 0.01m, // 1% for EUR
                _ => 0.015m     // Default 1.5%
            };
        }
    }
}
