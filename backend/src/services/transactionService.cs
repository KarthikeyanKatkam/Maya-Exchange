using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Models;
using Maya.Exchange.Interfaces;
using Maya.Exchange.Enums;

namespace Maya.Exchange.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ILogger<TransactionService> _logger;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserService _userService;
        private readonly IKycService _kycService;
        private readonly ICurrencyConversionService _conversionService;

        public TransactionService(
            ILogger<TransactionService> logger,
            ITransactionRepository transactionRepository, 
            IUserService userService,
            IKycService kycService,
            ICurrencyConversionService conversionService)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
            _userService = userService;
            _kycService = kycService;
            _conversionService = conversionService;
        }

        public async Task<TransactionResult> ProcessTransaction(TransactionRequest request)
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

                // Validate transaction limits based on KYC level
                if (!await ValidateTransactionLimits(request))
                {
                    return new TransactionResult
                    {
                        Success = false,
                        Message = "Transaction limit exceeded"
                    };
                }

                // Process based on transaction type
                switch (request.TransactionType)
                {
                    case TransactionType.LocalToLocal:
                        return await ProcessLocalToLocalTransaction(request);
                    
                    case TransactionType.LocalToCrypto:
                        return await ProcessLocalToCryptoTransaction(request);
                    
                    case TransactionType.CryptoToLocal:
                        return await ProcessCryptoToLocalTransaction(request);
                    
                    case TransactionType.CryptoToCrypto:
                        return await ProcessCryptoToCryptoTransaction(request);
                    
                    default:
                        throw new ArgumentException("Invalid transaction type");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing transaction");
                return new TransactionResult
                {
                    Success = false,
                    Message = "Internal server error"
                };
            }
        }

        private async Task<bool> ValidateTransactionLimits(TransactionRequest request)
        {
            var userLimits = await _userService.GetUserTransactionLimits(request.UserId);
            var dailyTotal = await _transactionRepository.GetUserDailyTransactionTotal(request.UserId);
            
            return dailyTotal + request.Amount <= userLimits.DailyLimit;
        }

        private async Task<TransactionResult> ProcessLocalToLocalTransaction(TransactionRequest request)
        {
            var convertedAmount = await _conversionService.Convert(
                request.Amount,
                request.SourceCurrency,
                request.TargetCurrency
            );

            var transaction = new Transaction
            {
                UserId = request.UserId,
                Amount = request.Amount,
                ConvertedAmount = convertedAmount,
                SourceCurrency = request.SourceCurrency,
                TargetCurrency = request.TargetCurrency,
                TransactionType = TransactionType.LocalToLocal,
                Status = TransactionStatus.Completed,
                Timestamp = DateTime.UtcNow
            };

            await _transactionRepository.CreateTransaction(transaction);

            return new TransactionResult
            {
                Success = true,
                TransactionId = transaction.Id,
                ConvertedAmount = convertedAmount
            };
        }

        // Similar implementations for other transaction types...

        public async Task<IEnumerable<Transaction>> GetUserTransactions(string userId)
        {
            return await _transactionRepository.GetTransactionsByUserId(userId);
        }

        public async Task<Transaction> GetTransactionById(string transactionId)
        {
            return await _transactionRepository.GetTransactionById(transactionId);
        }
    }
}
