using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Maya.Exchange.Models;
using Maya.Exchange.Interfaces;
using Maya.Exchange.Data;

namespace Maya.Exchange.Services
{
    public class MayaDexService : IMayaDexService
    {
        private readonly IConfiguration _configuration;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IUserRepository _userRepo;
        private readonly IKycService _kycService;
        private readonly ICurrencyConversionService _conversionService;

        public MayaDexService(
            IConfiguration configuration,
            ITransactionRepository transactionRepo, 
            IUserRepository userRepo,
            IKycService kycService,
            ICurrencyConversionService conversionService)
        {
            _configuration = configuration;
            _transactionRepo = transactionRepo;
            _userRepo = userRepo;
            _kycService = kycService;
            _conversionService = conversionService;
        }

        public async Task<TransactionResult> ProcessTransaction(TransactionRequest request)
        {
            // Validate KYC status
            var kycStatus = await _kycService.ValidateKycStatus(request.UserId);
            if (!kycStatus.IsValid)
            {
                throw new UnauthorizedAccessException("KYC validation failed");
            }

            // Process based on transaction type
            switch (request.TransactionType)
            {
                case TransactionType.Send:
                    return await ProcessSendTransaction(request);
                
                case TransactionType.Receive:
                    return await ProcessReceiveTransaction(request);
                
                case TransactionType.Convert:
                    return await ProcessConversionTransaction(request);
                
                default:
                    throw new ArgumentException("Invalid transaction type");
            }
        }

        private async Task<TransactionResult> ProcessSendTransaction(TransactionRequest request)
        {
            // Validate balance
            var userBalance = await _userRepo.GetUserBalance(request.UserId);
            if (userBalance < request.Amount)
            {
                throw new InvalidOperationException("Insufficient balance");
            }

            // Process send transaction
            var transaction = new Transaction
            {
                UserId = request.UserId,
                Type = TransactionType.Send,
                Amount = request.Amount,
                Currency = request.Currency,
                Timestamp = DateTime.UtcNow
            };

            await _transactionRepo.CreateTransaction(transaction);
            await _userRepo.UpdateBalance(request.UserId, -request.Amount);

            return new TransactionResult
            {
                Success = true,
                TransactionId = transaction.Id,
                Message = "Transaction processed successfully"
            };
        }

        private async Task<TransactionResult> ProcessReceiveTransaction(TransactionRequest request)
        {
            // Process receive transaction
            var transaction = new Transaction
            {
                UserId = request.UserId,
                Type = TransactionType.Receive,
                Amount = request.Amount,
                Currency = request.Currency,
                Timestamp = DateTime.UtcNow
            };

            await _transactionRepo.CreateTransaction(transaction);
            await _userRepo.UpdateBalance(request.UserId, request.Amount);

            return new TransactionResult
            {
                Success = true,
                TransactionId = transaction.Id,
                Message = "Transaction processed successfully"
            };
        }

        private async Task<TransactionResult> ProcessConversionTransaction(TransactionRequest request)
        {
            // Get conversion rate and calculate converted amount
            var convertedAmount = await _conversionService.Convert(
                request.Amount,
                request.Currency,
                request.TargetCurrency
            );

            // Process conversion transaction
            var transaction = new Transaction
            {
                UserId = request.UserId,
                Type = TransactionType.Convert,
                Amount = request.Amount,
                Currency = request.Currency,
                TargetCurrency = request.TargetCurrency,
                ConvertedAmount = convertedAmount,
                Timestamp = DateTime.UtcNow
            };

            await _transactionRepo.CreateTransaction(transaction);
            await _userRepo.UpdateBalance(request.UserId, -request.Amount);
            await _userRepo.UpdateBalance(request.UserId, convertedAmount, request.TargetCurrency);

            return new TransactionResult
            {
                Success = true,
                TransactionId = transaction.Id,
                Message = "Conversion processed successfully"
            };
        }

        public async Task<IEnumerable<Transaction>> GetTransactionHistory(string userId)
        {
            return await _transactionRepo.GetTransactionsByUserId(userId);
        }

        public async Task<decimal> GetUserBalance(string userId, string currency)
        {
            return await _userRepo.GetUserBalance(userId, currency);
        }
    }
}
