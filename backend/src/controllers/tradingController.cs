using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;
using Maya.Exchange.Middleware;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradingController : ControllerBase
    {
        private readonly ILogger<TradingController> _logger;
        private readonly ITradingService _tradingService;
        private readonly IKycService _kycService;
        private readonly IWalletService _walletService;

        public TradingController(
            ILogger<TradingController> logger,
            ITradingService tradingService,
            IKycService kycService,
            IWalletService walletService)
        {
            _logger = logger;
            _tradingService = tradingService;
            _kycService = kycService;
            _walletService = walletService;
        }

        [HttpGet("markets")]
        public async Task<IActionResult> GetMarkets([FromQuery] MarketQueryParams queryParams)
        {
            try
            {
                var markets = await _tradingService.GetMarkets(queryParams);
                return Ok(markets);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving markets: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("order")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var kycStatus = await _kycService.ValidateKycStatus(userId);
                if (!kycStatus.IsValid)
                {
                    return BadRequest(new { message = "KYC verification required" });
                }

                var walletBalance = await _walletService.CheckBalance(userId, request.AssetId);
                if (!walletBalance.HasSufficientFunds)
                {
                    return BadRequest(new { message = "Insufficient funds" });
                }

                var order = await _tradingService.PlaceOrder(userId, request);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error placing order: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("orders")]
        [Authorize]
        public async Task<IActionResult> GetOrders([FromQuery] OrderQueryParams queryParams)
        {
            try
            {
                var userId = User.GetUserId();
                var orders = await _tradingService.GetOrders(userId, queryParams);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving orders: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpDelete("order/{orderId}")]
        [Authorize]
        public async Task<IActionResult> CancelOrder(string orderId)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _tradingService.CancelOrder(userId, orderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error canceling order: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("orderbook/{marketId}")]
        public async Task<IActionResult> GetOrderBook(string marketId, [FromQuery] OrderBookQueryParams queryParams)
        {
            try
            {
                var orderBook = await _tradingService.GetOrderBook(marketId, queryParams);
                return Ok(orderBook);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving order book: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("trades/{marketId}")]
        public async Task<IActionResult> GetMarketTrades(string marketId, [FromQuery] TradeQueryParams queryParams)
        {
            try
            {
                var trades = await _tradingService.GetMarketTrades(marketId, queryParams);
                return Ok(trades);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving market trades: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }
    }
}
