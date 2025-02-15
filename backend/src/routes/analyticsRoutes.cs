using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Maya.Exchange.Models;
using Maya.Exchange.Services;
using Maya.Exchange.Controllers;

namespace Maya.Exchange.Routes
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AnalyticsRoutes : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsRoutes(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet("trading-volume")]
        public async Task<IActionResult> GetTradingVolume([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var volume = await _analyticsService.GetTradingVolume(startDate, endDate);
            return Ok(volume);
        }

        [HttpGet("user-activity")]
        public async Task<IActionResult> GetUserActivity([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var activity = await _analyticsService.GetUserActivity(startDate, endDate);
            return Ok(activity);
        }

        [HttpGet("transaction-metrics")]
        public async Task<IActionResult> GetTransactionMetrics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var metrics = await _analyticsService.GetTransactionMetrics(startDate, endDate);
            return Ok(metrics);
        }

        [HttpGet("currency-pairs")]
        public async Task<IActionResult> GetCurrencyPairMetrics([FromQuery] string baseCurrency, [FromQuery] string quoteCurrency)
        {
            var metrics = await _analyticsService.GetCurrencyPairMetrics(baseCurrency, quoteCurrency);
            return Ok(metrics);
        }

        [HttpGet("kyc-statistics")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetKycStatistics()
        {
            var stats = await _analyticsService.GetKycStatistics();
            return Ok(stats);
        }

        [HttpGet("order-book-depth")]
        public async Task<IActionResult> GetOrderBookDepth([FromQuery] string baseCurrency, [FromQuery] string quoteCurrency)
        {
            var depth = await _analyticsService.GetOrderBookDepth(baseCurrency, quoteCurrency);
            return Ok(depth);
        }

        [HttpGet("trade-history")]
        public async Task<IActionResult> GetTradeHistory([FromQuery] string userId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var history = await _analyticsService.GetTradeHistory(userId, startDate, endDate);
            return Ok(history);
        }

        [HttpGet("user-balance-history")]
        public async Task<IActionResult> GetUserBalanceHistory([FromQuery] string userId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var balanceHistory = await _analyticsService.GetUserBalanceHistory(userId, startDate, endDate);
            return Ok(balanceHistory);
        }
    }
}
