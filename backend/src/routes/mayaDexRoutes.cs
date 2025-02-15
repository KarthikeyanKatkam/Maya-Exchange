using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Models;
using MayaExchange.Services;
using MayaExchange.Middleware;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/dex")]
    public class MayaDexRoutes : ControllerBase
    {
        private readonly IDexService _dexService;
        private readonly IKycService _kycService;
        private readonly IAuthenticationService _authService;

        public MayaDexRoutes(
            IDexService dexService,
            IKycService kycService, 
            IAuthenticationService authService)
        {
            _dexService = dexService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpGet("pairs")]
        [Authorize]
        public async Task<IActionResult> GetTradingPairs()
        {
            try
            {
                var pairs = await _dexService.GetTradingPairs();
                return Ok(pairs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("trade")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> ExecuteTrade([FromBody] TradeRequest request)
        {
            try
            {
                var userId = _authService.GetCurrentUserId();
                var kycStatus = await _kycService.GetUserKycStatus(userId);
                
                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required for trading");
                }

                var result = await _dexService.ExecuteTrade(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("orderbook/{pairId}")]
        [Authorize] 
        public async Task<IActionResult> GetOrderBook(string pairId)
        {
            try
            {
                var orderBook = await _dexService.GetOrderBook(pairId);
                return Ok(orderBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("trades/history")]
        [Authorize]
        public async Task<IActionResult> GetTradeHistory()
        {
            try
            {
                var userId = _authService.GetCurrentUserId();
                var history = await _dexService.GetTradeHistory(userId);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        [HttpPost("order/cancel/{orderId}")]
        [Authorize]
        public async Task<IActionResult> CancelOrder(string orderId)
        {
            try
            {
                var userId = _authService.GetCurrentUserId();
                var result = await _dexService.CancelOrder(userId, orderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
