using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Models;
using Maya.Exchange.Interfaces;
using Maya.Exchange.Data;
using Maya.Exchange.Common;

namespace Maya.Exchange.Services
{
    public class TradingService : ITradingService
    {
        private readonly ILogger<TradingService> _logger;
        private readonly ITradeRepository _tradeRepository;
        private readonly IUserService _userService;
        private readonly IKycService _kycService;
        private readonly ICurrencyConverter _currencyConverter;

        public TradingService(
            ILogger<TradingService> logger,
            ITradeRepository tradeRepository, 
            IUserService userService,
            IKycService kycService,
            ICurrencyConverter currencyConverter)
        {
            _logger = logger;
            _tradeRepository = tradeRepository;
            _userService = userService;
            _kycService = kycService;
            _currencyConverter = currencyConverter;
        }

        public async Task<TradeResult> ExecuteTradeAsync(TradeRequest request)
        {
            try
            {
                // Validate KYC status
                var kycStatus = await _kycService.ValidateKycStatusAsync(request.UserId);
                if (!kycStatus.IsValid)
                {
                    throw new TradingException("KYC validation failed");
                }

                // Validate user balance
                var userBalance = await _userService.GetUserBalanceAsync(request.UserId, request.SourceCurrency);
                if (userBalance < request.Amount)
                {
                    throw new InsufficientFundsException("Insufficient balance for trade");
                }

                // Calculate conversion rate and fees
                var conversionRate = await _currencyConverter.GetConversionRateAsync(
                    request.SourceCurrency,
                    request.TargetCurrency
                );

                var fees = CalculateTradingFees(request.Amount, request.TradeType);
                var convertedAmount = (request.Amount - fees) * conversionRate;

                // Execute trade
                var trade = new Trade
                {
                    UserId = request.UserId,
                    SourceCurrency = request.SourceCurrency,
                    TargetCurrency = request.TargetCurrency,
                    Amount = request.Amount,
                    ConvertedAmount = convertedAmount,
                    Fees = fees,
                    Rate = conversionRate,
                    Status = TradeStatus.Pending,
                    Timestamp = DateTime.UtcNow
                };

                // Save trade record
                await _tradeRepository.CreateTradeAsync(trade);

                // Update user balances
                await _userService.UpdateBalanceAsync(request.UserId, request.SourceCurrency, -request.Amount);
                await _userService.UpdateBalanceAsync(request.UserId, request.TargetCurrency, convertedAmount);

                trade.Status = TradeStatus.Completed;
                await _tradeRepository.UpdateTradeAsync(trade);

                return new TradeResult
                {
                    TradeId = trade.Id,
                    Status = trade.Status,
                    SourceAmount = request.Amount,
                    TargetAmount = convertedAmount,
                    Fees = fees,
                    Rate = conversionRate,
                    Timestamp = trade.Timestamp
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing trade for user {UserId}", request.UserId);
                throw;
            }
        }

        private decimal CalculateTradingFees(decimal amount, TradeType tradeType)
        {
            // Fee calculation logic based on trade type and amount
            var baseFee = tradeType switch
            {
                TradeType.LocalToLocal => 0.001m,  // 0.1%
                TradeType.LocalToCrypto => 0.002m, // 0.2%
                TradeType.CryptoToLocal => 0.002m, // 0.2%
                TradeType.CryptoToCrypto => 0.003m,// 0.3%
                _ => throw new ArgumentException("Invalid trade type")
            };

            return amount * baseFee;
        }

        public async Task<TradeHistory> GetTradeHistoryAsync(string userId, int page = 1, int pageSize = 20)
        {
            return await _tradeRepository.GetTradeHistoryAsync(userId, page, pageSize);
        }

        public async Task<Trade> GetTradeByIdAsync(string tradeId)
        {
            return await _tradeRepository.GetTradeByIdAsync(tradeId);
        }
    }
}
