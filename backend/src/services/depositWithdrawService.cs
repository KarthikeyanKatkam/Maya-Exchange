using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Models;
using Maya.Exchange.Interfaces;
using Maya.Exchange.Common;
using Maya.Exchange.Data;

namespace Maya.Exchange.Services
{
    public class DepositWithdrawService : IDepositWithdrawService
    {
        private readonly ILogger<DepositWithdrawService> _logger;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IUserRepository _userRepo;
        private readonly IKycService _kycService;
        private readonly IWalletService _walletService;

        public DepositWithdrawService(
            ILogger<DepositWithdrawService> logger,
            ITransactionRepository transactionRepo,
            IUserRepository userRepo, 
            IKycService kycService,
            IWalletService walletService)
        {
            _logger = logger;
            _transactionRepo = transactionRepo;
            _userRepo = userRepo;
            _kycService = kycService;
            _walletService = walletService;
        }

        public async Task<TransactionResult> ProcessDeposit(DepositRequest request)
        {
            try
            {
                // Validate KYC status
                var kycStatus = await _kycService.ValidateKycStatus(request.UserId);
                if (!kycStatus.IsValid)
                {
                    return new TransactionResult 
                    { 
                        Success = false,
                        Message = "KYC validation failed"
                    };
                }

                // Validate deposit amount and limits
                if (!ValidateDepositAmount(request.Amount, request.Currency))
                {
                    return new TransactionResult
                    {
                        Success = false,
                        Message = "Invalid deposit amount or limit exceeded"
                    };
                }

                // Process the deposit
                var transaction = new Transaction
                {
                    UserId = request.UserId,
                    Type = TransactionType.Deposit,
                    Amount = request.Amount,
                    Currency = request.Currency,
                    Status = TransactionStatus.Pending,
                    Timestamp = DateTime.UtcNow
                };

                await _transactionRepo.CreateTransaction(transaction);
                await _walletService.CreditWallet(request.UserId, request.Amount, request.Currency);

                return new TransactionResult
                {
                    Success = true,
                    TransactionId = transaction.Id,
                    Message = "Deposit processed successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing deposit");
                throw;
            }
        }

        public async Task<TransactionResult> ProcessWithdrawal(WithdrawalRequest request)
        {
            try
            {
                // Validate KYC status
                var kycStatus = await _kycService.ValidateKycStatus(request.UserId);
                if (!kycStatus.IsValid)
                {
                    return new TransactionResult
                    {
                        Success = false,
                        Message = "KYC validation failed"
                    };
                }

                // Check balance and validate withdrawal amount
                var balance = await _walletService.GetBalance(request.UserId, request.Currency);
                if (balance < request.Amount)
                {
                    return new TransactionResult
                    {
                        Success = false,
                        Message = "Insufficient balance"
                    };
                }

                // Process the withdrawal
                var transaction = new Transaction
                {
                    UserId = request.UserId,
                    Type = TransactionType.Withdrawal,
                    Amount = request.Amount,
                    Currency = request.Currency,
                    Status = TransactionStatus.Pending,
                    Timestamp = DateTime.UtcNow
                };

                await _transactionRepo.CreateTransaction(transaction);
                await _walletService.DebitWallet(request.UserId, request.Amount, request.Currency);

                return new TransactionResult
                {
                    Success = true,
                    TransactionId = transaction.Id,
                    Message = "Withdrawal processed successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing withdrawal");
                throw;
            }
        }

        private bool ValidateDepositAmount(decimal amount, string currency)
        {
            // Implement deposit validation logic based on currency type and limits
            if (amount <= 0)
                return false;

            // Add additional validation rules based on currency type
            switch (currency.ToUpper())
            {
                case "BTC":
                    return amount <= 10.0m; // Example BTC deposit limit
                case "ETH":
                    return amount <= 100.0m; // Example ETH deposit limit
                case "USD":
                    return amount <= 50000.0m; // Example USD deposit limit
                default:
                    return amount <= 10000.0m; // Default limit for other currencies
            }
        }
    }
}
